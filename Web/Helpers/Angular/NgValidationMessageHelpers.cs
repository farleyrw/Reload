﻿using System;
using System.Collections.Generic;
using System.Linq;
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

			// TODO: build ng-message validation string, allow for extra messages and ordering
			// TODO: needs form name to access field if creating parent ng-messages
			//	<span ng-message="{0}">{1}</span>

			foreach(var validationMessage in validationMessages)
			{
				validationMessageHtml.AppendLine(string.Format(
					"<span ng-message=\"{0}\">{1}</span>",
					validationMessage.Key.ToString().ToLower(),
					validationMessage.Value.ErrorMessage
				));
			}

			return new MvcHtmlString(validationMessageHtml.ToString());
		}

		private static IDictionary<NgValidatorType, ModelClientValidationRule> GetFilteredRules(
			this IDictionary<NgValidatorType, ModelClientValidationRule> validations)
		{
			// TODO: this was meant to restrict to only appropriate validation messages.

			// TODO: use custom attribute on the enum to get this list.
			NgValidatorType[] validMessageTypes = new NgValidatorType[]
			{
				NgValidatorType.Minlength,
				NgValidatorType.Maxlength,
				NgValidatorType.Email,
				NgValidatorType.Date,
				NgValidatorType.Number,
				NgValidatorType.Required,
				NgValidatorType.Pattern
			};

			return validations.Where(item => validMessageTypes.Contains(item.Key))
				.ToDictionary(item => item.Key, item => item.Value);
		}
	}
}