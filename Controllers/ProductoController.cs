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
        [HttpDelete("Eliminar producto")]
        public void EliminarProducto(long idProducto)
        {
            ADO_Producto.EliminarProducto(idProducto);

        }
        
    }
}
