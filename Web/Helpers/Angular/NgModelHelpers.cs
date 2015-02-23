using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Reload.Web.Helpers.Angular
{
	public static class NgModelHelpers
	{
		public static MvcHtmlString NgModelFor<TModel, TProperty>(
			this HtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, TProperty>> expression,
			object htmlAttributes = null)
		{
			IDictionary<string, object> ngAttributes = NgHtmlHelpers.GetAttributesFromValidations(expression);

			IDictionary<string, object> attributes = HtmlHelper.ObjectToDictionary(htmlAttributes ?? new { });

			// TODO: merge generated attributes with those optionally provided.
			foreach(var item in ngAttributes)
			{
				attributes.Add(item);
			}

			return htmlHelper.EditorFor(expression, attributes);
		}
	}
}