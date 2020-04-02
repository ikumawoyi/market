using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CallScheduler.Models
{
	[Table("records")]
	public class Record
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string AdministeredPRN { get; set; }

		public int IncidentId { get; set; }
		public Incident Incident { get; set; }
		public int CareId { get; set; }
		public Care Care { get; set; }
		public DateTime? DateCompleted { get; set; }
	}
}
