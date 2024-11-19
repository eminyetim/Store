using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.Infrastructe.Mapper.MappingProfile.cs
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<ProductDtoForInsertion , Product>();
            CreateMap<ProductDtoForUpdate , Product>().ReverseMap(); // iki yönlü mapleme.
        }
    }
}