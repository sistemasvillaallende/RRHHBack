using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHHBack.Entities.RRHH
{
    public class RRHH_Seteo_licencias : DALBase
    {
        public int id { get; set; }
        public string descripcion_licencia { get; set; }
        public int cod_clasif_personal { get; set; }
        public DateTime fecha_alta { get; set; }
        public short activo { get; set; }
        public int antiguedad_desde { get; set; }
        public int antiguedad_hasta { get; set; }
        public int dias_licencias { get; set; }

        public RRHH_Seteo_licencias()
        {
            id = 0;
            descripcion_licencia = string.Empty;
            cod_clasif_personal = 0;
            fecha_alta = DateTime.Now;
            activo = 0;
            antiguedad_desde = 0;
            antiguedad_hasta = 0;
            dias_licencias = 0;
        }

        private static List<RRHH_Seteo_licencias> mapeo(SqlDataReader dr)
        {
            List<RRHH_Seteo_licencias> lst = new List<RRHH_Seteo_licencias>();
            RRHH_Seteo_licencias obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int descripcion_licencia = dr.GetOrdinal("descripcion_licencia");
                int cod_clasif_personal = dr.GetOrdinal("cod_clasif_personal");
                int fecha_alta = dr.GetOrdinal("fecha_alta");
                int activo = dr.GetOrdinal("activo");
                int antiguedad_desde = dr.GetOrdinal("antiguedad_desde");
                int antiguedad_hasta = dr.GetOrdinal("antiguedad_hasta");
                int dias_licencias = dr.GetOrdinal("dias_licencias");
                while (dr.Read())
                {
                    obj = new RRHH_Seteo_licencias();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(descripcion_licencia)) { obj.descripcion_licencia = dr.GetString(descripcion_licencia); }
                    if (!dr.IsDBNull(cod_clasif_personal)) { obj.cod_clasif_personal = dr.GetInt32(cod_clasif_personal); }
                    if (!dr.IsDBNull(fecha_alta)) { obj.fecha_alta = dr.GetDateTime(fecha_alta); }
                    if (!dr.IsDBNull(activo)) { obj.activo = dr.GetInt16(activo); }
                    if (!dr.IsDBNull(antiguedad_desde)) { obj.antiguedad_desde = dr.GetInt32(antiguedad_desde); }
                    if (!dr.IsDBNull(antiguedad_hasta)) { obj.antiguedad_desde = dr.GetInt32(antiguedad_hasta); }
                    if (!dr.IsDBNull(dias_licencias)) { obj.dias_licencias = dr.GetInt32(dias_licencias); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<RRHH_Seteo_licencias> read()
        {
            try
            {
                List<RRHH_Seteo_licencias> lst = new List<RRHH_Seteo_licencias>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Rrhh_seteo_licencias";
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

        public static RRHH_Seteo_licencias getByPk(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM RRHH_Seteo_licencias WHERE");
                sql.AppendLine("id = @id");
                RRHH_Seteo_licencias obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<RRHH_Seteo_licencias> lst = mapeo(dr);
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

        public static int insert(RRHH_Seteo_licencias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO RRHH_Seteo_licencias(");
                sql.AppendLine("descripcion_licencia");
                sql.AppendLine(", cod_clasif_personal");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(", activo");
                sql.AppendLine(", antiguedad_desde");
                sql.AppendLine(", antiguedad_hasta");
                sql.AppendLine(", dias_licencias");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@descripcion_licencia");
                sql.AppendLine("@cod_clasif_personal");
                sql.AppendLine("@fecha_alta");
                sql.AppendLine("@activo");
                sql.AppendLine("@antiguedad_desde");
                sql.AppendLine("@antiguedad_hasta");
                sql.AppendLine("@dias_licencias");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@descripcion_licencia", obj.descripcion_licencia);
                    cmd.Parameters.AddWithValue("@cod_clasif_personal", obj.cod_clasif_personal);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@antiguedad_desde", obj.antiguedad_desde);
                    cmd.Parameters.AddWithValue("@antiguedad_hasta", obj.antiguedad_hasta);
                    cmd.Parameters.AddWithValue("@dias_licencias", obj.dias_licencias);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(RRHH_Seteo_licencias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  RRHH_Seteo_licencias SET");
                sql.AppendLine("descripcion_licencia=@descripcion_licencia");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", antiguedad_desde=@antiguedad_desde");
                sql.AppendLine(", antiguedad_hasta=@antiguedad_hasta");
                sql.AppendLine(", dias_licencias=@dias_licencias");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@descipcion_licencia", obj.descripcion_licencia);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@antiguedad_desde", obj.antiguedad_desde);
                    cmd.Parameters.AddWithValue("@antiguedad_hasta", obj.antiguedad_hasta);
                    cmd.Parameters.AddWithValue("@dias_licencias", obj.dias_licencias);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(RRHH_Seteo_licencias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  RRHH_Seteo_licencias ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetLicenciasByAntiguedad(int antiguedad, int cod_clasif_per)
        {
            try
            {
                string sql = @"SELECT * 
                               FROM RRHH_Seteo_licencias 
                               WHERE activo=1 AND
                                 cod_clasif_personal=@cod_clasif_per AND
                                 @antiguedad between antiguedad_desde and antiguedad_hasta";

                RRHH_Seteo_licencias? obj = new RRHH_Seteo_licencias();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@antiguedad", antiguedad);
                    cmd.Parameters.AddWithValue("@cod_clasif_per", cod_clasif_per);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<RRHH_Seteo_licencias> lst = mapeo(dr);
                    if (lst.Count > 0)
                        obj = lst[0];
                }
                return obj.dias_licencias;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int GetLicenciaxDias(DateTime fecha_ingreso)
        {
            // Obtiene la fecha actual,
            DateTime fecha_actual = DateTime.Today;
            int meses = fecha_actual.Month - fecha_ingreso.Month;
            return meses;
        }

    }
}

