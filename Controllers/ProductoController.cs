using Microsoft.AspNetCore.Mvc;
using SistemaGestionAPI.ADO;
using SistemaGestionAPI.Models;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        [HttpPost]
        public void Crear([FromBody]Producto producto)
        {
            ADO_Producto.CrearProducto(producto);
            
        }

        [HttpPut]
        public void Actualizar([FromBody] Producto producto)
        {
            ADO_Producto.ActualizarProducto(producto);

        }
        [HttpDelete]
        public void Delete([FromBody] Producto producto)
        {
            ADO_Producto.EliminarProducto(producto);

        }
    }
}
