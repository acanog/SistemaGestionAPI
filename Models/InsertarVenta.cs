namespace SistemaGestionAPI.Models
{
    public class InsertarVenta
    {
        public Venta Venta { get; set; }
        public List<ProductoVendido> ProductosVendidos { get; set; }
    }
}
