namespace SistemaGestionAPI.Models
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string Descripciones { get; set; }
        public int Costo { get; set; }
        public int PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
    }
}
