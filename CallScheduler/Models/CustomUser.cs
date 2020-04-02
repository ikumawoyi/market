using CallScheduler.Enums;
using CallScheduler.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CallScheduler.Models
{
    [Table("users")]
    public class CustomUser : IdentityUser, IEntityBase, IAuditDescriptionBase
    {
        [StringLength(256)]
        public override string ConcurrencyStamp { get; set; } = $"{Guid.NewGuid()}";
        [StringLength(256)]
        public string Name { get; set; }
        public string AssignerCode { get; set; }
        public string EngineerCode { get; set; }
        public string LeadCode { get; set; }
        public string TeamLead { get; set; }
        public string InitiatorCode { get; set; }
        public string BankCode { get; set; }
        [StringLength(256)]
        public string FirstName { get; set; }
        [StringLength(256)]
        public string LastName { get; set; }
        [StringLength(256)]
        public string OtherName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Zone { get; set; }

        public string ImageName { get; set; }

        [Display(Name = "Revoked Permissions"), StringLength(2000)]
        public string RevokedPermissions { get; set; }

        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();

        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; } = new List<IdentityUserClaim<string>>();

        /// <summary>
        /// Navigation property for this users login accounts.
        /// </summary>
        /// 

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; } = new List<IdentityUserLogin<string>>();

        public DateTime? LastLogin { get; internal set; }

        public bool IsPermissionNotRevoked(string permission) => RevokedPermissions?.Split(',').All(x => x != permission) ?? true;
        public object GetId() => Id;
        public string GetAuditDescription(AuditType action, bool forApproval = false)
        {
            var pad = forApproval ? " Subject to approval." : string.Empty;
            // var agency = Agent == null ? string.Empty : $" - {Agent?.Name}";

            switch (action)
            {
                case AuditType.Create:
                    return $" User ({UserName}({PhoneNumber}) created.{pad}";
                case AuditType.Update:
                    return $"User ({UserName}({PhoneNumber}) was updated.{pad}";
                case AuditType.Delete:
                    return $"Deletion of user ({UserName}({PhoneNumber}).{pad}";
                case AuditType.View:
                    return $"View user ({UserName}({PhoneNumber})";
                case AuditType.Suspend:
                    return $"Suspended user ({UserName}({PhoneNumber})";
                case AuditType.List:
                    return $"Accessed List of Users ";
                case AuditType.Authorize:
                default: break;
            }
            return null;
        }

        [NotMapped]
        public string RoleName { get; set; }

        [NotMapped]
        public string Pwd { set; get; }
    }
}
