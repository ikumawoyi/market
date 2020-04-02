using CallScheduler.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("calltimelines")]
    public class CallTimeline
    {
        [Key]
        public int Id { get; set; }
        public int CallId { get; set; }
        public Call Call { get; set; }
        public string CallOrderNumber { get; set; }
        public CallStatus Status { get; set; }
        public string EngineerLocation { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }

        [NotMapped]
        public string Duration
        {
            get
            {
                var duration = "";
                if (DateChanged.HasValue)
                {
                    duration = DateChanged.Value.Subtract(DateCreated).ToString(@"d\:hh\:mm\:ss");
                }
                else
                {
                    duration = DateTime.Now.Subtract(DateCreated).ToString(@"d\:hh\:mm\:ss");
                }
                return duration;
            }
        }
    }

    public class Status
    {
        public CallStatus Value { get; set; }
        public string Text { get; set; }
    }
}
