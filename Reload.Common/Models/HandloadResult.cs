using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reload.Common.Models
{
	public class HandloadResult
	{
		[Key]
		public int HandloadResultId { get; set; }

		public DateTime Date { get; set; }

		[Required]
		public int TotalShots { get; set; }

		[Required]
		public long GroupSize { get; set; }

		public WeatherConditions Weather { get; set; }

		[ForeignKey("HandloadId")]
		public Handload Handload { get; set; }
	}
}