using CallScheduler.Enums;
using CallScheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("initiators")]
    public class Initiator : IEntityBase, IAuditDescriptionBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string InitiatorCode { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public int BankId { get; set; }
        public Bank Bank { get; set; }

        public ICollection<Call> Calls { get; set; }
        public ICollection<InitiatedCall> InitiatedCalls { get; set; }

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
                    return $"Initiator (({Name}) created.";
                case AuditType.Update:
                    return $"Initiator ({Name}) was updated.";
                case AuditType.Delete:
                    return $"Deletion of initiator ({Name})";
                case AuditType.View:
                    return $"View initiator ({Name})";
                case AuditType.Suspend:
                    return $"Suspended initiator ({Name})";
                case AuditType.List:
                    return $"Accessed List of initiators";
                case AuditType.Authorize:
                default: break;
            }
            return null;
        }
    }
}
