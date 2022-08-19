using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Products.Queries.GetSingleProduct
{
    public class GetSingleProductQueryValidator : AbstractValidator<GetSingleProductQuery>
    {
        public GetSingleProductQueryValidator()
        {
            RuleFor(e => e.ProductId)
              .NotNull().NotEmpty();
        }
    }
}
