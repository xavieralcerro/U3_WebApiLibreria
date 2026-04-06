using WebApi_Libreria.Entity;

namespace WebApi_Libreria.Repositories
{
    public interface ILibroRepository : IGenericRepository<Libro>
    {
        Task<IEnumerable<Libro>> GetLibrosConCategoriaYProveedorAsync();
    }
}