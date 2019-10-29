using AutoMapper;
using BandQ.Commons.Services.Models;
using ProductsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWeb
{
    public class BandQProfile : Profile
    {
        public BandQProfile()
        {
            CreateMap<ProductModel, ProductsViewModel>();
            CreateMap<ProductsViewModel, ProductModel>();
            CreateMap<List<ProductsViewModel>, List<ProductModel>>();
            CreateMap<CreateProductViewModel, ProductModel>();
            CreateMap<UpdateProductViewModel, ProductModel>();
            CreateMap<ProductModel, UpdateProductViewModel > ();
            CreateMap<ProductModel, CreateProductViewModel> ();


        }

    }
}
