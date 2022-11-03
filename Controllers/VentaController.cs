using Microsoft.AspNetCore.Mvc;
using SistemaGestionAPI.ADO;
using SistemaGestionAPI.Models;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : Controller
    {
        [HttpPost("Cargar venta")]
        public void CargarVenta([FromBody] InsertarVenta venta)
            {
                ADO_Venta.CargarVenta(venta);
            }
    }

}
