using CallScheduler.Enums;
using CallScheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("teamleads")]
    public class TeamLead : IEntityBase, IAuditDescriptionBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // public string InitiatorCode { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string LeadCode { get; set; }

        public ICollection<Engineer> Engineers { get; set; }

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
                    return $"Team lead (({Name}) created.";
                case AuditType.Update:
                    return $"Team lead ({Name}) was updated.";
                case AuditType.Delete:
                    return $"Deletion of team lead ({Name})";
                case AuditType.View:
                    return $"View team lead ({Name})";
                case AuditType.Suspend:
                    return $"Suspended team lead ({Name})";
                case AuditType.List:
                    return $"Accessed list of team leads";
                case AuditType.Authorize:
                default: break;
            }
            return null;
        }
    }
}
