using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

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
		public static IDictionary<string, object> GetAttributesFromValidations<TModel, TProperty>(
			Expression<Func<TModel, TProperty>> expression)
		{
			List<ModelClientValidationRule> validations = NgHtmlHelpers.GetValidationRules<TModel, TProperty>(expression);

			return NgHtmlHelpers.TransformValidatorsToDirectives(validations);
		}

		public static List<ModelClientValidationRule> GetValidationRules<TModel, TProperty>(
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
		public static IDictionary<string, object> TransformValidatorsToDirectives(List<ModelClientValidationRule> validations)
		{
			IDictionary<string, object> attributes = new Dictionary<string, object>();

			validations.ForEach(validation =>
			{
				string validationType = validation.ValidationType.ToLower();

				// TODO: add enums instead of strings, move attribute conversion into different method
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
					//case "range":
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
	}
}