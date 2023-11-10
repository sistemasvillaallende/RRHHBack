using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using RRHHBack.Services;
using RRHHBack.Library;
using RRHHBack.Entities.RRHH;
using RRHHBack.Entities;

namespace RRHHBack.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RRHH_Movimientos_licenciasController : Controller
    {
        private IRRHH_Movimientos_licenciasService _RRHH_Movimientos_licenciasService;
        public RRHH_Movimientos_licenciasController(IRRHH_Movimientos_licenciasService RRHH_Movimientos_licenciasService)
        {
            _RRHH_Movimientos_licenciasService = RRHH_Movimientos_licenciasService;
        }
        [HttpGet]
        public IActionResult GetByPk(int id_tipo_movimiento, int legajo)
        {
            var RRHH_Movimientos_licencias = _RRHH_Movimientos_licenciasService.GetByPk(id_tipo_movimiento, legajo);
            if (RRHH_Movimientos_licencias == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(RRHH_Movimientos_licencias);
        }

        [HttpGet]
        public ActionResult<PaginadorGenerico<RRHH_Movimientos_licencias>> Movimientos_licencias_paginado(string buscarPor = "", string strParametro = "",
            int activo = 1, int pagina = 0, int registros_por_pagina = 10)
        {
            List<RRHH_Movimientos_licencias> _Movimientos;
            PaginadorGenerico<RRHH_Movimientos_licencias> _PaginadorMovimientos;
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;
            _TotalRegistros = _RRHH_Movimientos_licenciasService.Count();
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);
            if (!string.IsNullOrEmpty(buscarPor) && buscarPor != "0" && strParametro != "0")
            {
                _Movimientos = _RRHH_Movimientos_licenciasService.Movimientos_licencias_paginado(buscarPor, strParametro, 0, _TotalRegistros);
            }
            else
                _Movimientos = _RRHH_Movimientos_licenciasService.Movimientos_licencias_paginado(buscarPor, strParametro, (pagina * registros_por_pagina) - registros_por_pagina + 1,
                                                                            pagina * registros_por_pagina);
            //Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _PaginadorMovimientos = new PaginadorGenerico<RRHH_Movimientos_licencias>()
            {
                RegistrosPorPagina = registros_por_pagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                BusquedaPor = buscarPor,
                Parametro = strParametro,
                //OrdenActual = orden,
                //TipoOrdenActual = tipo_orden,
                Resultado = _Movimientos
            };
            if (_PaginadorMovimientos == null)
            {
                return BadRequest(new { message = "No se encontraron los datos" });
            }
            return _PaginadorMovimientos;
        }

        [HttpPost]
        public IActionResult Liquida_licencias_anuales(DateTime fecha_hoy, string usuario)
        {
            DateTime fecha_sistema = DateTime.Now;
            if (fecha_hoy.Year >= fecha_sistema.Year)
            {
                _RRHH_Movimientos_licenciasService.Liquida_licencias_anuales(fecha_hoy, usuario);
            }
            else
                return BadRequest(new { message = @"Error en la Liquidacion de las Licencias, 
                                                    la fecha de ingreso no puede ser menor a la fecha de Sistema!" });
            return Ok();
        }

        [HttpPost]
        public IActionResult InsertMovimientoManual(RRHH_Movimientos_licencias obj, string usuario)
        {
            obj.oAudita.fecha_movimiento = DateTime.Now.ToString();
            obj.oAudita.usuario = usuario;
            _RRHH_Movimientos_licenciasService.InsertMovimientoManual(obj);
            var Movimiento = _RRHH_Movimientos_licenciasService.GetByID(obj.id);
            if (Movimiento.id == 0)
            {
                return Ok(new { message = "Error no se pudo Insertar el Movimiento de Licencia." });
            }
            return Ok(Movimiento);
        }
    }
}

