using AutoMapper;
using ProvidersService.Dtos;
using ProvidersService.Models;


namespace ProvidersService.Profiles
{
    public class ProvidersProfile : Profile
    {
        public ProvidersProfile()
        {
            // Source -> Target
            CreateMap<Detail, DetailreadDto>();
            CreateMap<ProviderCreateDto, Provider>();
            CreateMap<Provider, ProviderReadDto>();
        
        }
    }
}