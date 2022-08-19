using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Products.Commands.UpsertProduct
{
    public class UpsertProductCommand : IRequest<string>
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
