using RRHHBack.Entities.EMPLEADOS;
using RRHHBack.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using RRHHBack.Entities;

namespace RRHHBack.Entities.RRHH
{
    public class RRHH_Movimientos_licencias : DALBase
    {
        public int id { get; set; }
        public int id_tipo_movimiento { get; set; }
        public int legajo { get; set; }
        public string cuit { get; set; }
        public DateTime fecha_movimiento { get; set; }
        public string periodo { get; set; }
        public DateTime fecha_liquidacion { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public int total_dias { get; set; }
        public int dias_consumidos { get; set; }
        public int saldo_dias { get; set; }
        public Auditoria oAudita { get; set; }

        public RRHH_Movimientos_licencias()
        {
            id = 0;
            id_tipo_movimiento = 0;
            legajo = 0;
            cuit = string.Empty;
            fecha_movimiento = DateTime.Now;
            periodo = string.Empty;
            fecha_liquidacion = DateTime.Now;
            fecha_vencimiento = DateTime.Now;
            total_dias = 0;
            dias_consumidos = 0;
            saldo_dias = 0;
            oAudita = new Auditoria();
        }

        private static List<RRHH_Movimientos_licencias> mapeo(SqlDataReader dr)
        {
            List<RRHH_Movimientos_licencias> lst = new List<RRHH_Movimientos_licencias>();
            RRHH_Movimientos_licencias obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int id_tipo_movimiento = dr.GetOrdinal("id_tipo_movimiento");
                int legajo = dr.GetOrdinal("legajo");
                int cuit = dr.GetOrdinal("cuit");
                int fecha_movimiento = dr.GetOrdinal("fecha_movimiento");
                int periodo = dr.GetOrdinal("periodo");
                int fecha_liquidacion = dr.GetOrdinal("fecha_liquidacion");
                int fecha_vencimiento = dr.GetOrdinal("fecha_vencimiento");
                int total_dias = dr.GetOrdinal("total_dias");
                int dias_consumidos = dr.GetOrdinal("dias_consumidos");
                int saldo_dias = dr.GetOrdinal("saldo_dias");
                while (dr.Read())
                {
                    obj = new RRHH_Movimientos_licencias();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(id_tipo_movimiento)) { obj.id_tipo_movimiento = dr.GetInt32(id_tipo_movimiento); }
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(cuit)) { obj.cuit = dr.GetString(cuit); }
                    if (!dr.IsDBNull(fecha_movimiento)) { obj.fecha_movimiento = dr.GetDateTime(fecha_movimiento); }
                    if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                    if (!dr.IsDBNull(fecha_liquidacion)) { obj.fecha_liquidacion = dr.GetDateTime(fecha_liquidacion); }
                    if (!dr.IsDBNull(fecha_vencimiento)) { obj.fecha_vencimiento = dr.GetDateTime(fecha_vencimiento); }
                    if (!dr.IsDBNull(total_dias)) { obj.total_dias = dr.GetInt32(total_dias); }
                    if (!dr.IsDBNull(dias_consumidos)) { obj.dias_consumidos = dr.GetInt32(dias_consumidos); }
                    if (!dr.IsDBNull(saldo_dias)) { obj.saldo_dias = dr.GetInt32(saldo_dias); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<RRHH_Movimientos_licencias> read()
        {
            try
            {
                List<RRHH_Movimientos_licencias> lst = new List<RRHH_Movimientos_licencias>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM RRHH_Movimientos_licencias";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static RRHH_Movimientos_licencias GetByPk(int id_tipo_movimiento, int legajo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Rrhh_movimientos_licencias");
                sql.AppendLine("WHERE id_tipo_movimiento = @id_tipo_movimiento");
                sql.AppendLine("AND legajo = @legajo");
                RRHH_Movimientos_licencias? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tipo_movimiento", id_tipo_movimiento);
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<RRHH_Movimientos_licencias> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static RRHH_Movimientos_licencias GetByID(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Rrhh_movimientos_licencias");
                sql.AppendLine("WHERE id_tipo_movimiento = @id_tipo_movimiento");
                sql.AppendLine("AND legajo = @legajo");
                RRHH_Movimientos_licencias? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<RRHH_Movimientos_licencias> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int insert(RRHH_Movimientos_licencias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO RRHH_Movimientos_licencias(");
                sql.AppendLine("id");
                sql.AppendLine(", id_tipo_movimiento");
                sql.AppendLine(", legajo");
                sql.AppendLine(", cuit");
                sql.AppendLine(", fecha_movimiento");
                sql.AppendLine(", periodo");
                sql.AppendLine(", fecha_liquidacion");
                sql.AppendLine(", fecha_vencimiento");
                sql.AppendLine(", total_dias");
                sql.AppendLine(", dias_consumidos");
                sql.AppendLine(", saldo_dias");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id");
                sql.AppendLine(", @id_tipo_movimiento");
                sql.AppendLine(", @legajo");
                sql.AppendLine(", @cuit");
                sql.AppendLine(", @fecha_movimiento");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @fecha_liquidacion");
                sql.AppendLine(", @fecha_vencimiento");
                sql.AppendLine(", @total_dias");
                sql.AppendLine(", @dias_consumidos");
                sql.AppendLine(", @saldo_dias");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@id_tipo_movimiento", obj.id_tipo_movimiento);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@fecha_movimiento", obj.fecha_movimiento);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@fecha_liquidacion", obj.fecha_liquidacion);
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", obj.fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@total_dias", obj.total_dias);
                    cmd.Parameters.AddWithValue("@dias_consumidos", obj.dias_consumidos);
                    cmd.Parameters.AddWithValue("@saldo_dias", obj.saldo_dias);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void update(RRHH_Movimientos_licencias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  RRHH_Movimientos_licencias SET");
                sql.AppendLine("id=@id");
                sql.AppendLine(", cuit=@cuit");
                sql.AppendLine(", fecha_movimiento=@fecha_movimiento");
                sql.AppendLine(", periodo=@periodo");
                sql.AppendLine(", fecha_liquidacion=@fecha_liquidacion");
                sql.AppendLine(", fecha_vencimiento=@fecha_vencimiento");
                sql.AppendLine(", total_dias=@total_dias");
                sql.AppendLine(", dias_consumidos=@dias_consumidos");
                sql.AppendLine(", saldo_dias=@saldo_dias");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_tipo_movimiento=@id_tipo_movimiento");
                sql.AppendLine("AND legajo=@legajo");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@id_tipo_movimiento", obj.id_tipo_movimiento);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@fecha_movimiento", obj.fecha_movimiento);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@fecha_liquidacion", obj.fecha_liquidacion);
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", obj.fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@total_dias", obj.total_dias);
                    cmd.Parameters.AddWithValue("@dias_consumidos", obj.dias_consumidos);
                    cmd.Parameters.AddWithValue("@saldo_dias", obj.saldo_dias);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(RRHH_Movimientos_licencias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  RRHH_Movimientos_licencias ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_tipo_movimiento=@id_tipo_movimiento");
                sql.AppendLine("AND legajo=@legajo");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tipo_movimiento", obj.id_tipo_movimiento);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<RRHH_Movimientos_licencias> Movimientos_licencias_paginado(string buscarPor, string strParametro,
           int registro_desde, int registro_hasta)
        {
            try
            {
                bool busquedaSi = false;
                List<RRHH_Movimientos_licencias> lst = new List<RRHH_Movimientos_licencias>();
                string strSQL = @"SELECT * 
                                  FROM RRHH_Movimientos_licencias";
                string sqlWhere = "";
                if (!string.IsNullOrEmpty(buscarPor))
                {
                    switch (buscarPor)
                    {
                        case "id_tipo_movimiento":
                            sqlWhere = @" WHERE
                                id_tipo_licencia=Convert(int,@parametro) AND
                                id BETWEEN @desde AND @hasta";
                            break;
                        case "cuit":
                            sqlWhere = @" WHERE
                                cuit=Convert(varchar(11),@parametro) AND
                                id BETWEEN @desde AND @hasta";
                            break;
                        case "legajo":
                            sqlWhere = @" WHERE
                                legajo=Convert(int, @parametro) AND
                                id BETWEEN @desde AND @hasta";
                            break;
                        case "periodo":
                            sqlWhere = @" WHERE
                                periodo=@parametro AND
                                id BETWEEN @desde AND @hasta";
                            break;
                        default:
                            break;
                    }
                }
                if (sqlWhere.Length > 0)
                {
                    busquedaSi = true;
                    strSQL += sqlWhere;
                }
                else
                {
                    busquedaSi = false;
                    strSQL += " WHERE fecha_movimiento BETWEEN @desde AND @hasta ORDER By fecha_movimiento";
                }
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@desde", registro_desde);
                    cmd.Parameters.AddWithValue("@hasta", registro_hasta);
                    if (busquedaSi)
                        cmd.Parameters.AddWithValue("@parametro", strParametro);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Count()
        {
            try
            {
                int count = 0;
                string sql = @"SELECT count(*) 
                               FROM RRHH_Movimientos_licencias (nolock)";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void InsertNuevasLicencias(List<RRHH_Movimientos_licencias> lst)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO RRHH_Movimientos_licencias(");
                sql.AppendLine("id_tipo_movimiento");
                sql.AppendLine(", legajo");
                sql.AppendLine(", cuit");
                sql.AppendLine(", fecha_movimiento");
                sql.AppendLine(", periodo");
                sql.AppendLine(", fecha_liquidacion");
                sql.AppendLine(", fecha_vencimiento");
                sql.AppendLine(", total_dias");
                sql.AppendLine(", dias_consumidos");
                sql.AppendLine(", saldo_dias");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_tipo_movimiento");
                sql.AppendLine(", @legajo");
                sql.AppendLine(", @cuit");
                sql.AppendLine(", @fecha_movimiento");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @fecha_liquidacion");
                sql.AppendLine(", @fecha_vencimiento");
                sql.AppendLine(", @total_dias");
                sql.AppendLine(", @dias_consumidos");
                sql.AppendLine(", @saldo_dias");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tipo_movimiento", 1);
                    cmd.Parameters.AddWithValue("@legajo", 0);
                    cmd.Parameters.AddWithValue("@cuit", "");
                    cmd.Parameters.AddWithValue("@fecha_movimiento", DateTime.Now);
                    cmd.Parameters.AddWithValue("@periodo", "0000/00");
                    cmd.Parameters.AddWithValue("@fecha_liquidacion", DateTime.Now);
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", (DateTime.Now.AddYears(1)));
                    cmd.Parameters.AddWithValue("@total_dias", 0);
                    cmd.Parameters.AddWithValue("@dias_consumidos", 0);
                    cmd.Parameters.AddWithValue("@saldo_dias", 0);
                    cmd.Connection.Open();
                    foreach (var item in lst)
                    {
                        cmd.Parameters["@id_tipo_movimiento"].Value = item.id_tipo_movimiento;
                        cmd.Parameters["@legajo"].Value = item.legajo;
                        cmd.Parameters["@cuit"].Value = item.cuit;
                        cmd.Parameters["@fecha_movimiento"].Value = item.fecha_movimiento;
                        cmd.Parameters["@periodo"].Value = item.periodo;
                        cmd.Parameters["@fecha_liquidacion"].Value = item.fecha_liquidacion;
                        cmd.Parameters["@fecha_vencimiento"].Value = item.fecha_vencimiento;
                        cmd.Parameters["@total_dias"].Value = item.total_dias;
                        cmd.Parameters["@dias_consumidos"].Value = item.dias_consumidos;
                        cmd.Parameters["@saldo_dias"].Value = item.saldo_dias;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void Liquidar_licencia_anuales(DateTime fecha_hoy, string usuario)
        {
            var ErrorMessage = string.Empty;
            try
            {
                int antiguedad = 0;
                string periodo = string.Format("{0}/{1}", fecha_hoy.Year,
                                                          fecha_hoy.Month.ToString().PadLeft(2, Convert.ToChar("0")));
                List<LstEmpleados> lstEmp = new List<LstEmpleados>();
                List<Entities.EMPLEADOS.AntiguedadEmp> lstAntiguedad = new();//List<Entities.EMPLEADOS.AntiguedadEmp>();
                Entities.EMPLEADOS.AntiguedadEmp objAntiguedad;
                List<RRHH_Movimientos_licencias> lstMovlicencias = new();//List<RRHH_Movimientos_licencias>();
                RRHH_Movimientos_licencias objMov;

                lstEmp = EmpleadoD.GetLstEmpleados();
                antiguedad = 0;
                foreach (var item in lstEmp)
                {
                    objAntiguedad = new Entities.EMPLEADOS.AntiguedadEmp();
                    antiguedad = Helpers.Antiguedad(Convert.ToDateTime(item.fecha_ingreso),
                        Convert.ToDateTime(fecha_hoy)) + item.antiguedad_ant;
                    objAntiguedad.legajo = item.legajo;
                    objAntiguedad.antiguedad = antiguedad;
                    objAntiguedad.cuit = item.cuit;
                    if (antiguedad > 0)
                        objAntiguedad.dias_licencia = RRHH_Seteo_licencias.GetLicenciasByAntiguedad(antiguedad, item.cod_clasif_per);
                    else
                        objAntiguedad.dias_licencia = RRHH_Seteo_licencias.GetLicenciaxDias(Convert.ToDateTime(item.fecha_ingreso));
                    lstAntiguedad.Add(objAntiguedad);
                }
                //
                foreach (var item in lstAntiguedad)
                {
                    objMov = new RRHH_Movimientos_licencias();
                    objMov.id_tipo_movimiento = 1;
                    objMov.legajo = item.legajo;
                    objMov.cuit = item.cuit;
                    objMov.periodo = periodo;
                    objMov.fecha_movimiento = DateTime.Now;
                    objMov.fecha_liquidacion = DateTime.Now;
                    objMov.fecha_vencimiento = DateTime.Now.AddYears(1);
                    objMov.total_dias = item.dias_licencia;
                    objMov.dias_consumidos = 0;
                    objMov.saldo_dias = 0;
                    lstMovlicencias.Add(objMov);
                }
                if (lstMovlicencias.Count > 0)
                    InsertNuevasLicencias(lstMovlicencias);
                else
                {
                    ErrorMessage = "No se Encontraron datos para la Liquidación en curso!." + "<br>"
                   + " Para continuar con la Liquidación, verifique el Periodo de Licencias a Liquidar" + "<br>"
                   + " Solicite asistencia a la Oficina de Sistemas!," + "<br>";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Encontrado: " + ErrorMessage, ex);
            }
        }
        public static int InsertMovimientoManual(RRHH_Movimientos_licencias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO RRHH_Movimientos_licencias(");
                sql.AppendLine("id_tipo_movimiento");
                sql.AppendLine(", legajo");
                sql.AppendLine(", cuit");
                sql.AppendLine(", fecha_movimiento");
                sql.AppendLine(", periodo");
                sql.AppendLine(", fecha_liquidacion");
                sql.AppendLine(", fecha_vencimiento");
                sql.AppendLine(", total_dias");
                sql.AppendLine(", dias_consumidos");
                sql.AppendLine(", saldo_dias");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_tipo_movimiento");
                sql.AppendLine(", @legajo");
                sql.AppendLine(", @cuit");
                sql.AppendLine(", @fecha_movimiento");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @fecha_liquidacion");
                sql.AppendLine(", @fecha_vencimiento");
                sql.AppendLine(", @total_dias");
                sql.AppendLine(", @dias_consumidos");
                sql.AppendLine(", @saldo_dias");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tipo_movimiento", obj.id_tipo_movimiento);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@fecha_movimiento", obj.fecha_movimiento);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@fecha_liquidacion", obj.fecha_movimiento);
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", (DateTime.Now.AddYears(1)));
                    cmd.Parameters.AddWithValue("@total_dias", obj.total_dias);
                    cmd.Parameters.AddWithValue("@dias_consumidos", obj.dias_consumidos);
                    cmd.Parameters.AddWithValue("@saldo_dias", obj.saldo_dias);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}

