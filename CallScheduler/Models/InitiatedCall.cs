using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("initiatedcalls")]
    public class InitiatedCall
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CallOrderNumber { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorCode { get; set; }

        public int BankId { get; set; }
        public Bank Bank { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        public int InitiatorId { get; set; }
        public Initiator Initiator { get; set; }

        public bool IsAssigned { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
