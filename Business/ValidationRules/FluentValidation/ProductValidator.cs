using System;
using FluentValidation;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
	public class ProductValidator: AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(expression: p => p.ProductName).NotEmpty();
            RuleFor(expression: p => p.ProductName).Length(2, 30);
			RuleFor(p => p.UnitPrice).NotEmpty();
			RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1);
			RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
			RuleFor(p => p.ProductName).Must(StartWithA);
        }

		private bool StartWithA(string args)
		{
			Console.WriteLine("Checking if starts with A");
			bool startsWithA = args.StartsWith("A");
			Console.WriteLine("Check complete, starts with A value : " + startsWithA);
			return startsWithA;
		}

    }
}

