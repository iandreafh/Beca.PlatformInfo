using AutoMapper;

namespace PlatformInfo.API.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<Entities.Platform, Models.PlatformWithoutMoviesDto>();
            CreateMap<Entities.Platform, Models.PlatformDto>();
        }
    }
}
