using Microsoft.AspNetCore.Mvc;
using SistemaGestionAPI.ADO;
using SistemaGestionAPI.Models;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : Controller
    {
        [HttpPost]
        public static void CargarVenta([FromBody] Venta venta)
            {
                ADO_Venta.CargarVenta(venta);
            }
    }

}
