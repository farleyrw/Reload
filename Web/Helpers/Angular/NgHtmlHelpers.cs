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
	/// <summary>Angular html helpers that produce valid ng markup.</summary>
	public static class NgHtmlHelpers
	{
		/// <summary>Gets the angular attributes from the .net validations from the given expression.</summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="expression">The expression.</param>
		/// <returns>A dictionary of the html attribute validations.</returns>
		public static IDictionary<string, object> GetAttributesFromValidations<TModel, TProperty>(
			Expression<Func<TModel, TProperty>> expression)
		{
			IDictionary<NgValidatorType, ModelClientValidationRule> ngValidations = GetNgValidations(expression);

			return TransformValidatorsToDirectives(ngValidations);
		}

		/// <summary>Gets the angular validations.</summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="expression">The expression.</param>
		/// <param name="propertyType">Type of the property.</param>
		/// <returns>A dictionary of the angular type keyed validations.</returns>
		public static IDictionary<NgValidatorType, ModelClientValidationRule> GetNgValidations<TModel, TProperty>(
			Expression<Func<TModel, TProperty>> expression)
		{
			IDictionary<NgValidatorType, ModelClientValidationRule> result = new Dictionary<NgValidatorType, ModelClientValidationRule>();
			
			Type propertyType = typeof(TProperty);

			if(propertyType == typeof(int))
			{
				result.Add(NgValidatorType.Number, null);
			}

			// TODO: Should this function off the DataType attribute instead of the .net type?
			if(propertyType == typeof(DateTime))
			{
				result.Add(NgValidatorType.Date, null);
			}

			List<ModelClientValidationRule> validations = GetValidationRules<TModel, TProperty>(expression);

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
					case "range":
						result.Add(NgValidatorType.Min, validation);
						result.Add(NgValidatorType.Max, validation);
						break;
					default:
						result.Add(NgValidatorType.Unknown, validation);
						break;
				}
			});

			return result;
		}

		/// <summary>Gets the .net validation rules.</summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="expression">The expression.</param>
		/// <returns>A list of validation rules for the given expression.</returns>
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
		private static IDictionary<string, object> TransformValidatorsToDirectives(IDictionary<NgValidatorType, ModelClientValidationRule> validations)
		{
			IDictionary<string, object> attributes = new Dictionary<string, object>();

			foreach(var item in validations)
			{
				ModelClientValidationRule validation = item.Value;

				switch(item.Key)
				{
					case NgValidatorType.Required:
						attributes.Add("required", null);
						break;
					case NgValidatorType.Pattern:
						attributes.Add("ng-pattern", validation.ValidationParameters["pattern"]);
						break;
					case NgValidatorType.Minlength:
						attributes.Add("ng-minlength", validation.ValidationParameters["min"]);
						break;
					case NgValidatorType.Maxlength:
						attributes.Add("ng-maxlength", validation.ValidationParameters["max"]);
						break;
					case NgValidatorType.Min:
						attributes.Add("min", validation.ValidationParameters["min"]);
						break;
					case NgValidatorType.Max:
						attributes.Add("max", validation.ValidationParameters["max"]);
						break;
				}
			}

			return attributes;
		}
	}
}