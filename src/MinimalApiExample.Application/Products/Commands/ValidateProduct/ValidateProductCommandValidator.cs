using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Products.Commands.ValidateProduct
{
    public class ValidateProductCommandValidator : AbstractValidator<ValidateProductCommand>
    {
        public ValidateProductCommandValidator()
        {
            RuleFor(e => e.ProductId)
              .NotNull().NotEmpty();
        }
    }
}
