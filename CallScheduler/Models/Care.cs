using CallScheduler.Enums;
using CallScheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CallScheduler.Models
{
	[Table("care")]
	public class Care : IEntityBase, IAuditDescriptionBase
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CareId { get; set; }
		public string CareCode { get; set; }
		public string FirstName { get; set; }
		public string OtherName { get; set; }
		public string LastName { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		

		public ICollection<Record> Records { get; set; }

		public DateTime? DateCreated { get; set; }
		public DateTime? DateUpdated { get; set; }
	//	public Gender Gender { get; set; }

		public string Passport { get; set; }

		public object GetId() => CareId;
		public string GetAuditDescription(AuditType action, bool forApproval)
		{
			var pad = forApproval ? " Subject to approval." : string.Empty;
			switch (action)
			{
				case AuditType.Create:
					return $"Care (({Name}) created.";
				case AuditType.Update:
					return $"Care({Name}) was updated.";
				case AuditType.Delete:
					return $"Deletion of care ({Name})";
				case AuditType.View:
					return $"View care ({Name})";
				case AuditType.Suspend:
					return $"Suspended care ({Name})";
				case AuditType.List:
					return $"Accessed List of Cares";
				case AuditType.Authorize:
				default: break;
			}
			return null;
		}
	}
}
