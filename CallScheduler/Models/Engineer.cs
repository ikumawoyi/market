using CallScheduler.Enums;
using CallScheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("engineers")]
    public class Engineer : IEntityBase, IAuditDescriptionBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EngineerCode { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public int TeamLeadId { get; set; }
        public TeamLead TeamLead { get; set; }

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
                    return $"Engineer (({Name}) created.";
                case AuditType.Update:
                    return $"Engineer({Name}) was updated.";
                case AuditType.Delete:
                    return $"Deletion of engineer ({Name})";
                case AuditType.View:
                    return $"View engineer ({Name})";
                case AuditType.Suspend:
                    return $"Suspended engineer ({Name})";
                case AuditType.List:
                    return $"Accessed List of Engineers";
                case AuditType.Authorize:
                default: break;
            }
            return null;
        }
    }
}
