using AutoMapper;
using MediatR;
using MinimalApiExample.Application.Common.Exceptions;
using MinimalApiExample.Application.Common.Interfaces;
using MinimalApiExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Products.Commands.UpsertProduct
{
    public class UpsertProductCommandHandler : IRequestHandler<UpsertProductCommand, string>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UpsertProductCommandHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpsertProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product();
           
            if (String.IsNullOrEmpty(request.ProductId))
            {               
                product.ProductId = Guid.NewGuid().ToString();
                product.CreateDate = DateTime.Now;
                product.IsActive = true;

                _context.Products.Add(product);
            }
            else
            {
                product = await _context.Products.FindAsync(request.ProductId);

                if (product == null)
                    throw new EntryValidationException();
            }

            product = _mapper.Map<UpsertProductCommand, Product>(request, product);

            await _context.SaveChangesAsync();

            return product.ProductId;
        }
    }
}
