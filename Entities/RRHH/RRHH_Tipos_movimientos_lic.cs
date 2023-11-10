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
    public class RRHH_Tipos_movimientos_lic : DALBase
    {
        public int id { get; set; }
        public string descripcion_movimiento { get; set; }
        public short activo { get; set; }
        public int suma { get; set; }
        public DateTime fecha_alta { get; set; }

        public RRHH_Tipos_movimientos_lic()
        {
            id = 0;
            descripcion_movimiento = string.Empty;
            activo = 0;
            suma = 0;
            fecha_alta = DateTime.Now;
        }

        private static List<RRHH_Tipos_movimientos_lic> mapeo(SqlDataReader dr)
        {
            List<RRHH_Tipos_movimientos_lic> lst = new List<RRHH_Tipos_movimientos_lic>();
            RRHH_Tipos_movimientos_lic obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int descripcion_movimiento = dr.GetOrdinal("descripcion_movimiento");
                int activo = dr.GetOrdinal("activo");
                int suma = dr.GetOrdinal("suma");
                int fecha_alta = dr.GetOrdinal("fecha_alta");
                while (dr.Read())
                {
                    obj = new RRHH_Tipos_movimientos_lic();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(descripcion_movimiento)) { obj.descripcion_movimiento = dr.GetString(descripcion_movimiento); }
                    if (!dr.IsDBNull(activo)) { obj.activo = dr.GetInt16(activo); }
                    if (!dr.IsDBNull(suma)) { obj.suma = dr.GetInt32(suma); }
                    if (!dr.IsDBNull(fecha_alta)) { obj.fecha_alta = dr.GetDateTime(fecha_alta); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<RRHH_Tipos_movimientos_lic> read()
        {
            try
            {
                List<RRHH_Tipos_movimientos_lic> lst = new List<RRHH_Tipos_movimientos_lic>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Rrhh_tipos_movimientos_lic";
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

        public static RRHH_Tipos_movimientos_lic GetByPk(int id)
        {
            try
            {
                string sql = @"SELECT * 
                              FROM RRHH_Tipos_movimientos_lic 
                              WHERE id=@id";
                RRHH_Tipos_movimientos_lic obj = new RRHH_Tipos_movimientos_lic();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<RRHH_Tipos_movimientos_lic> lst = mapeo(dr);
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

        public static int insert(RRHH_Tipos_movimientos_lic obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Rrhh_tipos_movimientos_lic(");
                sql.AppendLine("id");
                sql.AppendLine(", descripcion_movimiento");
                sql.AppendLine(", activo");
                sql.AppendLine(", suma");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id");
                sql.AppendLine(", @descripcion_movimiento");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @suma");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@descripcion_movimiento", obj.descripcion_movimiento);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@suma", obj.suma);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(RRHH_Tipos_movimientos_lic obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Rrhh_tipos_movimientos_lic SET");
                sql.AppendLine("id=@id");
                sql.AppendLine(", descripcion_movimiento=@descripcion_movimiento");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", suma=@suma");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@descripcion_movimiento", obj.descripcion_movimiento);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@suma", obj.suma);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(RRHH_Tipos_movimientos_lic obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Rrhh_tipos_movimientos_lic ");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Combo> Tipos_movimientos_lic()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT id, descripcion_movimiento
                                        FROM RRHH_Tipos_movimientos_lic 
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

    }
}

