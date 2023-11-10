using RRHHBack.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace RRHHBack.Entities.RRHH
{
    public class Licencia
    {
        public int legajo { get; set; }
        public int licenciagenerada { get; set; }
        public int licenciadisponible { get; set; }
        public int licenciausadas { get; set; }
        public int razonesparticulares { get; set; }
        public Licencia()
        {
            legajo = 0;
            licenciagenerada = 0;
            licenciadisponible = 0;
            licenciausadas = 0;
            razonesparticulares = 0;
        }

        private static List<Licencia> mapeo(SqlDataReader dr)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            List<Licencia> lst = new List<Licencia>();
            Licencia obj;
            if (dr.HasRows)
            {
                int legajo = dr.GetOrdinal("legajo");
                int licenciagenerada = dr.GetOrdinal("licenciagenerada");
                int licenciadisponible = dr.GetOrdinal("licenciadisponible");
                int licenciausadas = dr.GetOrdinal("licenciausadas");
                int razonesparticulares = dr.GetOrdinal("razonesparticulares");
                while (dr.Read())
                {
                    obj = new Licencia();
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(licenciagenerada)) { obj.licenciagenerada = dr.GetInt32(licenciagenerada); }
                    if (!dr.IsDBNull(licenciadisponible)) { obj.licenciadisponible = dr.GetInt32(licenciadisponible); }
                    if (!dr.IsDBNull(licenciausadas)) { obj.licenciadisponible = dr.GetInt32(licenciadisponible); }
                    if (!dr.IsDBNull(razonesparticulares)) { obj.razonesparticulares = dr.GetInt32(razonesparticulares); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static Licencia GetDatosLicenciaByEmpleado(int legajo)
        {
            try
            {
                string sql = @"SELECT legajo, licenciagenerada, licenciadisponible, 
                                      licenciausadas, razonesparticulares
                               FROM EMPLEADOS
                               WHERE legajo=@legajo";
                Licencia? obj = new Licencia();
                List<Licencia> lst = new List<Licencia>();
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
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


    }
}
