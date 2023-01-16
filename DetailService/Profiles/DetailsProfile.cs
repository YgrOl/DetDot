using AutoMapper;
using DetailService.Dtos;
using DetailService.Models;

namespace DetailService.Profiles
{
    public class DetailsProfile : Profile
    {
        public DetailsProfile()
        {
            //Source -> Target
            CreateMap<Detail, DetailReadDto>();
            CreateMap<DetailCreateDto, Detail>();
        }
    }
}