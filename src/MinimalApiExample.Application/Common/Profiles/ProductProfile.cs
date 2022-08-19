using AutoMapper;
using MinimalApiExample.Application.Common.Models;
using MinimalApiExample.Application.Products.Commands.UpsertProduct;
using MinimalApiExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Common.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<UpsertProductCommand, Product>()
               .ForMember(a => a.ProductId, b => b.MapFrom(c => c.ProductId))
            .ForAllMembers(opt => opt.Condition((src, dist, srcMember) => srcMember != null && srcMember != ""));

            CreateMap<Product, ProductVM>();

        }
    }
}
