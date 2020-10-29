using AutoMapper;
using BLL.DTOs.Movie;
using DAL.Entities;

namespace BLL.Mappings
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Movie, MovieDTO>()
                .ForMember(dest =>
                    dest.Director,
                    opt => opt.MapFrom(src => $"{src.Director.FirstName} {src.Director.Lastname}"));

            CreateMap<CreatemovieDTO, Movie>();
            CreateMap<Movie, EditMovieDTO>();
            CreateMap<EditMovieDTO, Movie>();
        }
    }
}
