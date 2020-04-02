using CallScheduler.Enums;
using CallScheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CallScheduler.Models
{
    [Table("bankadmins")]
    public class BankAdmin : IEntityBase, IAuditDescriptionBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // public string InitiatorCode { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public int BankId { get; set; }
        public Bank Bank { get; set; }

        // public ICollection<Call> Calls { get; set; }
        // public ICollection<InitiatedCall> InitiatedCalls { get; set; }

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
                    return $"Bank admin (({Name}) created.";
                case AuditType.Update:
                    return $"Bank admin ({Name}) was updated.";
                case AuditType.Delete:
                    return $"Deletion of bank admin ({Name})";
                case AuditType.View:
                    return $"View bank admin ({Name})";
                case AuditType.Suspend:
                    return $"Suspended bank admin ({Name})";
                case AuditType.List:
                    return $"Accessed list of bank admins";
                case AuditType.Authorize:
                default: break;
            }
            return null;
        }
    }
}
