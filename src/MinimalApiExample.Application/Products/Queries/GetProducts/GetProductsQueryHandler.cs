using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApiExample.Application.Common.Exceptions;
using MinimalApiExample.Application.Common.Helpers;
using MinimalApiExample.Application.Common.Interfaces;
using MinimalApiExample.Application.Common.Models;
using MinimalApiExample.Domain.Entities;

namespace MinimalApiExample.Application.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetProductsVM> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Product> products = _context.Products;
            
            if (!String.IsNullOrEmpty(request.SearchValue))
                products = products.Where(c => c.Name.ToString().Contains(request.SearchValue)
                    || c.Description.Contains(request.SearchValue));
                    

            if (!String.IsNullOrEmpty(request.SortBy))
            {
                try
                {
                    products = products.FilterOrderBy(request.SortBy, request.SortByDescending);
                }
                catch
                {
                    throw new OperationFailedException();
                }
            }

            //get total pages
            var totalPage = products.TotalPagesCount(request.EachPerPage);
            var totalResult = products.Count();

            //Fail if no result found
            if (totalPage == 0)
                return new GetProductsVM()
                {
                    TotalPages = totalPage,
                    PageId = request.PageId,
                    TotalResults = totalResult,
                    Products = new List<ProductVM>()
                };

            if (request.PageId > totalPage) 
                request.PageId = totalPage;

            //paging
            var productResult = await
                products.ToPaginatedQuery(request.PageId, request.EachPerPage).ToListAsync();

            // Mapping
            var result = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductVM>>(productResult);

            //Creating result
            return new GetProductsVM()
            {
                TotalPages = totalPage,
                PageId = request.PageId,
                TotalResults = totalResult,
                Products = result.ToList()
            };
        }
    }
}
