using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace Reload.Web.Helpers.Angular
{
	/*	The idea is to generate angular directives (html attributes) based on data annotations on the model.
	 *	These are to be appended as an attribute dictionary
	 */
	public static class NgHtmlHelpers
	{
        public static MvcHtmlString NgDirectivesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
			return NgDirectivesFor(htmlHelper, expression, null /* validationMessage */, new RouteValueDictionary());
        }

		public static MvcHtmlString NgDirectivesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string validationMessage)
        {
			return NgDirectivesFor(htmlHelper, expression, validationMessage, new RouteValueDictionary());
        }

		public static MvcHtmlString NgDirectivesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string validationMessage, object htmlAttributes)
        {
			return NgDirectivesFor(htmlHelper, expression, validationMessage, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

		public static MvcHtmlString NgDirectivesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string validationMessage, IDictionary<string, object> htmlAttributes)
        {
			List<ModelClientValidationRule> validations = GetValidationRules<TModel, TProperty>(expression);

            string result = GetNgValidatorDirectives(validations);

            return new MvcHtmlString(result);
        }

		public static MvcHtmlString NgValidationMessagesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string validationMessage, IDictionary<string, object> htmlAttributes)
		{
			List<ModelClientValidationRule> validations = GetValidationRules<TModel, TProperty>(expression);
			IDictionary<string, string> validatorMessages = validations.ToDictionary(k => k.ValidationType, v => v.ErrorMessage);

			// TODO: build ng-messages string, allow for extra messages and ordering
			//	<span ng-message="{0}">{1}</span>

			return new MvcHtmlString(string.Empty);
		}

		private static List<ModelClientValidationRule> GetValidationRules<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
		{
			ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<TModel>());
			string name = ExpressionHelper.GetExpressionText(expression);
			List<ModelClientValidationRule> validations = ModelValidatorProviders.Providers.GetValidators(
					metadata ?? ModelMetadata.FromStringExpression(name, new ViewDataDictionary()),
					new ControllerContext())
				.SelectMany(v => v.GetClientValidationRules())
				.ToList();

			return validations;
		}

        private static string GetNgValidatorDirectives(List<ModelClientValidationRule> validations)
        {
            var result = "";

			validations.ForEach(validation =>
			{
				result += " " + ConvertValidatorToNgValidator(validation);
			});

            return result;
        }

        private static string ConvertValidatorToNgValidator(ModelClientValidationRule val)
        {
			// TODO: pattern, email, date, size
            switch (val.ValidationType.ToLower())
            {
                case "required":
                    return "required";
                case "range":
					string minValue = val.ValidationParameters["min"].ToString();
					string maxValue = val.ValidationParameters["max"].ToString();

                    return string.Format("ng-minlength=\"{0}\" ng-maxlength=\"{1}\"", minValue, maxValue);
                case "regex":
					string patternValue = val.ValidationParameters["pattern"].ToString();

                    return string.Format("ng-pattern=\"{0}\"", patternValue);
                case "length":
                    string result = "";

					if(val.ValidationParameters.ContainsKey("min"))
					{
						result += string.Format("ng-minlength=\"{0}\" ", val.ValidationParameters["min"]);
					}

					if(val.ValidationParameters.ContainsKey("max"))
					{
						result += string.Format("ng-maxlength=\"{0}\"", val.ValidationParameters["max"]);
					}

                    return result.TrimEnd();
                default:
					return string.Format("{0}=\"{1}\"", val.ValidationType, System.Web.Helpers.Json.Encode(val.ValidationParameters));
            }
        }
	}
}