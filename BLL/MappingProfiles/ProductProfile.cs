using AutoMapper;
using BLL.Dtos;
using DAL.Entities;

namespace BLL.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<CreateProductDto, Product>(MemberList.Source);
            CreateMap<UpdateProductDto, Product>(MemberList.Source);
            CreateMap<PatchProductDto, Product>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
