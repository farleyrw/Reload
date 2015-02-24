using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Reload.Web.Helpers.Angular
{
	public static class NgValidationHelpers
	{
		public static MvcHtmlString NgValidationMessagesFor<TModel, TProperty>(
			this HtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, TProperty>> expression)
		{
			List<ModelClientValidationRule> validations = NgHtmlHelpers.GetValidationRules(expression);

			IDictionary<string, string> validationMessages = GetTransformedValidations(validations);

			StringBuilder validationMessageHtml = new StringBuilder();

			// TODO: build ng-message validation string, allow for extra messages and ordering
			// TODO: needs form name to access field if creating parent ng-messages
			//	<span ng-message="{0}">{1}</span>

			foreach(var validationMessage in validationMessages)
			{
				validationMessageHtml.Append(string.Format(
					"<span ng-message=\"{0}\">{1}</span>",
					validationMessage.Key.Replace("ng-", string.Empty),
					validationMessage.Value
				));
			}

			return new MvcHtmlString(validationMessageHtml.ToString());
		}

		private static IDictionary<string, string> GetTransformedValidations(List<ModelClientValidationRule> validations)
		{
			IDictionary<string, string> validationMessages = validations
				.ToDictionary(key => key.ValidationType.ToLower(), value => value.ErrorMessage);

			// TODO: transform to angular error key from enum

			return validationMessages;
		}
	}
}