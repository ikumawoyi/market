using CallScheduler.Data;
using CallScheduler.Interfaces;
using CallScheduler.Models;
using CallScheduler.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallScheduler.Controllers
{
    [Authorize]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IPermissionService _perm;
        private readonly UserManager<CustomUser> _userManager;
        private readonly RoleManager<CustomRole> _roleManager;
        private readonly IAuditService _audit;
        private readonly IEmailSender _emailSender;
        private readonly CallSchedulerDbContext _context;
        private readonly IImageHandler _imageHandler;
        public readonly IOptions<EmailSettings> _appSettings;

        public UsersController(UserManager<CustomUser> userManager,
            RoleManager<CustomRole> roleManager, IAuditService audit, IOptions<EmailSettings> appSettings,
            IEmailSender emailSender, CallSchedulerDbContext context, IPermissionService perm, IImageHandler imageHandler)
        {
            _perm = perm;
            _roleManager = roleManager;
            _userManager = userManager;
            _audit = audit;
            _emailSender = emailSender;
            _context = context;
            _imageHandler = imageHandler;
            _appSettings = appSettings;
        }

        [Route("{page}/{pageSize}")]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 1000)
        {
            var usersWithRoles = (from user in _userManager.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      FirstName = user.FirstName,
                                      OtherName = user.OtherName,
                                      LastName = user.LastName,
                                     // Zone = user.Zone,
                                      PhoneNumber = user.PhoneNumber,
                                     // IsActive = user.IsActive,
                                     // IsDeleted = user.IsDeleted,
                                      FullName = $"{user.FirstName} {user.OtherName} {user.LastName}",
                                      RoleNames = (from userRole in user.Roles
                                                   join role in _roleManager.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).Select(p => new UserViewModel()

                                  {
                                      UserId = p.UserId,
                                      UserName = p.Username,
                                      FirstName = p.FirstName,
                                      OtherName = p.OtherName,
                                      LastName = p.LastName,
                                      FullName = p.FullName,
                                      
                                      Email = p.Email,
                                      PhoneNumber = p.PhoneNumber,
                                     // IsActive = p.IsActive,
                                     // IsDeleted = p.IsDeleted,
                                      Role = string.Join(",", p.RoleNames)
                                  });

            await _audit.CreateAudit("View Users", "Viewed list of users");
            var currentUsers = await PaginatedList<UserViewModel>.CreateAsync(
                usersWithRoles.Where(u => u.UserName != "Owners" && u.UserName != "Admins"), page, pageSize);
            ViewBag.NumberOfPages = Utils.GetPages(usersWithRoles, pageSize);
            return View(currentUsers);
        }

        [Route("create")]
        public IActionResult Create()
        {
            var isAdmin = (_perm.UserRole.Name == "Admin" || _perm.UserRole.Name == "CareAdmin") ? true : false;
            var roles = _roleManager.Roles;
            ViewBag.Roles = isAdmin ?
                new SelectList(roles.Where(r => r.Name != "Admin" || r.Name != "BankAdmin"), "Name", "Name") :
                new SelectList(roles.Where(r => r.Name == "Owner" && r.Name == "Admin" && r.Name == "BankAdmin"), "Name", "Name");
            //var banks = _context.Banks;
            //ViewBag.Banks = new SelectList(banks, "BankCode", "Name");
            //var teamleads = _context.TeamLeads;
            //ViewBag.TeamLeads = new SelectList(teamleads, "Id", "Name");
            //ViewData["IsAdmin"] = isAdmin;
            //ViewData["BankCode"] = _perm.CurrentUser.BankCode;
            return View();
        }

        [HttpPost("create")]
        public async Task<BasicResponse> Create([FromForm] CreateUserViewModel model)
        {
            if (model.File == null) return BasicResponse.FailureResult("Image is required");
            var resp = await _imageHandler.UploadImage(model.File);
            var url = "";
            if (!string.IsNullOrEmpty(resp)) url = resp;

            var userName = model.Username;
            var userEmail = model.Email;
            var userCode = Utils.GenerateCode(8);
            //var bankCode = !string.IsNullOrEmpty(model.BankCode) ? model.BankCode : "";
            //var bankId = 0;
            if (string.IsNullOrEmpty(userName))
                return BasicResponse.FailureResult("User was not created, Username was not provided.");
            if (string.IsNullOrEmpty(userEmail))
                return BasicResponse.FailureResult("User was not created, Email was not provided.");
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userEmail))
            {
                var user = await _userManager.FindByNameAsync(userName);
                var userE = await _userManager.FindByEmailAsync(userEmail);
                if (user != null)
                {
                    return BasicResponse.FailureResult("User record was not saved, Username already exists.");
                }
                if (userE != null)
                {
                    return BasicResponse.FailureResult("User record was not saved, Email already exists.");
                }
                if (user == null && userE == null)
                {
                    user = new CustomUser
                    {
                        UserName = model.Username,
                        Email = model.Email,
                        EmailConfirmed = true,
                        ConcurrencyStamp = $"{Guid.NewGuid()}",
                        FirstName = model.FirstName,
                        OtherName = model.OtherName,
                        LastName = model.LastName,
                        PhoneNumber = model.Phone,
                       // BankCode = model.BankCode,
                       // LeadCode = model.LeadCode,
                       // IsActive = true,
                       // IsDeleted = false,
                        ImageName = url,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now
                    };
                    var roleName = model.RoleName;
                    var role = await _roleManager.FindByNameAsync(roleName);
                    if (role == null)
                        return BasicResponse.FailureResult("Selected role does not exist!");
                    //if (roleName == "Initiator" || roleName == "BankAdmin" )
                    //{
                    //    if (string.IsNullOrEmpty(bankCode)) return BasicResponse.FailureResult("Initiator must belong to bank");
                    //    var bank = _context.Banks.FirstOrDefault(b => b.BankCode == bankCode);
                    //    if (bank == null) return BasicResponse.FailureResult("Selected Bank does not exist, Contact Administrator");
                    //    bankId = (bank != null) ? bank.Id : 0;

                    //}

                    // var password = RandomPassword.Generate(8);

                    var password = "Password@1";
                    var result = await _userManager.CreateAsync(user, password);
                    if (result.Succeeded && !await _userManager.IsInRoleAsync(user, roleName))
                    {
                        await _userManager.AddToRoleAsync(user, roleName);
                        user.Pwd = password;

                        // add user to initiator, assigner or engineer table
                        var userIAE = await _userManager.FindByNameAsync(userName);
                        // var email = _context.Banks.Where(b => b.BankCode == bankCode).Select(b => b.Email).FirstOrDefault();
                        if (roleName == "TeamLead")
                        {
                            var teamLead = new TeamLead
                            {
                                LeadCode  = $"TL{userCode}",
                                FirstName = model.FirstName,
                                OtherName = model.OtherName,
                                LastName = model.LastName,
                                Name = $"{model.FirstName} {model.LastName}",
                                DateCreated = DateTime.Now,
                                DateUpdated = DateTime.Now
                            };
                            var msg = $"{"You have been profiled on our call logging platform in Ark Technology as a Team Lead with "}{ teamLead.FirstName}, { teamLead.LastName} {". And your password is "}{password} {"with username " }{user.UserName}{" on "}{teamLead.DateCreated} {"  Logon to http://52.14.79.38/ using your usersame and password"}" ;
                            if (teamLead.LastName != null)
                            {
                               var  TLemail = model.Email.ToString();


                                var sendMail = _emailSender.SendEmailAsync(TLemail, "Call Notification", msg);
                            }
                            _context.TeamLeads.Add(teamLead);
                            await _context.SaveChangesAsync();
                            if (userIAE != null) userIAE.LeadCode = teamLead.LeadCode;
                            var response = await _userManager.UpdateAsync(userIAE);

                        }
                        //else if (roleName == "BankAdmin")
                        //{
                        //    var bankAdmin = new BankAdmin
                        //    {
                        //        // InitiatorCode = $"BA{userCode}",
                        //        FirstName = model.FirstName,
                        //        OtherName = model.OtherName,
                        //        LastName = model.LastName,
                        //        Name = $"{model.FirstName} {model.LastName}",
                        //        BankId = bankId,
                        //        DateCreated = DateTime.Now,
                        //        DateUpdated = DateTime.Now
                        //    };
                        //    var msg = $"{"You have been profiled on our call logging platform in Ark Technology as a BankAdmin with  "}{ bankAdmin.LastName}, { bankAdmin.Name} {". And your password is "}{password} {"with username " }{user.UserName}{" on "}{bankAdmin.DateCreated}  {"  Logon to http://52.14.79.38/ using your usersame and password"}";
                        //    if (bankAdmin.LastName != null)
                        //    {
                        //      var Bemail = model.Email.ToString();


                        //        var sendMail = _emailSender.SendEmailAsync(Bemail, "Call Notification", msg);
                        //    }
                        //    _context.BankAdmins.Add(bankAdmin);
                        //    await _context.SaveChangesAsync();
                        //}
                        //else if (roleName == "Initiator")
                        //{
                        //    var initiator = new Initiator
                        //    {
                        //        InitiatorCode = $"IN{userCode}",
                        //        FirstName = model.FirstName,
                        //        OtherName = model.OtherName,
                        //        LastName = model.LastName,
                        //        Name = $"{model.FirstName} {model.LastName}",
                        //        BankId = bankId,
                        //        DateCreated = DateTime.Now,
                        //        DateUpdated = DateTime.Now
                        //    };
                        //    var msg = $"{"You have been created on our call logging platform in Ark Technology as a call Initiator with "}{ initiator.FirstName}, { initiator.Name} {". And your password is "}{password} {"with username " }{user.UserName}{" on "}{initiator.DateCreated}  {"  Logon to http://52.14.79.38/ using your usersame and password"}";
                        //    if (initiator.LastName != null)
                        //    {
                        //       var Iemail = model.Email.ToString();
                                

                        //        var sendMail = _emailSender.SendEmailAsync(Iemail, "Call Notification", msg);
                        //    }
                        //    _context.Initiators.Add(initiator);
                        //    await _context.SaveChangesAsync();
                        //    if (userIAE != null) userIAE.InitiatorCode = initiator.InitiatorCode;
                        //    var response = await _userManager.UpdateAsync(userIAE);
                        //}
                        //else if (roleName == "Engineer")
                        //{
                        //    if (!model.TeamLeadId.HasValue)
                        //        return BasicResponse.FailureResult("Team lead must be selected for Engineer!");
                        //    var engineer = new Engineer
                        //    {
                        //        EngineerCode = $"EN{userCode}",
                        //        FirstName = model.FirstName,
                        //        OtherName = model.OtherName,
                        //        LastName = model.LastName,
                        //        TeamLeadId = model.TeamLeadId.Value,
                        //        Name = $"{model.FirstName} {model.LastName}",
                        //        DateCreated = DateTime.Now,
                        //        DateUpdated = DateTime.Now
                        //    };
                        //    var msg = $"{"You have been created on our call logging platform in Ark Technology as a field engineer with "}{ engineer.FirstName}, { engineer.Name} {". And your password is "}{password} {"with username " }{user.UserName}{" on "}{engineer.DateCreated}  {"  Logon to http://52.14.79.38/ using your usersame and password"}";
                        //    if (engineer.FirstName != null)
                        //    {
                        //     var   Engemail = model.Email.ToString();


                        //        var sendMail = _emailSender.SendEmailAsync(Engemail, "Call Notification", msg);
                        //    }
                        //    _context.Engineers.Add(engineer);
                        //    await _context.SaveChangesAsync();
                        //    if (userIAE != null) userIAE.EngineerCode = engineer.EngineerCode;
                        //    var response = await _userManager.UpdateAsync(userIAE);
                        //}
                        //else if (roleName == "Assigner")
                        //{
                        //    var assigner = new Assigner
                        //    {
                        //        AssignerCode = $"AS{userCode}",
                        //        FirstName = model.FirstName,
                        //        OtherName = model.OtherName,
                        //        LastName = model.LastName,
                        //        Name = $"{model.FirstName} {model.LastName}",
                        //        DateCreated = DateTime.Now,
                        //        DateUpdated = DateTime.Now
                        //    };
                        //    var msg = $"{"You have been created on our call logging platform in Ark Technology as an Assigner with "}{ assigner.AssignerCode}, { assigner.Name} {". And your password is "}{password} {"with username " }{user.UserName}{" on "}{assigner.DateCreated}  {"  Logon to http://52.14.79.38/ using your usersame and password"}";
                        //    if (assigner.LastName != null)
                        //    {
                        //       var Aemail = model.Email.ToString();


                        //        var sendMail = _emailSender.SendEmailAsync(Aemail, "Call Notification", msg);
                        //    }
                        //    _context.Assigners.Add(assigner);
                        //    await _context.SaveChangesAsync();
                        //    if (userIAE != null) userIAE.AssignerCode = assigner.AssignerCode;
                        //    var response = await _userManager.UpdateAsync(userIAE);
                        //}

                        else
                        {
                            // admin users
                        }

                        await _emailSender.SendEmailAsync($"{user.Email}", "Confirm your email",
                            $"An account has been created for you on the Call Scheduler Solution. <br />" +
                            $"Username: {user.UserName} <br /> Password: {user.Pwd}");
                        await _audit.CreateAudit("Create User", "Creation of user successful");
                        return BasicResponse.SuccessResult("User saved!");
                    }
                    return BasicResponse.FailureResult("User was not saved!");
                }
            }
            return BasicResponse.FailureResult("Username and email are required.");
        }

        [Route("details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var user = await _userManager.FindByNameAsync(id);
            if (user != null)
            {
                var customUser = _context.Users.Include("Roles").SingleOrDefault(x => x.Id == user.Id);
                var roleId = customUser?.Roles.FirstOrDefault()?.RoleId;
                var userRole = _context.Roles.SingleOrDefault(x => x.Id == roleId);
                user.RoleName = userRole.Name;
                return View(user);
            }
            return RedirectToAction("Index");
        }
    }
}