using MediatR;
using MinimalApiExample.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<GetProductsVM>
    {
        public int PageId { get; set; } = 1;
        public int EachPerPage { get; set; } = 20;
        public string SearchValue { get; set; } = "";
        public string SortBy { get; set; } = "";
        public bool SortByDescending { get; set; } = false;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ExactDate { get; set; }
    }
}
