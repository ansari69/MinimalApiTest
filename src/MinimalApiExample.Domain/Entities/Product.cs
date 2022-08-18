using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Domain.Entities
{
    public class Product
    {
        public Product()
        {

        }

        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsActive { get; set; }

    }
}
