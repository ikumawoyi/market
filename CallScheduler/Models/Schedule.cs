using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("schedules")]
    public class Schedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CallId { get; set; }
        public string CallOrderNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateToRun { get; set; }
    }
}
