using CallScheduler.Data;
using CallScheduler.Interfaces;
using CallScheduler.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CallScheduler.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly RoleManager<CustomRole> _roleManager;
        private readonly IAuditService _audit;
        private readonly IEmailSender _emailSender;
        private readonly CallSchedulerDbContext _context;
        private readonly IImageHandler _imageHandler;
        private readonly SignInManager<CustomUser> _signInManager;

        public HomeController(UserManager<CustomUser> userManager,
            RoleManager<CustomRole> roleManager, SignInManager<CustomUser> signInManager, IAuditService audit,
            IEmailSender emailSender, CallSchedulerDbContext context, IImageHandler imageHandler)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _audit = audit;
            _emailSender = emailSender;
            _context = context;
            _imageHandler = imageHandler;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Login(string returnUrl = null)
        { 
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;

            if (string.IsNullOrEmpty(returnUrl))
            {
                ViewData["ReturnUrl"] = "";
            }

            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult AddRole()
        {
            return View();
        }

        // POST: ApplicationRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole([Bind("Description,Id, Name")] CustomRole applicationRole)
        {
            applicationRole.DateCreated = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(applicationRole);
                _context.Add(applicationRole);
              //  await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationRole);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            // _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult FirstChangePassword(string username = null)
        {
            ViewData["Username"] = username;
            return View();
        }

        public IActionResult ChangePassword(string username = null)
        {

            var userId = _userManager.GetUserId(HttpContext.User);
            CustomUser user = _userManager.FindByIdAsync(userId).Result;
            var userName = user.UserName;
           
            ViewData["Username"] = userName;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
