using System;
using System.ComponentModel.DataAnnotations;
using Reload.Common.Models;

namespace Reload.Common.System
{
	/// <summary>Represents an error in the system.</summary>
	public class Error : IBaseModel
	{
		[Key]
		public int Id { get; set; }

		public int AccountId { get; set; }

		public DateTime TimeStamp { get; set; }

		[Required]
		public string Location { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public string StackTrace { get; set; }

		public override string ToString()
		{
			return string.Format("Id: {1}{0} Location: {2}{0} Description: {3}{0} StackTrace: {4}{0}",
				this.Id,
				this.Location,
				this.Description,
				this.StackTrace
			);
		}

		public Error()
		{
			this.TimeStamp = DateTime.Now;
		}
	}
}