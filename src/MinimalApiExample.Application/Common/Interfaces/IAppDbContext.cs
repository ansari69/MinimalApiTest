using Microsoft.EntityFrameworkCore;
using MinimalApiExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
       DbSet<Product> Products { get; set; }



    }
}
