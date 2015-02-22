using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Reload.Web.Helpers.Angular
{
	/*	The idea is to generate angular directives (html attributes) based on data annotations on the model.
	 *	
	 *	These are to be inserted in a raw html string like:
	 *	<input ng-model="property" @Html.NgDirectivesFor(model => model.Property) />
	 *	Producing:
	 *	<input ng-model="property" ng-*="" />
	 *	
	 *	Or as a full input model creator:
	 *	@Html.NgModelFor(model => model.Property [, string:name|id] [, object:htmlAttributes])
	 *	Resulting in similar functionality from native Html model helpers producing:
	 *	<input ng-model="name" name="name" id="name" type="typeof(property)" ng-*="*" />
	 */
	public static class NgHtmlHelpers
	{
		public static MvcHtmlString NgDirectivesFor<TModel, TProperty>(
			this HtmlHelper<TModel> htmlHelper, 
			Expression<Func<TModel, TProperty>> expression)
		{
			List<ModelClientValidationRule> validations = GetValidationRules<TModel, TProperty>(expression);

			IDictionary<string, string> ngAttributes = TransformValidatorsToDirectives(validations);

			string html = AttributesToHtmlString(ngAttributes);

			return new MvcHtmlString(html);
		}

		public static MvcHtmlString NgValidationMessagesFor<TModel, TProperty>(
			this HtmlHelper<TModel> htmlHelper, 
			Expression<Func<TModel, TProperty>> expression)
		{
			List<ModelClientValidationRule> validations = GetValidationRules<TModel, TProperty>(expression);
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
				validationMessages.Append(string.Format("<span ng-message=\"{0}\">{1}</span>", validationMessage.Key, validationMessage.Value));
			}

			return new MvcHtmlString(validationMessages.ToString());
		}

		private static List<ModelClientValidationRule> GetValidationRules<TModel, TProperty>(
			Expression<Func<TModel, TProperty>> expression)
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

		/// <summary>Transforms the .Net validators to angular directives.</summary>
		/// <param name="validations">The validations.</param>
		/// <returns>A set of attributes representing angular directives.</returns>
		private static IDictionary<string, string> TransformValidatorsToDirectives(List<ModelClientValidationRule> validations)
		{
			IDictionary<string, string> attributes = new Dictionary<string, string>();

			validations.ForEach(validation =>
			{
				string validationType = validation.ValidationType.ToLower();

				switch(validationType)
				{
					// TOOD: email? other types?
					case "required":
						attributes.Add(validationType, null);
						break;
					case "regex":
						string patternValue = validation.ValidationParameters["pattern"].ToString();

						attributes.Add("ng-pattern", patternValue);
						break;
					case "range":
					case "length":
						if(validation.ValidationParameters.ContainsKey("min"))
						{
							attributes.Add("ng-minlength", validation.ValidationParameters["min"].ToString());
						}

						if(validation.ValidationParameters.ContainsKey("max"))
						{
							attributes.Add("ng-maxlength", validation.ValidationParameters["max"].ToString());
						}
						break;
					default:
						attributes.Add(validationType, System.Web.Helpers.Json.Encode(validation.ValidationParameters));
						break;
				}
			});

			return attributes;
		}

		private static string AttributesToHtmlString(IDictionary<string, string> attributes)
		{
			StringBuilder result = new StringBuilder();

			foreach(var attribute in attributes)
			{
				result.Append(attribute.Key);

				if(!string.IsNullOrWhiteSpace(attribute.Value))
				{
					result.Append(string.Format("=\"{0}\"", attribute.Value));
				}
			}

			return String.Join(" ", result.ToString());
		}
	}
}