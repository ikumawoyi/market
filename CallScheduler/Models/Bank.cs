using CallScheduler.Enums;
using CallScheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("banks")]
    public class Bank : IEntityBase, IAuditDescriptionBase
    {
        [Key]
        public int Id { get; set; }
        public string BankCode { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [StringLength(25)]
        [Display(Name = "Rc No")]
        public string RcNo { get; set; }
        [Display(Name = "Bank Logo")]
        public string BankLogo { get; set; }
        public string SLAStartTime { get; set; }
        public string SLAEndTime { get; set; }
        [Required]
        public int SLADuration { get; set; }
        [Required]
        public decimal SLAAmount { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        
        public ICollection<Call> Calls { get; set; }
        public ICollection<Machine> Machines { get; set; }
        public ICollection<Initiator> Initiators { get; set; }
        public ICollection<InitiatedCall> InitiatedCalls { get; set; }

        public object GetId() => Id;
        public string GetAuditDescription(AuditType action, bool forApproval)
        {
            var pad = forApproval ? " Subject to approval." : string.Empty;
            switch (action)
            {
                case AuditType.Create:
                    return $"Bank (({Name}) created.";
                case AuditType.Update:
                    return $"Bank({Name}) was updated.";
                case AuditType.Delete:
                    return $"Deletion of bank ({Name})";
                case AuditType.View:
                    return $"View bank ({Name})";
                case AuditType.Suspend:
                    return $"Suspended bank ({Name})";
                case AuditType.List:
                    return $"Accessed List of Banks";
                case AuditType.Authorize:
                default: break;
            }
            return null;
        }
    }
}
