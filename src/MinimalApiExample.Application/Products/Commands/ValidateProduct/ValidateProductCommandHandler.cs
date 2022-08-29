using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApiExample.Application.Common.Exceptions;
using MinimalApiExample.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Products.Commands.ValidateProduct
{
    public class ValidateProductCommandHandler : IRequestHandler<ValidateProductCommand, bool>
    {
        private readonly IAppDbContext _context;

        public ValidateProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ValidateProductCommand request, CancellationToken cancellationToken)
        {
            return await _context.Products
               .AnyAsync(f => f.ProductId == request.ProductId);
        }
    }
}
