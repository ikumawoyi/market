using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CallScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CallScheduler.Extensions;
using CallScheduler.Data;
using CallScheduler.Interfaces;

namespace CallScheduler.Services
{
    public class PermissionService : IPermissionService
    {
        public CustomUser CurrentUser { get; set; }
        public CustomRole UserRole { get; set; }
        public bool IsSignedIn { get; set; }
        public bool HasPermission(string action)
        {
            if (string.IsNullOrWhiteSpace(action)) return true;
            if (CurrentUser == null) return false;
            if (UserRole == null) return false;

            return UserRole.IsPermissionInRole(action) && CurrentUser.IsPermissionNotRevoked(action);
        }

        public bool HasPermissions(string actions)
        {
            if (CurrentUser == null) return false;
            if (UserRole == null) return false;

            return actions?.Split(',')
                .Any(x => UserRole.IsPermissionInRole(x) && CurrentUser.IsPermissionNotRevoked(x)) ?? true;
        }

        public bool IsFirstLogin { get; set; }
        public string Logo { get; set; }
        // public Agent Scope { get; set; }
        private IHostingEnvironment Env { get; }
        public PermissionService(CallSchedulerDbContext db, IHostingEnvironment env, IHttpContextAccessor accessor)
        {
            // IpAddress = accessor.HttpContext.Request.GetRemoteAddress();
            Env = env;
            if (!(accessor.HttpContext.User?.Identity.IsAuthenticated ?? false)) return;
            IsSignedIn = true;
            var id = (accessor.HttpContext.User.Identity as ClaimsIdentity)?
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(id)) return;

            CurrentUser = db.Users
                .Include("Roles")
                .SingleOrDefault(x => x.Id == id);
            IsFirstLogin = CurrentUser?.LastLogin == null;
            //Logo = CurrentUser?.
            //            if (CurrentUser?.AgentId != null)
            //                Scope = db.SuperAgents.SingleOrDefault(x => x.Id == CurrentUser.AgentId);
            // Scope = CurrentUser?.Agent;
            // Logo = Scope?.Logo;
            id = CurrentUser?.Roles.FirstOrDefault()?.RoleId;
            if (string.IsNullOrWhiteSpace(id)) return;

            UserRole = db.Roles.SingleOrDefault(x => x.Id == id);

            // Logo = string.IsNullOrEmpty(CurrentUser?.InstitutionCode) ? "" : db.Institutions.FirstOrDefault(i => i.Code == CurrentUser.InstitutionCode).LogoPath;
        }

        public List<string> GetAllPermissions() =>
            ReadFile("/Common/user.permission")
                .Select(line => line.Split('.')?.Last()?.Trim())
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();

        public List<string> GetRawPermissions() =>
            ReadFile("/Common/user.permission")
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();

        public List<string> DisplayPermissions(IHostingEnvironment env) =>
            ReadFile("/Common/display.permission")
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();

        private IEnumerable<string> ReadFile(string path) => CallScheduler.Helpers.FileHelpers.ReadFile(Env.ContentRootPath + path);
        public string IpAddress { get; set; }
    }
}
