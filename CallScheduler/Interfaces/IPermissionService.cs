using CallScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallScheduler.Interfaces
{
    public interface IPermissionService
    {
        CustomUser CurrentUser { get; set; }
        CustomRole UserRole { get; set; }
        bool IsSignedIn { get; set; }
        bool HasPermission(string action);
        bool HasPermissions(string actions);
        string Logo { get; set; }
        bool IsFirstLogin { get; set; }
        string IpAddress { get; set; }
    }
}