using AutoMapper;

namespace PlatformInfo.API.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Entities.Movie, Models.MovieDto>();
            CreateMap<Models.MovieForCreationDto, Entities.Movie>();
            CreateMap<Models.MovieForUpdateDto, Entities.Movie>();
            CreateMap<Entities.Movie, Models.MovieForUpdateDto>();
        }
    }
}
