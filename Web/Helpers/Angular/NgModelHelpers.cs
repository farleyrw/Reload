using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using EnumHelper = Reload.Common.Helpers.EnumHelper;

namespace Reload.Web.Helpers.Angular
{
	/// <summary>Angular html helpers that produce valid ng markup.</summary>
	public static class NgModelHelpers
	{
		/// <summary>Returns a text input element represented by the given expression with angular markup.</summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper.</param>
		/// <param name="expression">The expression.</param>
		/// <param name="htmlAttributes">The HTML attributes.</param>
		/// <returns>Html markup for the property with angular validations.</returns>
		public static MvcHtmlString NgTextBoxFor<TModel, TProperty>(
			this HtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, TProperty>> expression,
			object htmlAttributes = null)
		{
			IDictionary<string, object> ngAttributes = NgHtmlHelpers.GetAttributesFromValidations(expression);

			IDictionary<string, object> attributes = HtmlHelper.ObjectToDictionary(htmlAttributes ?? new { });

			// Merge generated ng attributes with those optionally provided.
			foreach(var item in ngAttributes)
			{
				attributes.Add(item);
			}

			// Set the input type for proper html5 validation if not already set.
			if(!attributes.ContainsKey("type"))
			{
				NgValidatorType modelHtmlType = GetModelHtmlType(expression);
				if(modelHtmlType != NgValidatorType.Unknown)
				{
					attributes.Add("type", modelHtmlType.ToString().ToLower());
				}
			}

			return htmlHelper.TextBoxFor(expression, attributes);
		}

		/// <summary>Gets the type of the model from the given expression.</summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="expression">The expression.</param>
		/// <returns>A strongly typed html input type.</returns>
		private static NgValidatorType GetModelHtmlType<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
		{
			List<NgValidatorType> htmlInputTypes = EnumHelper.CustomAttributes<NgValidatorType, NgHtmlInputTypeAttribute>();

			return NgHtmlHelpers.GetNgValidations(expression)
				.FirstOrDefault(a => htmlInputTypes.Contains(a.Key))
				.Key;
		}
	}
}