using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using .Services

namespace .Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Rrhh_seteo_licenciasController : Controller
    {
        private IRrhh_seteo_licenciasService _Rrhh_seteo_licenciasService;
        public Rrhh_seteo_licenciasController(IRrhh_seteo_licenciasService Rrhh_seteo_licenciasService)
        {
            _Rrhh_seteo_licenciasService = Rrhh_seteo_licenciasService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int id)
        {
            var Rrhh_seteo_licencias = _Rrhh_seteo_licenciasService.getByPk(id);
            if (Rrhh_seteo_licencias == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Rrhh_seteo_licencias);
        }







    }
}

