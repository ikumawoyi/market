using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("audits")]
    public class AuditTrail
    {
        public AuditTrail() => TimeStamp = DateTime.Now;

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Action { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Entity { get; set; }
        [StringLength(50)]
        public string EntityId { get; set; }
        [StringLength(2000)]
        public string OriginalValues { get; set; }
        [StringLength(2000)]
        public string NewValues { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        [StringLength(100)]
        public string User { get; private set; }
        [StringLength(50)]
        public string UserId { get; private set; }
        [StringLength(20)]
        public string IPAddress { get; private set; }
        [StringLength(100)]
        public string Scope { get; private set; }
    }
}
