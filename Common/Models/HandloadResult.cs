using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reload.Common.Models
{
	public class HandloadResult : IBaseModel
	{
		[Key]
		public int HandloadResultId { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		public int Yardage { get; set; }

		[Required]
		public int TotalShots { get; set; }

		[Required]
		public double GroupSizeInches { get; set; }

		public WeatherConditions Weather { get; set; }

		//[ForeignKey("HandloadId")]
		public int HandloadId { get; set; }
	}
}