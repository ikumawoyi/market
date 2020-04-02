using CallScheduler.Enums;
using CallScheduler.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("parts")]
    public class Part : IEntityBase, IAuditDescriptionBase
    {
        [Key]
        public int Id { get; set; }
        public string PartCode { get; set; }
        public string Name { get; set; }

        public int MachineVariantId { get; set; }
        public MachineVariant MachineVariant { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public object GetId() => Id;
        public string GetAuditDescription(AuditType action, bool forApproval)
        {
            var pad = forApproval ? " Subject to approval." : string.Empty;
            switch (action)
            {
                case AuditType.Create:
                    return $"Part (({PartCode}) created.";
                case AuditType.Update:
                    return $"Part ({PartCode}) was updated.";
                case AuditType.Delete:
                    return $"Deletion of part ({PartCode})";
                case AuditType.View:
                    return $"View part ({PartCode})";
                case AuditType.Suspend:
                    return $"Suspended part ({PartCode})";
                case AuditType.List:
                    return $"Accessed List of Parts";
                case AuditType.Authorize:
                default: break;
            }
            return null;
        }
    }
}
