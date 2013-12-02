﻿using System.ComponentModel.DataAnnotations;

namespace Reload.Common.System
{
	/// <summary>Represents an error in the system.</summary>
	public class Error
	{
		[Key]
		public int Id { get; set; }

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
	}
}