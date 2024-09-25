using AutoMapper;
using MarineWebsiteServer.WebAPI.DTOs.HomeDto;
using MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;
using MarineWebsiteServer.WebAPI.Models;

namespace MarineWebsiteServer.WebAPI.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateHomeDto, Home>();
        CreateMap<UpdateHomeDto, Home>();

        CreateMap<CreateHomeImageDto, HomeImage>();
        CreateMap<UpdateHomeImageDto, HomeImage>();
    }
}
