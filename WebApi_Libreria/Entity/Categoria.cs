namespace WebApi_Libreria.Entity
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Nombre { get; set; } 
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
