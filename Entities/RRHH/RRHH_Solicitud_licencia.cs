using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RRHHBack.Entities.RRHH
{
    public class RRHH_Solicitud_licencia : DALBase
    {
        public int id { get; set; }
        public int id_tipo_licencia { get; set; }
        public DateTime fecha_alta { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public string observaciones { get; set; }
        public int legajo { get; set; }
        public string cuit { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public int total_dias { get; set; }
        public short cod_estado { get; set; }
        public short aprobado { get; set; }
        public short id_secretaria { get; set; }
        public short id_direccion { get; set; }
        public short id_oficina { get; set; }
        public short id_aprobador { get; set; }
        public string obs_rechazado { get; set; }
        public DateTime fecha_aprobacion { get; set; }
        public DateTime fecha_rechazo { get; set; }

        public RRHH_Solicitud_licencia()
        {
            id = 0;
            id_tipo_licencia = 0;
            fecha_alta = DateTime.Now;
            fecha_solicitud = DateTime.Now;
            observaciones = string.Empty;
            legajo = 0;
            cuit = string.Empty;
            fecha_inicio = DateTime.Now;
            fecha_fin = DateTime.Now;
            total_dias = 0;
            cod_estado = 0;
            aprobado = 0;
            id_secretaria = 0;
            id_direccion = 0;
            id_oficina = 0;
            id_aprobador = 0;
            obs_rechazado = string.Empty;
        }
        private static List<RRHH_Solicitud_licencia> mapeo(SqlDataReader dr)
        {
            List<RRHH_Solicitud_licencia> lst = new List<RRHH_Solicitud_licencia>();
            RRHH_Solicitud_licencia obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int id_tipo_licencia = dr.GetOrdinal("id_tipo_licencia");
                int fecha_alta = dr.GetOrdinal("fecha_alta");
                int fecha_solicitud = dr.GetOrdinal("fecha_solicitud");
                int observaciones = dr.GetOrdinal("observaciones");
                int legajo = dr.GetOrdinal("legajo");
                int cuit = dr.GetOrdinal("cuit");
                int fecha_inicio = dr.GetOrdinal("fecha_inicio");
                int fecha_fin = dr.GetOrdinal("fecha_fin");
                int total_dias = dr.GetOrdinal("total_dias");
                int cod_estado = dr.GetOrdinal("cod_estado");
                int aprobado = dr.GetOrdinal("aprobado");
                int id_secretaria = dr.GetOrdinal("id_secretaria");
                int id_direccion = dr.GetOrdinal("id_direccion");
                int id_oficina = dr.GetOrdinal("id_oficina");
                int id_aprobador = dr.GetOrdinal("id_aprobador");
                int obs_rechazado = dr.GetOrdinal("obs_rechazado");
                int fecha_aprobacion = dr.GetOrdinal("fecha_aprobacion");
                int fecha_rechazo = dr.GetOrdinal("fecha_rechazo");
                while (dr.Read())
                {
                    obj = new RRHH_Solicitud_licencia();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(id_tipo_licencia)) { obj.id_tipo_licencia = dr.GetInt32(id_tipo_licencia); }
                    if (!dr.IsDBNull(fecha_alta)) { obj.fecha_alta = dr.GetDateTime(fecha_alta); }
                    if (!dr.IsDBNull(fecha_solicitud)) { obj.fecha_solicitud = dr.GetDateTime(fecha_solicitud); }
                    if (!dr.IsDBNull(observaciones)) { obj.observaciones = dr.GetString(observaciones); }
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(cuit)) { obj.cuit = dr.GetString(cuit); }
                    if (!dr.IsDBNull(fecha_inicio)) { obj.fecha_inicio = dr.GetDateTime(fecha_inicio); }
                    if (!dr.IsDBNull(fecha_fin)) { obj.fecha_fin = dr.GetDateTime(fecha_fin); }
                    if (!dr.IsDBNull(total_dias)) { obj.total_dias = dr.GetInt32(total_dias); }
                    if (!dr.IsDBNull(cod_estado)) { obj.cod_estado = dr.GetInt16(cod_estado); }
                    if (!dr.IsDBNull(aprobado)) { obj.aprobado = dr.GetInt16(aprobado); }
                    if (!dr.IsDBNull(id_secretaria)) { obj.id_secretaria = dr.GetInt16(id_secretaria); }
                    if (!dr.IsDBNull(id_direccion)) { obj.id_direccion = dr.GetInt16(id_direccion); }
                    if (!dr.IsDBNull(id_oficina)) { obj.id_oficina = dr.GetInt16(id_oficina); }
                    if (!dr.IsDBNull(id_aprobador)) { obj.id_aprobador = dr.GetInt16(id_aprobador); }
                    if (!dr.IsDBNull(obs_rechazado)) { obj.obs_rechazado = dr.GetString(obs_rechazado); }
                    if (!dr.IsDBNull(fecha_aprobacion)) { obj.fecha_aprobacion = dr.GetDateTime(fecha_aprobacion); }
                    if (!dr.IsDBNull(fecha_rechazo)) { obj.fecha_rechazo = dr.GetDateTime(fecha_rechazo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<RRHH_Solicitud_licencia> read()
        {
            try
            {
                List<RRHH_Solicitud_licencia> lst = new List<RRHH_Solicitud_licencia>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM RRHH_solicitud_licencia";
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
        public static RRHH_Solicitud_licencia getByPk()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Rrhh_solicitud_licencia WHERE");
                RRHH_Solicitud_licencia obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<RRHH_Solicitud_licencia> lst = mapeo(dr);
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
        public static int insert(RRHH_Solicitud_licencia obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO RRHH_Solicitud_licencia(");
                sql.AppendLine("id");
                sql.AppendLine(", id_tipo_licencia");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(", fecha_solicitud");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", legajo");
                sql.AppendLine(", cuit");
                sql.AppendLine(", fecha_inicio");
                sql.AppendLine(", fecha_fin");
                sql.AppendLine(", total_dias");
                sql.AppendLine(", cod_estado");
                sql.AppendLine(", aprobado");
                sql.AppendLine(", id_secretaria");
                sql.AppendLine(", id_direccion");
                sql.AppendLine(", id_oficina");
                sql.AppendLine(", id_aprobador");
                sql.AppendLine(", obs_rechazado");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id");
                sql.AppendLine(", @id_tipo_licencia");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(", @fecha_solicitud");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @legajo");
                sql.AppendLine(", @cuit");
                sql.AppendLine(", @fecha_inicio");
                sql.AppendLine(", @fecha_fin");
                sql.AppendLine(", @total_dias");
                sql.AppendLine(", @cod_estado");
                sql.AppendLine(", @aprobado");
                sql.AppendLine(", @id_secretaria");
                sql.AppendLine(", @id_direccion");
                sql.AppendLine(", @id_oficina");
                sql.AppendLine(", @id_aprobador");
                sql.AppendLine(", @obs_rechazado");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@id_tipo_licencia", obj.id_tipo_licencia);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@fecha_solicitud", obj.fecha_solicitud);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@fecha_inicio", obj.fecha_inicio);
                    cmd.Parameters.AddWithValue("@fecha_fin", obj.fecha_fin);
                    cmd.Parameters.AddWithValue("@total_dias", obj.total_dias);
                    cmd.Parameters.AddWithValue("@cod_estado", obj.cod_estado);
                    cmd.Parameters.AddWithValue("@aprobado", obj.aprobado);
                    cmd.Parameters.AddWithValue("@id_secretaria", obj.id_secretaria);
                    cmd.Parameters.AddWithValue("@id_direccion", obj.id_direccion);
                    cmd.Parameters.AddWithValue("@id_oficina", obj.id_oficina);
                    cmd.Parameters.AddWithValue("@id_aprobador", obj.id_aprobador);
                    cmd.Parameters.AddWithValue("@obs_rechazado", obj.obs_rechazado);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void update(RRHH_Solicitud_licencia obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  RRHH_Solicitud_licencia SET");
                sql.AppendLine("id=@id");
                sql.AppendLine(", id_tipo_licencia=@id_tipo_licencia");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine(", fecha_solicitud=@fecha_solicitud");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", legajo=@legajo");
                sql.AppendLine(", cuit=@cuit");
                sql.AppendLine(", fecha_inicio=@fecha_inicio");
                sql.AppendLine(", fecha_fin=@fecha_fin");
                sql.AppendLine(", total_dias=@total_dias");
                sql.AppendLine(", cod_estado=@cod_estado");
                sql.AppendLine(", aprobado=@aprobado");
                sql.AppendLine(", id_secretaria=@id_secretaria");
                sql.AppendLine(", id_direccion=@id_direccion");
                sql.AppendLine(", id_oficina=@id_oficina");
                sql.AppendLine(", id_aprobador=@id_aprobador");
                sql.AppendLine(", obs_rechazado=@obs_rechazado");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@id_tipo_licencia", obj.id_tipo_licencia);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@fecha_solicitud", obj.fecha_solicitud);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@fecha_inicio", obj.fecha_inicio);
                    cmd.Parameters.AddWithValue("@fecha_fin", obj.fecha_fin);
                    cmd.Parameters.AddWithValue("@total_dias", obj.total_dias);
                    cmd.Parameters.AddWithValue("@cod_estado", obj.cod_estado);
                    cmd.Parameters.AddWithValue("@aprobado", obj.aprobado);
                    cmd.Parameters.AddWithValue("@id_secretaria", obj.id_secretaria);
                    cmd.Parameters.AddWithValue("@id_direccion", obj.id_direccion);
                    cmd.Parameters.AddWithValue("@id_oficina", obj.id_oficina);
                    cmd.Parameters.AddWithValue("@id_aprobador", obj.id_aprobador);
                    cmd.Parameters.AddWithValue("@obs_rechazado", obj.obs_rechazado);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(RRHH_Solicitud_licencia obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  RRHH_Solicitud_licencia ");
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
                throw;
            }
        }
        public static List<RRHH_Solicitud_licencia> Solicitudes_paginado(string buscarPor, string strParametro,
             int registro_desde, int registro_hasta)
        {
            try
            {
                bool busquedaSi = false;
                List<RRHH_Solicitud_licencia> lst = new List<RRHH_Solicitud_licencia>();
                string strSQL = @"SELECT * 
                                  FROM RRHH_solicitud_licencia";
                string sqlWhere = "";
                if (!string.IsNullOrEmpty(buscarPor))
                {
                    switch (buscarPor)
                    {
                        case "id_tipo_licencia":
                            sqlWhere = @" WHERE
                                id_tipo_licencia=Convert(int,@parametro) AND
                                id BETWEEN @desde AND @hasta
                                ORDER By fecha_alta";
                            break;
                        case "cuit":
                            sqlWhere = @" WHERE
                                cuit=Convert(varchar(11),@parametro) AND
                                id BETWEEN @desde AND @hasta
                                ORDER By fecha_alta";
                            break;
                        case "legajo":
                            sqlWhere = @" WHERE
                                legajo=Convert(int, @parametro) AND
                                id BETWEEN @desde AND @hasta
                                ORDER By fecha_alta";
                            break;
                        case "id_oficina_aprobador":
                            sqlWhere = @" WHERE
                                id_oficina_aprobador=Convert(int,@parametro) AND
                                id BETWEEN @desde AND @hasta
                                ORDER By fecha_alta";
                            break;
                        case "fecha_solicitud":
                            sqlWhere = @" WHERE
                                fecha_solicitud=Convert(Date(),@parametro) AND
                                id BETWEEN @desde AND @hasta
                                ORDER By fecha_alta";
                            break;
                        case "id_aprobador":
                            sqlWhere = @" WHERE
                                id_aprobador=@parametro AND
                                id BETWEEN @desde AND @hasta
                                ORDER By fecha_alta";
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
                    strSQL += " WHERE id BETWEEN @desde AND @hasta ORDER By fecha_alta";
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
        public static int Count(string buscarPor, string strParametro)
        {
            try
            {
                int count = 0;
                bool busquedaSi = false;
                string strSQL = @"SELECT count(*) 
                               FROM RRHH_SOLICITUD_LICENCIA (nolock)";
                string sqlWhere = "";
                if (!string.IsNullOrEmpty(buscarPor))
                {
                    switch (buscarPor)
                    {
                        case "id_tipo_licencia":
                            sqlWhere = @" WHERE
                                id_tipo_licencia=Convert(int,@parametro)";
                            break;
                        case "cuit":
                            sqlWhere = @" WHERE
                                cuit=Convert(varchar(11),@parametro)";
                            break;
                        case "legajo":
                            sqlWhere = @" WHERE
                                legajo=Convert(int, @parametro)";
                            break;
                        case "id_oficina_aprobador":
                            sqlWhere = @" WHERE
                                id_oficina_aprobador=Convert(int,@parametro)";
                            break;
                        case "fecha_solicitud":
                            sqlWhere = @" WHERE
                                fecha_solicitud=Convert(Date(),@parametro)";
                            break;
                        case "id_aprobador":
                            sqlWhere = @" WHERE
                                id_aprobador=Convert(int,@parametro)";
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
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    if (busquedaSi)
                    {
                        cmd.Parameters.AddWithValue("@parametro", strParametro);
                    }
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
        public static List<RRHH_Solicitud_licencia> GetSolicitudPorAprobador(int id_aprobador)
        {
            try
            {
                string sql = @"SELECT *
                               FROM RRHH_Solicitud_licencia 
                               WHERE id_aprobador=@id_aprobador";
                List<RRHH_Solicitud_licencia> lst = new List<RRHH_Solicitud_licencia>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_aprobador", id_aprobador);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void AprobarSolicitud(int id, int legajo, int id_aprobador, string obs)
        {
            try
            {
                string sql = @"UPDATE RRHH_Solicitud_licencia SET 
                                 aprobado=1, fecha_aprobacion=GETDATE(),
                                 id_aprobador=@id_aprobador
                               FROM RRHH_APROBADORES
                               WHERE id=@id AND
                                     legajo=@legajo";
                using (SqlConnection con = DALBase.GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@id_aprobador", id_aprobador);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void RechazarSolicitud(int id, int legajo, int id_aprobador, string obs)
        {
            try
            {
                string sql = @"UPDATE RRHH_Solicitud_licencia SET 
                                 aprobado=0, fecha_rechazo=GETDATE(),
                                 id_aprobador=@id_aprobador,
                                 obs_rechazado=@obs
                               FROM RRHH_APROBADORES
                               WHERE id=@id AND
                                     legajo=@legajo";
                using (SqlConnection con = DALBase.GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@id_aprobador", id_aprobador);
                    cmd.Parameters.AddWithValue("@obs", obs);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

