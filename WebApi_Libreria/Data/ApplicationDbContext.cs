using Microsoft.EntityFrameworkCore;
using WebApi_Libreria.Entity;

namespace WebApi_Libreria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Libro y Categoria, Que miras bobo?
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Categoria)
                .WithMany()
                .HasForeignKey(l => l.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Libro y Proveedor XD
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Proveedor)
                .WithMany()
                .HasForeignKey(l => l.ProveedorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Precisión para Precio (decimal) wasaaaa
            modelBuilder.Entity<Libro>()
                .Property(l => l.Precio)
                .HasPrecision(18, 2);
        }
    }
}