using System.Data.SqlClient;
using System.Data;
using RRHHBack.Entities;
using System.Globalization;

namespace RRHHBack.Entities.RRHH
{
    public class Aprobadores
    {

        public int legajo { get; set; } = 0;
        public string cuil { get; set; } = string.Empty;
        public DateTime? fecha_ingreso { get; set; } = null;
        public string nombre { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string celular { get; set; } = string.Empty;
        public int cod_categoria { get; set; } = 0;
        public int cod_clasif_per { get; set; } = 0;
        public int id_secretaria { get; set; } = 0;
        public int id_direccion { get; set; } = 0;
        public int id_oficina { get; set; } = 0;
        public Aprobadores() { }
        private static List<Aprobadores> mapeo(SqlDataReader dr)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            List<Aprobadores> lst = new List<Aprobadores>();
            Aprobadores obj;
            if (dr.HasRows)
            {
                int legajo = dr.GetOrdinal("legajo");
                int cuil = dr.GetOrdinal("cuil");
                int fecha_ingreso = dr.GetOrdinal("fecha_ingreso");
                int nombre = dr.GetOrdinal("nombre");
                int email = dr.GetOrdinal("email");
                int celular = dr.GetOrdinal("celular");
                int cod_categoria = dr.GetOrdinal("cod_categoria");
                int cod_clasif_per = dr.GetOrdinal("cod_clasif_per");
                int id_secretaria = dr.GetOrdinal("id_secretaria");
                int id_direccion = dr.GetOrdinal("id_direccion");
                int id_oficina = dr.GetOrdinal("id_oficina");
                while (dr.Read())
                {
                    obj = new Aprobadores();
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(cuil)) { obj.cuil = dr.GetString(cuil); }
                    if (!dr.IsDBNull(fecha_ingreso)) { obj.fecha_ingreso = Convert.ToDateTime(dr.GetDateTime(fecha_ingreso), culturaFecArgentina); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    if (!dr.IsDBNull(email)) { obj.email = dr.GetString(email); }
                    if (!dr.IsDBNull(celular)) { obj.celular = dr.GetString(celular); }
                    if (!dr.IsDBNull(cod_categoria)) { obj.cod_categoria = dr.GetInt32(cod_categoria); }
                    if (!dr.IsDBNull(cod_clasif_per)) { obj.cod_clasif_per = dr.GetInt32(cod_clasif_per); }
                    if (!dr.IsDBNull(id_secretaria)) { obj.id_secretaria = dr.GetInt32(id_secretaria); }
                    if (!dr.IsDBNull(id_direccion)) { obj.id_direccion = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(id_oficina)) { obj.id_oficina = dr.GetInt32(id_oficina); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static Aprobadores GetAprobadorByLegajo(int legajo)
        {
            try
            {
                string sql = @"SELECT legajo, cuil, fecha_ingreso, nombre, email, celular, cod_categoria, cod_clasif_per,
                                id_secretaria, id_direccion, id_oficina
                               FROM RRHH_APROBADORES
                               WHERE legajo=@legajo";
                //string sqlWhere = "";
                Aprobadores? obj = null;
                using (SqlConnection con = DALBase.GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Aprobadores> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Aprobadores> GetAprobadoresBySecretaria(int id_secretaria, int id_direccion)
        {
            try
            {
                string sql = @"SELECT legajo, cuil, fecha_ingreso, nombre, email, celular, cod_categoria, 
                                   cod_clasif_per, id_secretaria, id_direccion, id_oficina
                               FROM RRHH_APROBADORES
                               WHERE 
                               cod_categoria>=24 AND
                               id_secretaria=@id_secretaria AND
                               id_direccion=@id_direccion";
                List<Aprobadores> lst = new();
                using (SqlConnection con = DALBase.GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_secretaria", id_secretaria);
                    cmd.Parameters.AddWithValue("@id_direccion", id_direccion);
                    cmd.CommandText = sql.ToString();
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
        public static List<Aprobadores> GetAprobadoresAll()
        {
            try
            {
                //WHERE fecha_baja is null AND legajo in (377, 710, 836)
                string sql = @"SELECT legajo, cuil, fecha_ingreso, nombre, email, celular, cod_categoria, 
                                   cod_clasif_per, id_secretaria, id_direccion, id_oficina
                               FROM RRHH_APROBADORES
                               ORDER BY cod_clasif_per desc";
                List<Aprobadores> lst = new();
                using (SqlConnection con = DALBase.GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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


    }
}
