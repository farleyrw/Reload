using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Reload.Common.Helpers;

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

		public static IDictionary<string, object> GetAttributesFromValidations<TModel, TProperty>(
			Expression<Func<TModel, TProperty>> expression)
		{
			List<ModelClientValidationRule> validations = NgHtmlHelpers.GetValidationRules<TModel, TProperty>(expression);
			var fun = GetNgValidations(validations, typeof(TProperty));

			return NgHtmlHelpers.TransformValidatorsToDirectives(fun);
		}

		/// <summary>Gets the angular validations.</summary>
		/// <param name="validations">The validations.</param>
		/// <param name="propertyType">Type of the property.</param>
		/// <returns>Returns a dictionary of the angular type keyed validation.</returns>
		public static IDictionary<NgValidatorType, ModelClientValidationRule> GetNgValidations(List<ModelClientValidationRule> validations, Type propertyType)
		{
			IDictionary<NgValidatorType, ModelClientValidationRule> result = new Dictionary<NgValidatorType, ModelClientValidationRule>();
			
			if (propertyType == typeof(int))
			{
				result.Add(NgValidatorType.Number, null);
			}

			if(propertyType == typeof(DateTime))
			{
				result.Add(NgValidatorType.Date, null);
			}
			
			validations.ForEach(validation =>
			{
				switch(validation.ValidationType.ToLower())
				{
					case "required":
						result.Add(NgValidatorType.Required, validation);
						break;
					case "email":
						result.Add(NgValidatorType.Email, validation);
						break;
					case "regex":
						result.Add(NgValidatorType.Pattern, validation);
						break;
					case "length":
						if(validation.ValidationParameters.ContainsKey("min"))
						{
							result.Add(NgValidatorType.Minlength, validation);
						}

						result.Add(NgValidatorType.Maxlength, validation);
						break;
					default:
						result.Add(NgValidatorType.Unknown, validation);
						break;
				}
			});

			return result;
		}

		/// <summary>Transforms the .Net validators to angular directives.</summary>
		/// <param name="validations">The validations.</param>
		/// <returns>A set of attributes representing angular directives.</returns>
		private static IDictionary<string, object> TransformValidatorsToDirectives(IDictionary<NgValidatorType, ModelClientValidationRule> validations)
		{
			IDictionary<string, object> attributes = new Dictionary<string, object>();

			foreach(var item in validations)
			{
				ModelClientValidationRule validation = item.Value;
				switch(item.Key)
				{
					// TOOD: email? other types?
					case NgValidatorType.Required:
						attributes.Add("required", null);
						break;
					case NgValidatorType.Pattern:
						attributes.Add("ng-pattern", validation.ValidationParameters["pattern"]);
						break;
					//case "range":
					case NgValidatorType.Maxlength:
						attributes.Add("ng-maxlength", validation.ValidationParameters["max"]);
						break;
					case NgValidatorType.Minlength:
						attributes.Add("ng-minlength", validation.ValidationParameters["min"]);
						break;
					default:
						//attributes.Add(validationType, System.Web.Helpers.Json.Encode(validation.ValidationParameters));
						break;
				}
			}

			return attributes;
		}
	}
}