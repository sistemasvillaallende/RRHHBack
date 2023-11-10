using RRHHBack.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RRHHBack.Entities.RRHH
{
    public class RRHH_Tipos_licencias : DALBase
    {
        public int id { get; set; }
        public string descripcion_licencia { get; set; }
        public DateTime fecha_alta { get; set; }
        public short es_paga { get; set; }
        public short descuentadias { get; set; }
        public short requiere_aprobacion { get; set; }
        public short diashabiles { get; set; }
        public short activa { get; set; }
        public short requiere_documentacion { get; set; }
        public short dias_fijo { get; set; }
        public int cant_dias { get; set; }



        public RRHH_Tipos_licencias()
        {
            id = 0;
            descripcion_licencia = string.Empty;
            fecha_alta = DateTime.Now;
            es_paga = 0;
            descuentadias = 0;
            requiere_aprobacion = 0;
            diashabiles = 0;
            activa = 0;
            requiere_documentacion = 0;
            dias_fijo = 0;
            cant_dias = 0;
        }

        private static List<RRHH_Tipos_licencias> mapeo(SqlDataReader dr)
        {
            List<RRHH_Tipos_licencias> lst = new List<RRHH_Tipos_licencias>();
            RRHH_Tipos_licencias obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int descripcion_licencia = dr.GetOrdinal("descripcion_licencia");
                int fecha_alta = dr.GetOrdinal("fecha_alta");
                int es_paga = dr.GetOrdinal("es_paga");
                int descuentadias = dr.GetOrdinal("descuentadias");
                int requiere_aprobacion = dr.GetOrdinal("requiere_aprobacion");
                int diashabiles = dr.GetOrdinal("diashabiles");
                int activa = dr.GetOrdinal("activa");
                int requiere_documentacion = dr.GetOrdinal("requiere_documentacion");
                int dias_fijo = dr.GetOrdinal("dias_fijo");
                int cant_dias = dr.GetOrdinal("cant_dias");
                while (dr.Read())
                {
                    obj = new RRHH_Tipos_licencias();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(descripcion_licencia)) { obj.descripcion_licencia = dr.GetString(descripcion_licencia); }
                    if (!dr.IsDBNull(fecha_alta)) { obj.fecha_alta = dr.GetDateTime(fecha_alta); }
                    if (!dr.IsDBNull(es_paga)) { obj.es_paga = dr.GetInt16(es_paga); }
                    if (!dr.IsDBNull(descuentadias)) { obj.descuentadias = dr.GetInt16(descuentadias); }
                    if (!dr.IsDBNull(requiere_aprobacion)) { obj.requiere_aprobacion = dr.GetInt16(requiere_aprobacion); }
                    if (!dr.IsDBNull(diashabiles)) { obj.diashabiles = dr.GetInt16(diashabiles); }
                    if (!dr.IsDBNull(activa)) { obj.activa = dr.GetInt16(activa); }
                    if (!dr.IsDBNull(requiere_documentacion)) { obj.requiere_documentacion = dr.GetInt16(requiere_documentacion); }
                    if (!dr.IsDBNull(dias_fijo)) { obj.dias_fijo = dr.GetInt16(dias_fijo); }
                    if (!dr.IsDBNull(cant_dias)) { obj.cant_dias = dr.GetInt32(cant_dias); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<RRHH_Tipos_licencias> read()
        {
            try
            {
                List<RRHH_Tipos_licencias> lst = new List<RRHH_Tipos_licencias>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM RRHH_Tipos_licencias";
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

        public static RRHH_Tipos_licencias getByPk(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM RRHH_Tipos_licencias WHERE");
                sql.AppendLine("id = @id");
                RRHH_Tipos_licencias obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<RRHH_Tipos_licencias> lst = mapeo(dr);
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

        public static List<Combo> Tipos_licencias()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT id, descripcion_licencia
                                        FROM RRHH_Tipos_licencias 
                                        ORDER BY 1";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = Convert.ToString(dr.GetString(1)); }
                            //if (!dr.IsDBNull(2)) { obj.campo_enlace = string.Empty; }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int insert(RRHH_Tipos_licencias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO RRHH_Tipos_licencias(");
                sql.AppendLine("descripcion_licencia");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(", es_paga");
                sql.AppendLine(", descuentadias");
                sql.AppendLine(", requiere_aprobacion, diashabiles");
                sql.AppendLine(", activa");
                sql.AppendLine(", requiere_documentacion");
                sql.AppendLine(", dias_fijo");
                sql.AppendLine(", cant_dias");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@descripcion_licencia");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(", @es_paga");
                sql.AppendLine(", @descuentadias");
                sql.AppendLine(", @requiere_aprobacion, @diashabiles");
                sql.AppendLine(", @activa");
                sql.AppendLine(", @requiere_documentacion");
                sql.AppendLine(", @dias_fijo");
                sql.AppendLine(", @cant_dias");

                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@descripcion_licencia", obj.descripcion_licencia);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@es_paga", obj.es_paga);
                    cmd.Parameters.AddWithValue("@descuentadias", obj.descuentadias);
                    cmd.Parameters.AddWithValue("@requiere_aprobacion", obj.requiere_aprobacion);
                    cmd.Parameters.AddWithValue("@diashabiles", obj.diashabiles);
                    cmd.Parameters.AddWithValue("@activa", obj.activa);
                    cmd.Parameters.AddWithValue("@requiere_documentacion", obj.requiere_documentacion);
                    cmd.Parameters.AddWithValue("@dias_fijo", obj.dias_fijo);
                    cmd.Parameters.AddWithValue("@cant_dias", obj.cant_dias);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(RRHH_Tipos_licencias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Rrhh_tipos_licencias SET");
                sql.AppendLine("descripcion_licencia=@descripcion_licencia");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine(", es_paga=@es_paga");
                sql.AppendLine(", descuentadias=@descuentadias");
                sql.AppendLine(", requiere_aprobacion=@requiere_aprobacion");
                sql.AppendLine(", diashabiles=@diashabiles");
                sql.AppendLine(", activa=@activa");
                sql.AppendLine(", requiere_documentacion=@requiere_documentacion");
                sql.AppendLine(", dias_fijo=@dias_fijo");
                sql.AppendLine(", cant_dias=@cant_dias");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@descripcion_licencia", obj.descripcion_licencia);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@es_paga", obj.es_paga);
                    cmd.Parameters.AddWithValue("@descuentadias", obj.descuentadias);
                    cmd.Parameters.AddWithValue("@requiere_aprobacion", obj.requiere_aprobacion);
                    cmd.Parameters.AddWithValue("@diashabiles", obj.diashabiles);
                    cmd.Parameters.AddWithValue("@activa", obj.activa);
                    cmd.Parameters.AddWithValue("@requiere_documentacion", obj.requiere_documentacion);
                    cmd.Parameters.AddWithValue("@dias_fijo", obj.dias_fijo);
                    cmd.Parameters.AddWithValue("@cant_dias", obj.cant_dias);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(RRHH_Tipos_licencias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  RRHH_Tipos_licencias ");
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

    }
}

