using CallScheduler.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CallScheduler.Models
{
    [Table("roles")]
    public class CustomRole : IdentityRole<string>, IEntityBase
    {
        public object GetId() => Id;
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        [NotMapped]
        public string Permissions { get; set; }

        [StringLength(256)]
        public override string ConcurrencyStamp { get; set; } = $"{Guid.NewGuid()}";
        public bool IsPermissionInRole(string permission) => Permissions == "*" || (Permissions?.Split(',').Any(x => x == permission) ?? false);
        public bool CanPerformAction(string action) => Permissions?.Split(',').Any(x => x == action) ?? false;
    }
}
