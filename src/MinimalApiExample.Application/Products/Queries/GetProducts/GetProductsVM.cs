using MinimalApiExample.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Products.Queries.GetProducts
{
    public class GetProductsVM
    {
        public int PageId { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
        public IList<ProductVM> Products { get; set; }
    }
}
