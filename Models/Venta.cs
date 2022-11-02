namespace SistemaGestionAPI.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string? Comentarios { get; set; }
        public int IdUsuario { get; set; }
        public ICollection<ProductoVendido>? productoVendido { get; set; }

    }
}
