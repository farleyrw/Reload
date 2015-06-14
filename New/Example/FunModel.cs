using System.ComponentModel.DataAnnotations;

namespace Reload.New.Example
{
	public class FunModel
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }
	}
}