using CallScheduler.Enums;
using CallScheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("machinevariants")]
    public class MachineVariant : IEntityBase, IAuditDescriptionBase
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<Machine> Machines { get; set; }
        public ICollection<Part> Parts { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public object GetId() => Id;
        public string GetAuditDescription(AuditType action, bool forApproval)
        {
            var pad = forApproval ? " Subject to approval." : string.Empty;
            switch (action)
            {
                case AuditType.Create:
                    return $"Machine Variant (({Name}) created.";
                case AuditType.Update:
                    return $"Machine Variant ({Name}) was updated.";
                case AuditType.Delete:
                    return $"Deletion of Machine Variant  ({Name})";
                case AuditType.View:
                    return $"View Machine Variant  ({Name})";
                case AuditType.Suspend:
                    return $"Suspended Machine Variant  ({Name})";
                case AuditType.List:
                    return $"Accessed List of Machine Variants";
                case AuditType.Authorize:
                default: break;
            }
            return null;
        }
    }
}
