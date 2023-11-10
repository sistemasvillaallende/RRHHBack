using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Transactions;
using Microsoft.Extensions.Options;
using RRHHBack.Entities.EMPLEADOS;
using RRHHBack.Entities.RRHH;
using RRHHBack.Library;


namespace RRHHBack.Services
{
    public class RRHH_Seteo_licenciasService : IRRHH_Seteo_licenciasService
    {
        public RRHH_Seteo_licencias getByPk(int id)
        {
            try
            {
                return RRHH_Seteo_licencias.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<RRHH_Seteo_licencias> read()
        {
            try
            {
                return RRHH_Seteo_licencias.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(RRHH_Seteo_licencias obj)
        {
            try
            {
                return RRHH_Seteo_licencias.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(RRHH_Seteo_licencias obj)
        {
            try
            {
                RRHH_Seteo_licencias.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(RRHH_Seteo_licencias obj)
        {
            try
            {
                RRHH_Seteo_licencias.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void Liquidar_vacaciones(DateTime fecha_hoy, string usuario)
        //{
        //    var ErrorMessage = string.Empty;
        //    try
        //    {
        //        int antiguedad = 0;
        //        //DateTime fecha_hoy = DateTime.Now;
        //        string periodo = string.Format("{0}/{1}", fecha_hoy.Year,
        //                                                  fecha_hoy.Month.ToString().PadLeft(2, Convert.ToChar("0")));
        //        List<LstEmpleados> lstEmp = new List<LstEmpleados>();
        //        List<Entities.EMPLEADOS.AntiguedadEmp> lstAntiguedad = new List<Entities.EMPLEADOS.AntiguedadEmp>();
        //        Entities.EMPLEADOS.AntiguedadEmp objAntiguedad;
        //        List<RRHH_Movimientos_licencias> lstMovlicencias = new List<RRHH_Movimientos_licencias>();
        //        RRHH_Movimientos_licencias objMov;
        //        using (TransactionScope scope = new())
        //        {
        //            lstEmp = EmpleadoD.GetLstEmpleados();
        //            antiguedad = 0;
        //            foreach (var item in lstEmp)
        //            {
        //                objAntiguedad = new Entities.EMPLEADOS.AntiguedadEmp();
        //                antiguedad = Helpers.Antiguedad(Convert.ToDateTime(item.fecha_ingreso),
        //                    Convert.ToDateTime(fecha_hoy)) + item.antiguedad_ant;
        //                objAntiguedad.legajo = item.legajo;
        //                objAntiguedad.antiguedad = antiguedad;
        //                objAntiguedad.cuit = item.cuit;
        //                if (antiguedad > 0)
        //                    objAntiguedad.dias_licencia = RRHH_Seteo_licencias.GetLicenciasByAntiguedad(antiguedad, item.cod_clasif_per);
        //                else
        //                    objAntiguedad.dias_licencia = RRHH_Seteo_licencias.GetLicenciaxDias(Convert.ToDateTime(item.fecha_ingreso));
        //                lstAntiguedad.Add(objAntiguedad);
        //            }
        //            //
        //            foreach (var item in lstAntiguedad)
        //            {
        //                objMov = new RRHH_Movimientos_licencias();
        //                objMov.id_tipo_movimiento = 1;
        //                objMov.legajo = item.legajo;
        //                objMov.cuit = item.cuit;
        //                objMov.fecha_movimiento = DateTime.Now;
        //                objMov.fecha_liquidacion = DateTime.Now;
        //                objMov.fecha_vencimiento = DateTime.Now.AddYears(1);
        //                objMov.total_dias = item.dias_licencia;
        //                objMov.dias_consumidos = 0;
        //                objMov.saldo_dias = 0;
        //                lstMovlicencias.Add(objMov);
        //            }
        //            if (lstMovlicencias.Count > 0)
        //                RRHH_Movimientos_licencias.InsertNuevasLincencias(lstMovlicencias);
        //            else
        //            {
        //                ErrorMessage = "No se Encontraron datos para la Liquidación en curso!." + "<br>"
        //               + " Para continuar con la Liquidación, verifique el Periodo de Licencias a Liquidar" + "<br>"
        //               + " Solicite asistencia a la Oficina de Sistemas!," + "<br>";
        //            }
        //            scope.Complete();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error Encontrado: " + ErrorMessage, ex);
        //    }
        //}


    }
}

