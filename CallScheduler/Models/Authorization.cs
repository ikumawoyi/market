using CallScheduler.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("authorizations")]
    public class Authorization
    {
        [Key]
        public int Id { get; set; }
        [StringLength(40, MinimumLength = 4)]
        public string Action { get; set; }
        [StringLength(50)]
        public string EntityId { get; set; }
        [StringLength(30)]
        public string EntityType { get; set; }
        [StringLength(30)]
        public string Requester { get; set; }
        public DateTime? RequestTimestamp { get; private set; } = DateTime.Now;
        public bool? IsApproved { get; set; }
        [StringLength(25)]
        public string Authorizer { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public DateTime? AuthorizeTimestamp { get; set; }
        [StringLength(2000)]
        public string EntityJson { get; set; }
        [StringLength(200)]
        public string DeclineReason { get; set; }
        [StringLength(30)]
        public string Agent { get; set; }
        public AuditType AuditType { get; set; }
        [StringLength(50)]
        public string Status { get; set; }

        public string IPAddress { get; set; }

        public Dictionary<string, string> Parameters = new Dictionary<string, string>();
    }
}
