using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Reload.Web.Helpers.Angular
{
	/// <summary>Angular directive model validation helpers.</summary>
	public static class NgModelValidationHelpers
	{
		/// <summary>Generates a list of validation attributes as angular directives.</summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper.</param>
		/// <param name="expression">The expression.</param>
		/// <returns>A string of html representing the angular directives for the property validators.</returns>
		public static MvcHtmlString NgValidationAttributesFor<TModel, TProperty>(
			this HtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, TProperty>> expression)
		{
			IDictionary<string, object> ngAttributes = NgHtmlHelpers.GetAttributesFromValidations(expression);

			string html = AttributesToHtmlString(ngAttributes);

			return new MvcHtmlString(html);
		}

		private static string AttributesToHtmlString(IDictionary<string, object> attributes)
		{
			StringBuilder result = new StringBuilder();

			foreach(var attribute in attributes)
			{
				result.Append(attribute.Key);

				if(!string.IsNullOrWhiteSpace(attribute.Value as string))
				{
					result.Append(string.Format("=\"{0}\"", attribute.Value));
				}
			}

			return String.Join(" ", result.ToString());
		}
	}
}