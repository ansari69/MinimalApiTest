using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Domain.Entities
{
    public class Category
    {
        public Category()
        {

        }

        public string CategoryId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public IList<Product> Products { get; set; }


    }
}
