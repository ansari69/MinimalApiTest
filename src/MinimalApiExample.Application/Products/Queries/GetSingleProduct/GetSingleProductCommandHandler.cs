using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetSingleProductCommandHandler : IRequestHandler<GetSingleProductCommand, ProductVM>
    {

        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetSingleProductCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVM> Handle(GetSingleProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .SingleOrDefaultAsync(f => f.ProductId == request.ProductId);

            var result = _mapper.Map<Product, ProductVM>(product);

            return result;
        }
    }
}
