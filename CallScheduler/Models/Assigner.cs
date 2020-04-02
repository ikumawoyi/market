using CallScheduler.Enums;
using CallScheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("assigners")]
    public class Assigner : IEntityBase, IAuditDescriptionBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AssignerCode { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public ICollection<Call> Calls { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        
        public string Passport { get; set; }

        public object GetId() => Id;
        public string GetAuditDescription(AuditType action, bool forApproval)
        {
            var pad = forApproval ? " Subject to approval." : string.Empty;
            switch (action)
            {
                case AuditType.Create:
                    return $"Assigner (({Name}) created.";
                case AuditType.Update:
                    return $"Assigner({Name}) was updated.";
                case AuditType.Delete:
                    return $"Deletion of assigner ({Name})";
                case AuditType.View:
                    return $"View assigner ({Name})";
                case AuditType.Suspend:
                    return $"Suspended assigner ({Name})";
                case AuditType.List:
                    return $"Accessed List of Assigners";
                case AuditType.Authorize:
                default: break;
            }
            return null;
        }
    }
}
