using CallScheduler.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallScheduler.Models
{
    [Table("settings")]
    public class Setting : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Key { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }

        public object GetId() => Id;
    }
}
