using CallScheduler.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CallScheduler.Controllers
{
    [Authorize]
    [Route("api/roles")]
    public class RolesController : Controller
    {
        private readonly RoleManager<CustomRole> _roleManager;

        public RolesController(RoleManager<CustomRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [Route("{page}/{pageSize}")]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var roles = _roleManager.Roles.Where(r => r.Name != "Owners");
            var currentRoles = await PaginatedList<CustomRole>.CreateAsync(roles, page, pageSize);
            ViewBag.NumberOfPages = Utils.GetPages(roles, pageSize);
            return View(currentRoles);
        }
    }
}