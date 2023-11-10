using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using .Services

namespace .Controllers
{
[ApiController]
[Route ("[controller]/[action]")]
public class Rrhh_tipos_licenciasController : Controller
{
private IRrhh_tipos_licenciasService _Rrhh_tipos_licenciasService;
public Rrhh_tipos_licenciasController (IRrhh_tipos_licenciasService Rrhh_tipos_licenciasService) {
_Rrhh_tipos_licenciasService = Rrhh_tipos_licenciasService;
}
[HttpGet]
public IActionResult getByPk(
int id)
{
var Rrhh_tipos_licencias = _Rrhh_tipos_licenciasService.getByPk(id);
if (Rrhh_tipos_licencias == null)
{
return BadRequest(new { message = "Error al obtener los datos" });
}
return Ok(Rrhh_tipos_licencias);
}







}
}

