using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Products.Commands.ValidateProduct
{
    public class ValidateProductCommand : IRequest<bool>
    {
        public string ProductId { get; set; }

    }
}
