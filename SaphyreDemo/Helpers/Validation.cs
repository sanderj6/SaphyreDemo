using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using SaphyreDemo.Data.Models;

namespace SaphyreDemo.Helpers
{
	//public class OrderDescriptionValidator : AbstractValidator<OrderDescription>
	//{
	//	public OrderDescriptionValidator() 
	//	{
	//		RuleFor(x => x.Description).NotEmpty();
	//		RuleFor(x => x.Amount).GreaterThan(0);
	//		RuleFor(x => x.TaxPercentage).GreaterThan(0);
	//		RuleFor(x => x.Products).Must(list => list != null && list.Count() > 0).WithMessage("The list must contain at least one object.");
	//		//RuleFor(x => x.YourGuidProperty).NotEmpty().WithMessage("GUID must not be empty.");
	//		//RuleFor(x => x.ComplexProperty).SetValidator(new ComplexTypeValidator());
	//		RuleFor(x => x.Date).Must(date => date > DateTime.MinValue).WithMessage("Date must not be minimum date.");
	//	}
	//}

	public class FluentValueValidator<T> : AbstractValidator<T>
	{
		public FluentValueValidator(Action<IRuleBuilderInitial<T, T>> rule)
		{
			rule(RuleFor(x => x));
		}

		private IEnumerable<string> ValidateValue(T arg)
		{
			if (arg == null)
			{
				return new List<string> { "Invalid input" };
			}

			var result = Validate(arg);
			if (result.IsValid)
				return new string[0];
			return result.Errors.Select(e => e.ErrorMessage);
		}

		public Func<T, IEnumerable<string>> Validation => ValidateValue;
	}

	public class CustomDateValidation : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			DateTime? inputDate = value as DateTime?;

			if (!inputDate.HasValue)
			{
				return new ValidationResult("Date is required.");
			}

			if (inputDate.Value.Date > DateTime.UtcNow.Date)
			{
				return new ValidationResult("Date cannot be in the future.");
			}

			return ValidationResult.Success;
		}
	}

	public class EnsureOneElementAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var list = value as IList;
			if (list != null && list.Count > 0)
				return ValidationResult.Success;
			else
				return new ValidationResult("The list must contain at least one element.");
		}
	}


}
