using WebApi_Libreria.DTOs;

namespace WebApi_Libreria.Services
{
    public interface ILibroService
    {
        Task<IEnumerable<LibroDto>> GetAllLibrosAsync();
        Task<LibroDto?> GetLibroByIdAsync(int id);
        Task<LibroDto> CreateLibroAsync(CrearLibroDto crearLibroDto);
        Task UpdateLibroAsync(int id, ActualizarLibroDto actualizarLibroDto);
        Task DeleteLibroAsync(int id);
    }
}