using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace ReloadingApp.Helpers.Mvc
{
	/// <summary>The maxlength text box helper class.</summary>
	public static class MaxLengthTextBox
	{
		/// <summary>Customs the text box for.</summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper.</param>
		/// <param name="expression">The expression.</param>
		/// <param name="htmlAttributes">The HTML attributes.</param>
		public static MvcHtmlString MaxLengthTextBoxFor<TModel, TProperty>(
			this HtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, TProperty>> expression,
			object htmlAttributes = null)
		{
			MemberExpression member = expression.Body as MemberExpression;
			StringLengthAttribute stringLength = member.Member.GetCustomAttribute<StringLengthAttribute>(false);

			IDictionary<string, object> attributes = (IDictionary<string, object>) new RouteValueDictionary(htmlAttributes ?? new { });
			if(stringLength != null)
			{
				attributes.Add("maxlength", stringLength.MaximumLength);
			}

			return htmlHelper.TextBoxFor(expression, attributes);
		}
	}
}