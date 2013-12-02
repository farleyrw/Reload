using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Reload.Common.Enums.Components;
using Reload.Common.Models.Components;

namespace Reload.Common.Models
{
	public class Handload
	{
		[Key]
		public int HandloadId { get; set; }

		public Powder Powder { get; set; }

		[Required]
		public long PowderCharge { get; set; }

		public Primer Primer { get; set; }

		public Brass Casing { get; set; }

		[Required]
		public long SeatingDepth { get; set; }

		public Bullet Bullet { get; set; }

		[ForeignKey("FirearmId")]
		public Firearm Firearm { get; set; }
	}
}