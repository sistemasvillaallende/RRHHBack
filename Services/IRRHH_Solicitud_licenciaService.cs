using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHHBack.Entities.RRHH;
using RRHHBack.Library;

namespace RRHHBack.Services
{
    public interface IRRHH_Solicitud_licenciaService
    {
        public List<RRHH_Solicitud_licencia> read();
        public RRHH_Solicitud_licencia getByPk();
        public int insert(RRHH_Solicitud_licencia obj);
        public void update(RRHH_Solicitud_licencia obj);
        public void delete(RRHH_Solicitud_licencia obj);
        public List<Combo> Tipos_licencias();
        public List<Combo> Tipos_movimientos_lic();
        public List<RRHH_Solicitud_licencia> Solicitudes_paginado(string buscarPor, string strParametro,
            int registro_desde, int registro_hasta);
        public int Count(string buscarPor, string strParametro);
        public List<Aprobadores> GetAprobadoresBySecretaria(int id_secretaria, int id_direccion);
        public List<Aprobadores> GetAprobadoresAll();
        public List<RRHH_Solicitud_licencia> GetSolicitudPorAprobador(int id_aprobador);
        public Aprobadores GetAprobadorByLegajo(int legajo);
        public Licencia GetDatosLicenciaByEmpleado(int legajo);
        public void RechazarSolicitud(int id, int legajo, int id_aprobador, string obs);
        public void AprobarSolicitud(int id, int legajo, int id_aprobador, string obs);
    }
}

