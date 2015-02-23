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
			List<ModelClientValidationRule> validations = null;// GetValidationRules<TModel, TProperty>(expression);
			IDictionary<string, string> validatorMessages = validations
				.ToDictionary(key => key.ValidationType.ToLower(), value => value.ErrorMessage);

			StringBuilder validationMessages = new StringBuilder();

			// TODO: needs form name to access field
			// TODO: build ng-messages validation string, allow for extra messages and ordering
			// types: pattern, email, date, size-> int, other types
			//	<span ng-message="{0}">{1}</span>

			foreach(var validationMessage in validatorMessages)
			{
				// TODO: probably going to need some transform here.
				validationMessages.Append(string.Format(
					"<span ng-message=\"{0}\">{1}</span>",
					validationMessage.Key,
					validationMessage.Value
				));
			}

			return new MvcHtmlString(validationMessages.ToString());
		}
	}
}