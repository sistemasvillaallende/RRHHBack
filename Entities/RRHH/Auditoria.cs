using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHHBack.Entities.RRHH
{
    public class Auditoria
    {
        public int id_auditoria { get; set; }
        public string fecha_movimiento { get; set; }
        public string usuario { get; set; }
        public string menu { get; set; }
        public string proceso { get; set; }
        public string identificacion { get; set; }
        public string autorizaciones { get; set; }
        public string observaciones { get; set; }
        public string detalle { get; set; }
        public Auditoria()
        {
            id_auditoria = 0;
            fecha_movimiento = DateTime.Today.ToShortDateString();
            usuario = string.Empty;
            menu = string.Empty;
            proceso = string.Empty;
            identificacion = string.Empty;
            autorizaciones = string.Empty;
            observaciones = string.Empty;
            detalle = string.Empty;
        }

        public static void Insert_movimiento(string fecha_movimiento, string usuario, string menu,
           string proceso, string identificacion, string autorizaciones, string observaciones, string detalle)
        {
            using (SqlConnection cn = DALBase.GetConnection("SIIMVA"))
            {
                SqlCommand? cmdInsert = null;
                SqlCommand? cmd = null;
                int id = 0;
                try
                {
                    string SQL = @"SELECT isnull(max(id_auditoria),0)  As id
                                FROM MOVIMIENTOS_SPW  (nolock)";
                    cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
                    cmd.Connection.Open();
                    id = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    string SQLAudita = @"INSERT INTO MOVIMIENTOS_SPW
                                    (id_auditoria, fecha_movimiento,
                                    usuario, menu, proceso,
                                    identificacion, autorizaciones,
                                    observaciones, detalle)
                                    VALUES
                                    (@id_auditoria, @fecha_movimiento,
                                    @usuario, @menu, @proceso,
                                    @identificacion, @autorizaciones, @detalle)";
                    cmdInsert = cn.CreateCommand();
                    cmdInsert.CommandType = CommandType.Text;
                    cmdInsert.CommandText = SQLAudita;
                    cmdInsert.Parameters.AddWithValue("@id_auditoria", id);
                    cmdInsert.Parameters.AddWithValue("@fecha_movimiento", fecha_movimiento);
                    cmdInsert.Parameters.AddWithValue("@usuario", usuario);
                    cmdInsert.Parameters.AddWithValue("@menu", menu);
                    cmdInsert.Parameters.AddWithValue("@proceso", proceso);
                    cmdInsert.Parameters.AddWithValue("@identificacion", identificacion);
                    cmdInsert.Parameters.AddWithValue("@autorizaciones", autorizaciones);
                    cmdInsert.Parameters.AddWithValue("@observaciones", observaciones);
                    cmdInsert.Parameters.AddWithValue("@detalle", detalle);
                    cmdInsert.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static void Insert_movimiento(Auditoria oAudita)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            using (SqlConnection cn = DALBase.GetConnection("SIIMVA"))
            {
                SqlCommand? cmdInsert = null;
                SqlCommand? cmd = null;
                int id = 0;
                try
                {
                    string SQL = @"SELECT isnull(max(id_auditoria),0)  As id
                                FROM MOVIMIENTOS_SPW  (nolock)";
                    cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
                    cmd.Connection.Open();
                    id = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    string SQLAudita = @"
                                    INSERT INTO MOVIMIENTOS_SPW
                                    (id_auditoria, fecha_movimiento,
                                    usuario, menu, proceso,
                                    identificacion, autorizaciones,
                                    observaciones, detalle)
                                    VALUES
                                    (@id_auditoria, @fecha_movimiento,
                                    @usuario, @menu, @proceso,
                                    @identificacion, @autorizaciones, @observaciones, @detalle)";
                    cmdInsert = cn.CreateCommand();
                    cmdInsert.CommandType = CommandType.Text;
                    cmdInsert.CommandText = SQLAudita;
                    cmdInsert.Parameters.AddWithValue("@id_auditoria", id);
                    cmdInsert.Parameters.AddWithValue("@fecha_movimiento",
                        Convert.ToDateTime(oAudita.fecha_movimiento, culturaFecArgentina));
                    cmdInsert.Parameters.AddWithValue("@usuario", oAudita.usuario);
                    cmdInsert.Parameters.AddWithValue("@menu", oAudita.menu);
                    cmdInsert.Parameters.AddWithValue("@proceso", oAudita.proceso);
                    cmdInsert.Parameters.AddWithValue("@identificacion", oAudita.identificacion);
                    cmdInsert.Parameters.AddWithValue("@autorizaciones", oAudita.autorizaciones);
                    cmdInsert.Parameters.AddWithValue("@observaciones", oAudita.observaciones);
                    cmdInsert.Parameters.AddWithValue("@detalle", oAudita.detalle);
                    cmdInsert.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

    }
}
