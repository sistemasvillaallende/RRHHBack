using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using System.Transactions;
using System.Globalization;
using RRHHBack.Library;
using RRHHBack.Entities.RRHH;
using System.Diagnostics;

namespace RRHHBack.Entities.EMPLEADOS
{
    public class EmpleadoD
    {
        public static List<LstEmpleados> GetLstEmpleados()
        {
            string strSQL = "";
            List<LstEmpleados> lst = new List<LstEmpleados>();
            LstEmpleados oEmp;

            strSQL = @"SELECT
                        e.legajo, rtrim(ltrim(e.nombre)) as nombre, 
                        convert(varchar(10), e.fecha_ingreso, 103) as fecha_ingreso, 
                        convert(varchar(10), e.fecha_nacimiento, 103) as fecha_nacimiento,
                        e.cuit,
                        e.cod_categoria, c.des_categoria, e.tarea, tl.des_tipo_liq,
                        b.nom_banco, e.nro_caja_ahorro, e.nro_cbu,
                        e.nro_documento, e.nro_cta_sb, e.nro_cta_gastos,
                        e.antiguedad_ant,
                        rtrim(ltrim(s.descripcion)) as secretaria, 
                        rtrim(ltrim(d1.descripcion)) as direccion, 
                        ltrim(rtrim(o.nombre_oficina)) as oficina,
                        rtrim(ltrim(p.programa)) as programa,
                        rtrim(ltrim(srl.descripcion)) as situacion_revista,
                        sivacaciones,
                        total_dias_vacaciones, total_dias_razones
                      FROM EMPLEADOS e
                        inner join TIPOS_LIQUIDACION tl on
                        tl.cod_tipo_liq = e.cod_tipo_liq
                        inner join BANCOS b on
                        b.cod_banco = e.cod_banco
                        inner join CATEGORIAS c on
                        e.cod_categoria = c.cod_categoria
                        inner join secretaria s on
                        s.id_secretaria = e.id_secretaria
                        inner join direccion d1 on
                        d1.id_direccion = e.id_direccion
                        inner join oficinas o on
                        o.codigo_oficina = e.id_oficina
                        inner join programas_publicos p on
                        p.id_programa = e.id_programa
                        Left join situacion_revista_legajo srl on
                        srl.id_revista = e.id_revista
                      WHERE e.fecha_baja is null
                      ORDER BY e.legajo";
            try
            {
                using (SqlConnection cn = DALBase.GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int legajo = dr.GetOrdinal("legajo");
                        int nombre = dr.GetOrdinal("nombre");
                        int fecha_ingreso = dr.GetOrdinal("fecha_ingreso");
                        int fecha_nac = dr.GetOrdinal("fecha_nacimiento");
                        int cuit = dr.GetOrdinal("fecha_nacimiento");
                        int cod_categoria = dr.GetOrdinal("cod_categoria");
                        int des_categoria = dr.GetOrdinal("des_categoria");
                        int tarea = dr.GetOrdinal("tarea");
                        int des_tipo_liq = dr.GetOrdinal("des_tipo_liq");
                        int nom_banco = dr.GetOrdinal("nom_banco");
                        int nro_caja_ahorro = dr.GetOrdinal("nro_caja_ahorro");
                        int nro_cbu = dr.GetOrdinal("nro_cbu");
                        int nro_documento = dr.GetOrdinal("nro_documento");
                        int nro_cta_sb = dr.GetOrdinal("nro_cta_sb");
                        int antiguedad_ant = dr.GetOrdinal("antiguedad_ant");
                        int cod_seccion = dr.GetOrdinal("cod_seccion");
                        int secretaria = dr.GetOrdinal("secretaria");
                        int direccion = dr.GetOrdinal("direccion");
                        int oficina = dr.GetOrdinal("oficina");
                        //int usuario = dr.GetOrdinal("usuario");
                        int programa = dr.GetOrdinal("programa");
                        int situacion_revista = dr.GetOrdinal("situacion_revista");
                        int sivacaciones = dr.GetOrdinal("sivacaciones");
                        int total_dias_vacaciones = dr.GetOrdinal("total_dias_vacaciones");
                        int total_dias_razones = dr.GetOrdinal("total_dias_razones");

                        while (dr.Read())
                        {
                            oEmp = new LstEmpleados();

                            if (!dr.IsDBNull(legajo)) oEmp.legajo = dr.GetInt32(legajo);
                            if (!dr.IsDBNull(nombre)) oEmp.nombre = dr.GetString(nombre);
                            if (!dr.IsDBNull(fecha_ingreso)) oEmp.fecha_ingreso = dr.GetString(fecha_ingreso);
                            if (!dr.IsDBNull(nro_documento)) oEmp.nro_documento = dr.GetString(nro_documento);
                            if (!dr.IsDBNull(fecha_nac)) oEmp.fecha_nacimiento = dr.GetString(fecha_nac);
                            if (!dr.IsDBNull(cuit)) oEmp.cuit = dr.GetString(cuit);
                            if (!dr.IsDBNull(cod_categoria)) oEmp.cod_categoria = dr.GetInt16(cod_categoria);
                            if (!dr.IsDBNull(des_categoria)) oEmp.des_categoria = dr.GetString(des_categoria);
                            if (!dr.IsDBNull(tarea)) oEmp.tarea = dr.GetString(tarea);
                            if (!dr.IsDBNull(des_tipo_liq)) oEmp.des_tipo_liq = dr.GetString(des_tipo_liq);
                            if (!dr.IsDBNull(nom_banco)) oEmp.nom_banco = dr.GetString(nom_banco);
                            if (!dr.IsDBNull(nro_caja_ahorro)) oEmp.nro_caja_ahorro = dr.GetString(nro_caja_ahorro);
                            if (!dr.IsDBNull(nro_cbu)) oEmp.nro_cbu = dr.GetString(nro_cbu);
                            if (!dr.IsDBNull(nro_documento)) oEmp.nro_documento = dr.GetString(nro_documento);
                            if (!dr.IsDBNull(nro_cta_sb)) oEmp.nro_cta_sb = dr.GetString(nro_cta_sb);
                            if (!dr.IsDBNull(antiguedad_ant)) oEmp.antiguedad_ant = dr.GetInt32(antiguedad_ant);
                            if (!dr.IsDBNull(secretaria)) oEmp.secrectaria = dr.GetString(secretaria);
                            if (!dr.IsDBNull(direccion)) oEmp.direccion = dr.GetString(direccion);
                            if (!dr.IsDBNull(oficina)) oEmp.oficina = dr.GetString(oficina);
                            if (!dr.IsDBNull(programa)) oEmp.programa = dr.GetString(programa);
                            if (!dr.IsDBNull(situacion_revista)) oEmp.situacion_revista = dr.GetString(situacion_revista);
                            if (!dr.IsDBNull(sivacaciones)) oEmp.sivacaciones = dr.GetBoolean(sivacaciones);
                            if (!dr.IsDBNull(total_dias_vacaciones)) oEmp.total_dias_vacaciones = dr.GetInt32(total_dias_vacaciones);
                            if (!dr.IsDBNull(total_dias_razones)) oEmp.total_dias_razones = dr.GetInt32(total_dias_razones);
                            lst.Add(oEmp);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw;
            }
            return lst;
        }

        public static bool UpdateDatosLicenciaByEmpleado(int legajo, int dias, int id_tipo_movimiento)
        {
            try
            {
                bool ok = false;
                string sql = @"UPDATE EMPLEADOS
                               SET licenciagenerada=@licenciagenerada, licenciadisponible=@disponible,
                                   licenciausadas=@licenciausadas, razonesparticulares=@razonesparticulares
                               WHERE legajo=@legajo";
                Licencia oLic_actual = Licencia.GetDatosLicenciaByEmpleado(legajo);
                using (SqlConnection cn = DALBase.GetConnectionSIIMVA())
                {
                    switch (id_tipo_movimiento)
                    {
                        case 1:
                            oLic_actual.licenciagenerada = dias;
                            oLic_actual.licenciadisponible += dias;
                            break;
                        case 2:
                            oLic_actual.licenciausadas -= dias;
                            oLic_actual.licenciadisponible -= dias;
                            break;
                        case 3:
                            oLic_actual.razonesparticulares = dias;
                            break;
                        case 4:
                            oLic_actual.razonesparticulares -= dias;
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        default:
                            break;
                    }
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@licenciagenerada", oLic_actual.licenciagenerada);
                    cmd.Parameters.AddWithValue("@licenciadisponible", oLic_actual.licenciadisponible);
                    cmd.Parameters.AddWithValue("@licenciausadas", oLic_actual.licenciausadas);
                    cmd.Parameters.AddWithValue("@razonesparticulares", oLic_actual.razonesparticulares);
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    ok = true;
                }
                return ok;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}




