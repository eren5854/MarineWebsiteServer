using AutoMapper;
using MarineWebsiteServer.WebAPI.DTOs;
using MarineWebsiteServer.WebAPI.DTOs.AboutDto;
using MarineWebsiteServer.WebAPI.DTOs.ContactDto;
using MarineWebsiteServer.WebAPI.DTOs.HomeDto;
using MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;
using MarineWebsiteServer.WebAPI.DTOs.InformationDto;
using MarineWebsiteServer.WebAPI.DTOs.LayoutDto;
using MarineWebsiteServer.WebAPI.DTOs.LinkDto;
using MarineWebsiteServer.WebAPI.DTOs.PortfolioDto;
using MarineWebsiteServer.WebAPI.Models;

namespace MarineWebsiteServer.WebAPI.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserDto, AppUser>();
        CreateMap<UpdateUserDto, AppUser>();

        CreateMap<CreateHomeDto, Home>();
        CreateMap<UpdateHomeDto, Home>();

        CreateMap<CreateHomeImageDto, HomeImage>();
        CreateMap<UpdateHomeImageDto, HomeImage>();

        CreateMap<CreateAboutDto, About>();
        CreateMap<UpdateAboutDto, About>();

        CreateMap<CreatePortfolioDto, Portfolio>();
        CreateMap<UpdatePortfolioDto, Portfolio>();

        CreateMap<CreateInformationDto, Information>();
        CreateMap<UpdateInformationDto, Information>();

        CreateMap<CreateLinkDto, Link>();
        CreateMap<UpdateLinkDto, Link>();

        CreateMap<CreateLayoutDto, Layout>();
        CreateMap<UpdateLayoutDto, Layout>();

        CreateMap<CreateContactDto, Contact>();

        CreateMap<CreateLinkDto, Link>();
        CreateMap<UpdateLinkDto, Link>();
    }
}
