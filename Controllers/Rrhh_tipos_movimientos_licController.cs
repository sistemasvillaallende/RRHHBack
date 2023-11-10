using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using .Services

namespace .Controllers
{
[ApiController]
[Route ("[controller]/[action]")]
public class Rrhh_tipos_movimientos_licController : Controller
{
private IRrhh_tipos_movimientos_licService _Rrhh_tipos_movimientos_licService;
public Rrhh_tipos_movimientos_licController (IRrhh_tipos_movimientos_licService Rrhh_tipos_movimientos_licService) {
_Rrhh_tipos_movimientos_licService = Rrhh_tipos_movimientos_licService;
}
[HttpGet]
public IActionResult getByPk(
)
{
var Rrhh_tipos_movimientos_lic = _Rrhh_tipos_movimientos_licService.getByPk();
if (Rrhh_tipos_movimientos_lic == null)
{
return BadRequest(new { message = "Error al obtener los datos" });
}
return Ok(Rrhh_tipos_movimientos_lic);
}







}
}

