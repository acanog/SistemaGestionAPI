using Microsoft.AspNetCore.Mvc;

namespace SistemaGestionAPI.Controllers
{
    public class ConfigController : Controller
    {
        public string connectionstring { get; set; }
        public ConfigController(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }
    }
}
