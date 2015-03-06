using System.IO;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Reload.Web.Helpers.Json
{
	public class JsonNetResult : JsonResult
	{
		public JsonNetResult()
		{
			this.Settings = new JsonSerializerSettings();
		}

		public JsonSerializerSettings Settings { get; private set; }

		public override void ExecuteResult(ControllerContext context)
		{
			HttpResponseBase response = context.HttpContext.Response;
			response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;

			if(this.ContentEncoding != null)
			{
				response.ContentEncoding = this.ContentEncoding;
			}

			if(this.Data == null) { return; }

			JsonSerializer scriptSerializer = JsonSerializer.Create(this.Settings);

			using(StringWriter sw = new StringWriter())
			{
				scriptSerializer.Serialize(sw, this.Data);
				response.Write(sw.ToString());
			}
		}
	}
}