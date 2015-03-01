using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Reload.Web.Helpers.Angular
{
	/// <summary>The angular validation message helpers.</summary>
	public static class NgValidationMessageHelpers
	{
		/// <summary>Gets the angular validation messages from the given expression.</summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper.</param>
		/// <param name="expression">The expression.</param>
		/// <returns>The html of the validation messages from the given expression.</returns>
		public static MvcHtmlString NgValidationMessagesFor<TModel, TProperty>(
			this HtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, TProperty>> expression)
		{
			IDictionary<NgValidatorType, ModelClientValidationRule> validationMessages = NgHtmlHelpers.GetNgValidations(expression);

			StringBuilder validationMessageHtml = new StringBuilder();

			foreach(var validationMessage in validationMessages)
			{
				validationMessageHtml.AppendLine(string.Format(
					"<div ng-message=\"{0}\">{1}</div>",
					validationMessage.Key.ToString().ToLower(),
					validationMessage.Value.ErrorMessage
				));
			}

			return new MvcHtmlString(validationMessageHtml.ToString());
		}
	}
}