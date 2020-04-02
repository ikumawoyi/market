using CallScheduler.Data;
using CallScheduler.Extensions;
using CallScheduler.Interfaces;
using CallScheduler.Models;
using CallScheduler.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CallScheduler.Controllers
{
    [Authorize]
    [Route("api")]
    public class AuthController : Controller
    {
        private readonly IPermissionService _perm;
        private readonly UserManager<CustomUser> _userManager;
        private readonly CallSchedulerDbContext _db;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly IAuditService _audit;

        public AuthController(SignInManager<CustomUser> signInManager, 
            UserManager<CustomUser> userManager, IPermissionService perm,
            CallSchedulerDbContext db, IAuditService audit)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
            _audit = audit;
            _perm = perm;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<BasicResponse> Login(LoginViewModel model, string returnUrl = null)
        {
            var copy = _perm;
            ViewData["ReturnUrl"] = returnUrl;

            if (string.IsNullOrEmpty(returnUrl))
            {
                ViewData["ReturnUrl"] = "";
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var identity = $"{user.UserName}".Trim();

                    //var isRemoved = await _userManager.RemovePasswordAsync(user);
                    //var isAdded = await _userManager.AddPasswordAsync(user, "Password@1");

                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        var defaultUrl = "/Home/Index";
                        if (user.LastLogin != null)
                        {
                            user.LastLogin = DateTime.Now;
                            await _userManager.UpdateAsync(user);
                            return BasicResponse.SuccessResult(defaultUrl);
                        }
                        defaultUrl = $"/Home/FirstChangePassword?username={model.UserName}";
                        await _signInManager.SignOutAsync();
                        return BasicResponse.SuccessResult(defaultUrl);
                    }
                    if (result.IsLockedOut)
                    {
                        return BasicResponse.FailureResult("User account locked out.");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return BasicResponse.FailureResult(ModelState.GetModelErrors());
        }

        [AllowAnonymous]
        [HttpPost("changepassword")]
        public async Task<BasicResponse> ChangePassword(string Username, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                var user = await _userManager.FindByNameAsync(Username);
                if (user != null)
                {
                    if (string.IsNullOrEmpty(NewPassword))
                        return BasicResponse.FailureResult("Password change failed, New password is required!");
                    if (NewPassword != ConfirmPassword)
                        return BasicResponse.FailureResult("The new password and confirmation password do not match.");
                    var result = await _userManager.ChangePasswordAsync(user, OldPassword, NewPassword);
                    if (result.Succeeded)
                    {
                        user.LastLogin = DateTime.Now;
                        var response = await _userManager.UpdateAsync(user);
                        await _audit.CreateAudit("Change Password", "Password change successful");
                        if (_perm.IsSignedIn) await _signInManager.SignOutAsync();
                        return BasicResponse.SuccessResult("/Home/Login");
                    }
                    await _audit.CreateAudit("Change Password", "Password change failed");
                    return BasicResponse.FailureResult("Password change failed!");
                }
                await _audit.CreateAudit("Change Password", "Password change failed");
                return BasicResponse.FailureResult("Password change failed, User does not exist!");
            }
            await _audit.CreateAudit("Change Password", "Password change failed");
            return BasicResponse.FailureResult("Password change failed, Username is required!");
        }

        [AllowAnonymous]
        [HttpPost("resetpassword")]
        public async Task<BasicResponse> ResetPassword(string Username)
        {
            var username = Username;
            if (username != null)
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user != null)
                {
                    // var password = RandomPassword.Generate(10);
                    var password = "Password@1";
                    var isRemoved = await _userManager.RemovePasswordAsync(user);
                    var isAdded = await _userManager.AddPasswordAsync(user, password);
                    if (isRemoved.Succeeded && isAdded.Succeeded)
                    {
                        user.Pwd = password;

                        //send email to new user
                        //var emailSetting = _db.Settings.FirstOrDefault(x => x.Key == "Admin.Email.ResetPassword")?.Value;
                        //var emailTemplate = communication.GetTemplatedMessage(emailSetting, user);
                        //var sendEmail = await communication.SendEmail($"{user.Email}", "PayAttitude Shopping Solution", emailTemplate, "Shopping");
                        //await _audit.CreateAudit("Reset Password", "Password reset successful");
                        // user.LastLogin = DateTime.Now;
                        user.LastLogin = null;
                        await _userManager.UpdateAsync(user);
                        return BasicResponse.SuccessResult("/Home/Login");
                    }
                    await _audit.CreateAudit("Reset Password", "Password reset failed");
                    return BasicResponse.FailureResult("Password reset failed!");
                }
                await _audit.CreateAudit("Reset Password", "Password reset failed");
                return BasicResponse.FailureResult("Password reset failed, User does not exist!");
            }
            await _audit.CreateAudit("Reset Password", "Password reset failed");
            return BasicResponse.FailureResult("Password reset failed, Username is required!");
        }
    }
}