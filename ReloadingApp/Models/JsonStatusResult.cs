
namespace Reload.Web.Models
{
	/// <summary>The json status result.</summary>
	public class JsonStatusResult
	{
		/// <summary>Gets or sets a value indicating whether this <see cref="JsonStatusResult"/> is success.</summary>
		/// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
		public bool Success { get; set; }

		/// <summary>Gets or sets the message.</summary>
		/// <value>The message.</value>
		public string Message { get; set; }
	}
}