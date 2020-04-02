using CallScheduler.Enums;
using CallScheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("machines")]
    public class Machine : IEntityBase, IAuditDescriptionBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Terminal Code")]
        public string MachineCode { get; set; }

        public int BankId { get; set; }
        public string Location { get; set; }
        public Bank Bank { get; set; }

        public int MachineVariantId { get; set; }
        public MachineVariant MachineVariant { get; set; }

        public ICollection<Call> Calls { get; set; }
        public ICollection<InitiatedCall> InitiatedCalls { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public object GetId() => Id;
        public string GetAuditDescription(AuditType action, bool forApproval)
        {
            var pad = forApproval ? " Subject to approval." : string.Empty;
            switch (action)
            {
                case AuditType.Create:
                    return $"Machine (({MachineCode}) created.";
                case AuditType.Update:
                    return $"Machine({MachineCode}) was updated.";
                case AuditType.Delete:
                    return $"Deletion of machine ({MachineCode})";
                case AuditType.View:
                    return $"View machine ({MachineCode})";
                case AuditType.Suspend:
                    return $"Suspended machine ({MachineCode})";
                case AuditType.List:
                    return $"Accessed List of Machines";
                case AuditType.Authorize:
                default: break;
            }
            return null;
        }
    }
}
