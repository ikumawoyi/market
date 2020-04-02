using CallScheduler.Data;
using CallScheduler.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallScheduler
{
    public static class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<CustomRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<CustomUser>>();
                var context = scope.ServiceProvider.GetRequiredService<CallSchedulerDbContext>();

                // seed default roles and users
                var seedRolesUsers = await SeedRolesUsers(userManager, roleManager);

                // seed banks and machine variants
                var seedBanks = await SeedBanks(context);
            }
        }

        public static async Task<BasicResponse> SeedRolesUsers(UserManager<CustomUser> userManager, RoleManager<CustomRole> roleManager)
        {
            string[] roleNames = { "Owner", "Admin" };

            foreach(var roleName in roleNames)
            {
                var role = await roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new CustomRole
                    {
                        Description = $"{roleName} role",
                        Name = roleName,
                        Permissions = "",
                        IsActive = true,
                        IsDeleted = false
                    };
                    await roleManager.CreateAsync(role);
                }
            }

            var listUsers = new List<Dictionary<string, string>>();
            var ownerUser = new Dictionary<string, string>
            {
                { "username", "Owner" },
                { "email", "michael.oyelami@outlook.com" },
                { "password", "Owner@12345" },
                { "rolename", "Owner" }
            };
            var adminUser = new Dictionary<string, string>
            {
                { "username", "Admin" },
                { "email", "michaeloyelami@gmail.com" },
                { "password", "Admin@12345" },
                { "rolename", "Admin" }
            };
            //var assigner = new Dictionary<string, string>
            //{
            //    { "username", "assigner" },
            //    { "email", "michaeloyelami@gmail.com" },
            //    { "password", "Assigner@12345" },
            //    { "rolename", "assigner" }
            //};
            //var initiator = new Dictionary<string, string>
            //{
            //    { "username", "initiator" },
            //    { "email", "michaeloyelami@gmail.com" },
            //    { "password", "Initiator@12345" },
            //    { "rolename", "initiator" }
            //};
            listUsers.Add(ownerUser);
            listUsers.Add(adminUser);
            //listUsers.Add(assigner);
            //listUsers.Add(initiator);

            try
            {
                foreach (var userDict in listUsers)
                {
                    var username = userDict.GetValue("username", true);
                    var user = await userManager.FindByNameAsync(username);
                    var result = new IdentityResult();

                    if (user == null)
                    {
                        user = new CustomUser
                        {
                            UserName = username,
                            Email = userDict.GetValue("email", true),
                            EmailConfirmed = true,
                            LastLogin = DateTime.Now,
                            ConcurrencyStamp = $"{Guid.NewGuid()}",
                            IsActive = true,
                            IsDeleted = false
                        };
                        result = await userManager.CreateAsync(user, userDict.GetValue("password", true));
                    }

                    if (result.Succeeded)
                    {
                        var roleName = userDict.GetValue("rolename", true);
                        var role = await roleManager.FindByNameAsync(roleName);
                        if (role == null)
                        {
                            role = new CustomRole
                            {
                                Description = $"{roleName} role",
                                Name = roleName,
                                Permissions = "",
                                IsActive = true,
                                IsDeleted = false
                            };
                            await roleManager.CreateAsync(role);
                        }
                        if (!await userManager.IsInRoleAsync(user, roleName))
                            await userManager.AddToRoleAsync(user, roleName);
                    }
                }
                return BasicResponse.SuccessResult("Default roles and users seeded succesfully");
            }
            catch (Exception e)
            {
                return BasicResponse.FailureResult(e.Message);
            }
        }

        public static async Task<BasicResponse> SeedBanks(CallSchedulerDbContext _context)
        {
            _context.Database.EnsureCreated();

            // banks dictionary
            var listBanks = new List<Dictionary<string, string>>();
            var UBA = new Dictionary<string, string>
            {
                { "bankcode", "1033" },
                { "name", "UBA" },
                { "shortName", "UBA" },
                { "address", "Umuahia 1 Bo Atm 4" },
                { "email", "uba@uba.com" },
                { "phone", "08094446789" },
                { "rcNo", "123456" },
                { "slaStartTime", "08:00" },
                { "slaEndTime", "17:00" }
            };
            var UB = new Dictionary<string, string>
            {
                { "bankcode", "1215" },
                { "name", "Unity Bank" },
                { "shortName", "UB" },
                { "address", "Umuahia" },
                { "email", "unity@gmail.com" },
                { "phone", "08095556743" },
                { "rcNo", "908765" },
                { "slaStartTime", "09:00" },
                { "slaEndTime", "18:00" }
            };
            var Keystone = new Dictionary<string, string>
            {
                { "bankcode", "1082" },
                { "name", "Keystone Bank" },
                { "shortName", "KB" },
                { "address", "Ph/Aba Road" },
                { "email", "keystone@gmail.com" },
                { "phone", "08095556743" },
                { "rcNo", "908761" },
                { "slaStartTime", "09:00" },
                { "slaEndTime", "18:00" }
            };
            var ECO = new Dictionary<string, string>
            {
                { "bankcode", "1050" },
                { "name", "Eco Bank" },
                { "shortName", "EB" },
                { "address", "Ab Ngwa Rd Aba" },
                { "email", "eko@gmail.com" },
                { "phone", "08095556743" },
                { "rcNo", "908765" },
                { "slaStartTime", "09:00" },
                { "slaEndTime", "18:00" }
            };
            var Heritage = new Dictionary<string, string>
            {
                { "bankcode", "1030" },
                { "name", "Heritage Bank" },
                { "shortName", "HB" },
                { "address", "Lagos" },
                { "email", "heritage@gmail.com" },
                { "phone", "08095556743" },
                { "rcNo", "908765" },
                { "slaStartTime", "09:00" },
                { "slaEndTime", "18:00" }
            };
            var Polaris = new Dictionary<string, string>
            {
                { "bankcode", "1076" },
                { "name", "Polaris Bank" },
                { "shortName", "PB" },
                { "address", "Lagos" },
                { "email", "polaris@gmail.com" },
                { "phone", "08095556743" },
                { "rcNo", "908765" },
                { "slaStartTime", "09:00" },
                { "slaEndTime", "18:00" }
            };
            var Wema = new Dictionary<string, string>
            {
                { "bankcode", "1035" },
                { "name", "Wema Bank" },
                { "shortName", "WB" },
                { "address", "Lagos" },
                { "email", "wema@gmail.com" },
                { "phone", "08095556743" },
                { "rcNo", "908765" },
                { "slaStartTime", "09:00" },
                { "slaEndTime", "18:00" }
            };
            var Access = new Dictionary<string, string>
            {
                { "bankcode", "1044" },
                { "name", "Access Bank" },
                { "shortName", "AB" },
                { "address", "Lagos" },
                { "email", "wema@gmail.com" },
                { "phone", "08095556743" },
                { "rcNo", "908765" },
                { "slaStartTime", "09:00" },
                { "slaEndTime", "18:00" }
            };
            listBanks.Add(UBA);
            listBanks.Add(UB);
            listBanks.Add(Keystone);
            listBanks.Add(ECO);
            listBanks.Add(Heritage);
            listBanks.Add(Polaris);
            listBanks.Add(Wema);
            listBanks.Add(Access);

            // machine variants dictionary
            var listMachineVariants = new List<Dictionary<string, string>>();
            var NCR = new Dictionary<string, string>
            {
                { "code", "0001" },
                { "name", "NCR" }
            };
            var Wincor = new Dictionary<string, string>
            {
                { "code", "0002" },
                { "name", "Wincor" }
            };
            listMachineVariants.Add(NCR);
            listMachineVariants.Add(Wincor);

            

            try
            {
                foreach (var bankDict in listBanks)
                {
                    var bankCode = bankDict.GetValue("bankcode", true);
                    var bank = _context.Banks.FirstOrDefault(c => c.BankCode == bankCode);
                    if (bank == null)
                    {
                        bank = new Bank()
                        {
                            BankCode = bankCode,
                            Name = bankDict.GetValue("name", true),
                            ShortName = bankDict.GetValue("shortName", true),
                            Address = bankDict.GetValue("address", true),
                            Email = bankDict.GetValue("email", true),
                            Phone = bankDict.GetValue("phone", true),
                            RcNo = bankDict.GetValue("rcNo", true),
                            SLAAmount = 5000.00m,
                            SLADuration = 5,
                            SLAStartTime = bankDict.GetValue("slaStartTime", true),
                            SLAEndTime = bankDict.GetValue("slaEndTime", true),
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        };
                        _context.Banks.Add(bank);
                        await _context.SaveChangesAsync();
                    }
                }
                foreach (var machineVariantDict in listMachineVariants)
                {
                    var code = machineVariantDict.GetValue("code", true);
                    var name = machineVariantDict.GetValue("name", true);
                    var machineVariant = _context.MachineVariants.FirstOrDefault(c => c.Code == code);
                    if (machineVariant == null)
                    {
                        machineVariant = new MachineVariant()
                        {
                            Code = code,
                            Name = name,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        };
                        _context.MachineVariants.Add(machineVariant);
                        await _context.SaveChangesAsync();
                    }
                }
                return BasicResponse.SuccessResult("Banks and machine variant seeded successfully!");
            }
            catch (Exception e)
            {
                return BasicResponse.FailureResult(e.Message);
            }
        }
    }
}
