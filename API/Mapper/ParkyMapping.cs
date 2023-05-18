using AutoMapper;
using Packages;
using Packages.DTO;

namespace API.Mapper
{
    public class ParkyMapping : Profile
    {
        public ParkyMapping()
        {
            CreateMap<Items, ItemsDto>().ReverseMap();
        }
    }
}
