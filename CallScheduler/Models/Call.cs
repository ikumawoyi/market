using CallScheduler.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CallScheduler.Models
{
    [Table("calls")]
    public class Call
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CallOrderNumber { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorCode { get; set; }
        public string EngineerLocation { get; set; }
        public int SLADuration { get; set; }
        public decimal SLAAmount { get; set; }

        public int AssignerId { get; set; }
        public Assigner Assigner { get; set; }
        public int InitiatorId { get; set; }
        public Initiator Initiator { get; set; }
        public int EngineerId { get; set; }
        public Engineer Engineer { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        public ICollection<CallTimeline> CallTimelines { get; set; }

        public bool MetSLA { get; set; } // default to false
        public bool IsCompleted { get; set; } // default to false
        public CallStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime? DateCompleted { get; set; }

        public string Parts { get; set; }
        [NotMapped]
        private int _partsCount = 0;  // Backing store
        [NotMapped]
        public string PartsCount
        {
            get
            {
                if (!string.IsNullOrEmpty(Parts))
                {
                    _partsCount = Parts.Split(',').Count();
                }
                return _partsCount.ToString();
            }
        }
    }
}
