using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using RRHHBack.Entities.RRHH;
using RRHHBack.Library;

namespace RRHHBack.Services
{
    public class RRHH_Solicitud_licenciaService : IRRHH_Solicitud_licenciaService
    {
        public RRHH_Solicitud_licencia getByPk()
        {
            try
            {
                return RRHH_Solicitud_licencia.getByPk();
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
        public List<RRHH_Solicitud_licencia> read()
        {
            try
            {
                return RRHH_Solicitud_licencia.read();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int insert(RRHH_Solicitud_licencia obj)
        {
            try
            {
                return RRHH_Solicitud_licencia.insert(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void update(RRHH_Solicitud_licencia obj)
        {
            try
            {
                RRHH_Solicitud_licencia.update(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void delete(RRHH_Solicitud_licencia obj)
        {
            try
            {
                RRHH_Solicitud_licencia.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Combo> Tipos_licencias()
        {
            try
            {
                return RRHH_Tipos_licencias.Tipos_licencias();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Combo> Tipos_movimientos_lic()
        {
            try
            {
                return RRHH_Tipos_movimientos_lic.Tipos_movimientos_lic();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<RRHH_Solicitud_licencia> Solicitudes_paginado(string buscarPor, string strParametro,
            int registro_desde, int registro_hasta)
        {
            try
            {
                return RRHH_Solicitud_licencia.Solicitudes_paginado(buscarPor, strParametro, registro_desde, registro_hasta);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Count(string buscarPor, string strParametro)
        {
            try
            {
                return RRHH_Solicitud_licencia.Count(buscarPor, strParametro);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<RRHH_Solicitud_licencia> GetSolicitudPorAprobador(int id_aprobador)
        {
            try
            {
                return RRHH_Solicitud_licencia.GetSolicitudPorAprobador(id_aprobador);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Aprobadores> GetAprobadoresBySecretaria(int id_secretaria, int id_direccion)
        {
            try
            {
                return Aprobadores.GetAprobadoresBySecretaria(id_secretaria, id_direccion);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Aprobadores> GetAprobadoresAll()
        {
            try
            {
                return Aprobadores.GetAprobadoresAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Aprobadores GetAprobadorByLegajo(int legajo)
        {
            try
            {
                return Aprobadores.GetAprobadorByLegajo(legajo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Licencia GetDatosLicenciaByEmpleado(int legajo)
        {
            try
            {
                return Licencia.GetDatosLicenciaByEmpleado(legajo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void RechazarSolicitud(int id, int legajo, int id_aprobador, string obs)
        {
            try
            {
                RRHH_Solicitud_licencia.RechazarSolicitud(id, legajo, obs);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AprobarSolicitud(int id, int legajo, int id_aprobador, string obs)
        {
            try
            {
                RRHH_Solicitud_licencia.AprobarSolicitud(id, legajo, obs);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

