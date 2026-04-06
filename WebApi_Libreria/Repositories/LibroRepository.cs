using Microsoft.EntityFrameworkCore;
using WebApi_Libreria.Data;
using WebApi_Libreria.Entity;

namespace WebApi_Libreria.Repositories
{
    public class LibroRepository : GenericRepository<Libro>, ILibroRepository
    {
        public LibroRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Libro>> GetLibrosConCategoriaYProveedorAsync()
        {
            return await _context.Libros
                .Include(l => l.Categoria)
                .Include(l => l.Proveedor)
                .ToListAsync();
        }
    }
}