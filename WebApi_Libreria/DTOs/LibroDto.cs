namespace WebApi_Libreria.DTOs
{
    public class LibroDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public decimal Precio { get; set; }
        public string? CategoriaNombre { get; set; }
        public string? ProveedorNombre { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class CrearLibroDto
    {
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public int CategoriaId { get; set; }
        public int ProveedorId { get; set; }
        public decimal Precio { get; set; }
    }

    public class ActualizarLibroDto
    {
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public int CategoriaId { get; set; }
        public int ProveedorId { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
    }
}