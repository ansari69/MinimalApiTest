using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Products.Commands.UpsertProduct
{
    public class UpsertProductCommandValidator : AbstractValidator<UpsertProductCommand>
    {
        public UpsertProductCommandValidator()
        {
            RuleFor(e => e.Name)
              .NotNull().NotEmpty();

            RuleFor(e => e.Description)
                 .NotNull().NotEmpty();
        }
    }
}
