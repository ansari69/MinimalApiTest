using MediatR;
using MinimalApiExample.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Products.Queries.GetSingleProduct
{
    public class GetSingleProductQuery : IRequest<ProductVM>
    {
        public string ProductId { get; set; }

    }
}
