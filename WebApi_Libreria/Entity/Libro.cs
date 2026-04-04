namespace WebApi_Libreria.Entity
{
    public class Libro
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public int CategoriaId { get; set; }
        public int ProveedorId { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        // Relaciones, también lo investigué
        public Categoria? Categoria { get; set; }
        public Proveedor? Proveedor { get; set; }
    }
}
