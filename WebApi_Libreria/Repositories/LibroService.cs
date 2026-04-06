using AutoMapper;
using WebApi_Libreria.DTOs;
using WebApi_Libreria.Entity;
using WebApi_Libreria.Repositories;

namespace WebApi_Libreria.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IMapper _mapper;

        public LibroService(ILibroRepository libroRepository, IMapper mapper)
        {
            _libroRepository = libroRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LibroDto>> GetAllLibrosAsync()
        {
            var libros = await _libroRepository.GetLibrosConCategoriaYProveedorAsync();
            return _mapper.Map<IEnumerable<LibroDto>>(libros);
        }

        public async Task<LibroDto?> GetLibroByIdAsync(int id)
        {
            var libro = await _libroRepository.GetByIdAsync(id);
            return libro != null ? _mapper.Map<LibroDto>(libro) : null;
        }

        public async Task<LibroDto> CreateLibroAsync(CrearLibroDto crearLibroDto)
        {
            var libro = _mapper.Map<Libro>(crearLibroDto);
            libro.Activo = true;
            libro.FechaCreacion = DateTime.Now;

            await _libroRepository.AddAsync(libro);
            await _libroRepository.SaveChangesAsync();

            return _mapper.Map<LibroDto>(libro);
        }

        public async Task UpdateLibroAsync(int id, ActualizarLibroDto actualizarLibroDto)
        {
            var libro = await _libroRepository.GetByIdAsync(id);
            if (libro == null)
                throw new Exception("Libro no encontrado");

            _mapper.Map(actualizarLibroDto, libro);
            _libroRepository.Update(libro);
            await _libroRepository.SaveChangesAsync();
        }

        public async Task DeleteLibroAsync(int id)
        {
            var libro = await _libroRepository.GetByIdAsync(id);
            if (libro == null)
                throw new Exception("Libro no encontrado");

            libro.Activo = false; // Baja lógica
            _libroRepository.Update(libro);
            await _libroRepository.SaveChangesAsync();
        }
    }
}