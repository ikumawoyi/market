using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallScheduler.Models
{
	public class Incident
	{
		public int Id { get; set; }
		public int IncidentId { get; set; }
		public string IncidentType { get; set; }
		public string IncidentDescription { get; set; }

		public ICollection<Record> Records { get; set; }
	}
}
