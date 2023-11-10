using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using RRHHBack.Services;
using RRHHBack.Entities.RRHH;
using RRHHBack.Library;

namespace RRHHBack.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RRHH_Solicitud_licenciaController : Controller
    {
        private IRRHH_Solicitud_licenciaService _RRHH_Solicitud_licenciaService;
        public RRHH_Solicitud_licenciaController(IRRHH_Solicitud_licenciaService RRHH_Solicitud_licenciaService)
        {
            _RRHH_Solicitud_licenciaService = RRHH_Solicitud_licenciaService;
        }
        [HttpGet]
        public IActionResult getByPk()
        {
            var RRHH_Solicitud_licencia = _RRHH_Solicitud_licenciaService.getByPk();
            if (RRHH_Solicitud_licencia == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(RRHH_Solicitud_licencia);
        }

        [HttpGet]
        public IActionResult Tipos_licencia()
        {
            var tipos = _RRHH_Solicitud_licenciaService.Tipos_licencias();
            if (tipos.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron Datos!!!" });
            }
            return Ok(tipos);
        }
        [HttpGet]
        public ActionResult<PaginadorGenerico<RRHH_Solicitud_licencia>> Solicitudes_paginado(string buscarPor = "", string strParametro = "",
            int activo = 1, int pagina = 0, int registros_por_pagina = 10)
        {
            List<RRHH_Solicitud_licencia> _Solicitudes;
            PaginadorGenerico<RRHH_Solicitud_licencia> _PaginadorSolicitudes;
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;
            _TotalRegistros = _RRHH_Solicitud_licenciaService.Count(buscarPor, strParametro);
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);
            if (!string.IsNullOrEmpty(buscarPor) && buscarPor != "0" && strParametro != "0")
            {
                _Solicitudes = _RRHH_Solicitud_licenciaService.Solicitudes_paginado(buscarPor, strParametro, 0, _TotalRegistros);
            }
            else
                _Solicitudes = _RRHH_Solicitud_licenciaService.Solicitudes_paginado(buscarPor, strParametro, (pagina * registros_por_pagina) - registros_por_pagina + 1,
                                                                            pagina * registros_por_pagina);
            //Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _PaginadorSolicitudes = new PaginadorGenerico<RRHH_Solicitud_licencia>()
            {
                RegistrosPorPagina = registros_por_pagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                BusquedaPor = buscarPor,
                Parametro = strParametro,
                //OrdenActual = orden,
                //TipoOrdenActual = tipo_orden,
                Resultado = _Solicitudes
            };
            if (_PaginadorSolicitudes == null)
            {
                return BadRequest(new { message = "No se encontraron los datos..." });
            }
            return _PaginadorSolicitudes;
        }


        [HttpGet]
        public ActionResult GetAprobadoresAll()
        {
            var aprobadores = _RRHH_Solicitud_licenciaService.GetAprobadoresAll();
            if (aprobadores.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron Aprobadores!!!" });
            }
            return Ok(aprobadores);
        }
        [HttpGet]
        public ActionResult GetAprobadorByLegajo(int id_aprobador)
        {
            var aprobador = _RRHH_Solicitud_licenciaService.GetAprobadorByLegajo(id_aprobador);
            if (aprobador.legajo == 0)
            {
                return BadRequest(new { message = "No se encontro Aprobador!!!" });
            }
            return Ok(aprobador);

        }
        [HttpGet]
        public ActionResult GetAprobadoresBySecretaria(int id_secretaria, int id_direccion)
        {
            var aprobadores = _RRHH_Solicitud_licenciaService.GetAprobadoresBySecretaria(id_secretaria, id_direccion);
            if (aprobadores.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron Aprobadores para estos Parametros!!!" });
            }
            return Ok(aprobadores);
        }
        [HttpGet]
        public ActionResult GetSolicitudPorAprobador(int id_aprobador)
        {
            var solicitudes = _RRHH_Solicitud_licenciaService.GetSolicitudPorAprobador(id_aprobador);
            if (solicitudes.Count == 0)
            {
                return BadRequest(new { message = "No se encontro la Solicitud de este Aprobador!!!" });
            }
            return Ok(solicitudes);

        }

        [HttpGet]
        public ActionResult GetDatosLicenciaByEmpleado(int legajo)
        {
            var licencias = _RRHH_Solicitud_licenciaService.GetDatosLicenciaByEmpleado(legajo);
            if (licencias.legajo == 0)
            {
                return BadRequest(new { message = "No se encontraron Datos de Licencia para este Legajo!!!" });
            }
            return Ok(licencias);
        }

        [HttpPost]
        public IActionResult ActualizarEstadoSolicitud(int id_solicitud, int legajo, int id_aprobador, string obs, int aprobado)
        {
            switch (aprobado)
            {
                case 0:
                    _RRHH_Solicitud_licenciaService.RechazarSolicitud(id_solicitud, legajo, id_aprobador, obs);
                    break;
                case 1:
                    _RRHH_Solicitud_licenciaService.AprobarSolicitud(id_solicitud, legajo, id_aprobador, obs);
                    break;
                default:
                    BadRequest(new { message = "Opcion no soportada para esta Operacion, llamar a la Oficina de Sistemas!!!" });
                    break;
            }
            return Ok();
        }


    }
}

