using AutoMapper;
using WebApi_Libreria.DTOs;
using WebApi_Libreria.Entity;

namespace WebApi_Libreria.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Libro mappings
            CreateMap<Libro, LibroDto>()
                .ForMember(dest => dest.CategoriaNombre,
                    opt => opt.MapFrom(src => src.Categoria != null ? src.Categoria.Nombre : null))
                .ForMember(dest => dest.ProveedorNombre,
                    opt => opt.MapFrom(src => src.Proveedor != null ? src.Proveedor.Nombre : null));

            CreateMap<CrearLibroDto, Libro>();
            CreateMap<ActualizarLibroDto, Libro>();
        }
    }
}