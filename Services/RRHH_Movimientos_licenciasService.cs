using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Transactions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RRHHBack.Entities;
using RRHHBack.Entities.EMPLEADOS;
using RRHHBack.Entities.RRHH;

namespace RRHHBack.Services
{
    public class RRHH_Movimientos_licenciasService : IRRHH_Movimientos_licenciasService
    {
        public RRHH_Movimientos_licencias GetByPk(int id_tipo_movimiento, int legajo)
        {
            try
            {
                return RRHH_Movimientos_licencias.GetByPk(id_tipo_movimiento, legajo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public RRHH_Movimientos_licencias GetByID(int id)
        {
            try
            {
                return RRHH_Movimientos_licencias.GetByID(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<RRHH_Movimientos_licencias> read()
        {
            try
            {
                return RRHH_Movimientos_licencias.read();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int insert(RRHH_Movimientos_licencias obj)
        {
            try
            {
                return RRHH_Movimientos_licencias.insert(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void update(RRHH_Movimientos_licencias obj)
        {
            try
            {
                RRHH_Movimientos_licencias.update(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void delete(RRHH_Movimientos_licencias obj)
        {
            try
            {
                RRHH_Movimientos_licencias.delete(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<RRHH_Movimientos_licencias> Movimientos_licencias_paginado(string buscarPor, string strParametro,
           int registro_desde, int registro_hasta)
        {
            try
            {
                return RRHH_Movimientos_licencias.Movimientos_licencias_paginado(buscarPor, strParametro,
                    registro_desde, registro_hasta);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Count()
        {
            try
            {
                return RRHH_Movimientos_licencias.Count();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Liquida_licencias_anuales(DateTime fecha_hoy, string usuario)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    RRHH_Movimientos_licencias.Liquidar_licencia_anuales(fecha_hoy, usuario);
                    scope.Complete();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int InsertMovimientoManual(RRHH_Movimientos_licencias obj)
        {
            try
            {
                int id = 0;
                using (TransactionScope scope = new TransactionScope())
                {
                    //Actualizo las licencias en Empleados
                    if (EmpleadoD.UpdateDatosLicenciaByEmpleado(obj.legajo, obj.total_dias, obj.id))
                    {
                        //y dsp inserto el movimiento
                        id = RRHH_Movimientos_licencias.InsertMovimientoManual(obj);
                        obj.oAudita.id_auditoria = 0;
                        obj.oAudita.fecha_movimiento = DateTime.Now.ToString();
                        obj.oAudita.menu = "GESTION DE LICENCIAS";
                        obj.oAudita.proceso = "AGREGAR_MOVIMIENTO_LICENCIA";
                        obj.oAudita.identificacion = obj.legajo.ToString();
                        obj.oAudita.autorizaciones = "";
                        obj.oAudita.observaciones = string.Format("0", "1", "Se agrego un movimiento a la licencia del Legajo ", obj.legajo);
                        obj.oAudita.detalle = JsonConvert.SerializeObject(obj);
                        //obj.oAudita.usuario = usuario;
                        Auditoria.Insert_movimiento(obj.oAudita);


                    }
                    scope.Complete();
                }
                return id;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}

