using Microsoft.AspNetCore.Mvc;
using SistemaGestionAPI.ADO;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : Controller
    {
        [HttpDelete("Eliminar ProductoVendido")]
        public void EliminarProductoVendido(long idProducto)
        {
            ADO_ProductoVendido.EliminarProductoVendido(idProducto);

        }
    }
}
