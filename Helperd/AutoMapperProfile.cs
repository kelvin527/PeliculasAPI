using AutoMapper;
using PeliculasAPI.DTOS;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Helperd
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Genero, GenerosDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Genero>();

        }
    }
}
