using AutoMapper;
using Movies.Core.Dtos;
using Movies.Core.Entities;

namespace Movies.API.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDetails, MovieDetailsDto>();
           
        }
    }
}
