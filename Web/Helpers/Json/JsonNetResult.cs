using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Reload.Web.Helpers.Json
{
	/// <summary>The JsonNet json result.</summary>
	/// <remarks>This is faster than the standard Json result and supports proper dictionary output.</remarks>
	public class JsonNetResult : JsonResult
	{
		/// <summary>Initializes a new instance of the <see cref="JsonNetResult"/> class.</summary>
		public JsonNetResult()
		{
			this.Settings = new JsonSerializerSettings();
		}

		/// <summary>Initializes a new instance of the <see cref="JsonNetResult"/> class.</summary>
		/// <param name="data">The data.</param>
		public JsonNetResult(object data) : this()
		{
			this.Data = data;
		}

		/// <summary>Gets the settings.</summary>
		/// <value>The settings.</value>
		public JsonSerializerSettings Settings { get; private set; }

		/// <summary>Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.</summary>
		/// <param name="context">The context within which the result is executed.</param>
		public override void ExecuteResult(ControllerContext context)
		{
			HttpResponseBase response = context.HttpContext.Response;
			response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;

			if(this.ContentEncoding != null)
			{
				response.ContentEncoding = this.ContentEncoding;
			}

			if(this.Data == null) { return; }

			using(JsonTextWriter writer = new JsonTextWriter(response.Output))
			{
				JsonSerializer serializer = JsonSerializer.Create(this.Settings);
				serializer.Serialize(writer, this.Data);
				writer.Flush();
			}
		}
	}
}