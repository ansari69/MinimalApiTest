using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApiExample.Application.Common.Exceptions;
using MinimalApiExample.Application.Common.Interfaces;
using MinimalApiExample.Application.Common.Models;
using MinimalApiExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Products.Queries.GetSingleProduct
{
    public class GetSingleProductQueryHandler : IRequestHandler<GetSingleProductQuery, ProductVM>
    {

        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetSingleProductQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVM> Handle(GetSingleProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .SingleOrDefaultAsync(f => f.ProductId == request.ProductId);

            if (product == null)
                throw new EntryValidationException();

            var result = _mapper.Map<Product, ProductVM>(product);

            return result;
        }
    }
}
