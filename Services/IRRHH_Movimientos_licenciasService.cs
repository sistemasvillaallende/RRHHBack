using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHHBack.Entities.RRHH;

namespace RRHHBack.Services
{
    public interface IRRHH_Movimientos_licenciasService
    {
        public List<RRHH_Movimientos_licencias> read();
        public RRHH_Movimientos_licencias GetByPk(int id_tipo_movimiento, int legajo);
        public RRHH_Movimientos_licencias GetByID(int id);
        public int insert(RRHH_Movimientos_licencias obj);
        public void update(RRHH_Movimientos_licencias obj);
        public void delete(RRHH_Movimientos_licencias obj);
        public List<RRHH_Movimientos_licencias> Movimientos_licencias_paginado(string buscarPor, string strParametro,
           int registro_desde, int registro_hasta);
        public int Count();
        public void Liquida_licencias_anuales(DateTime fecha_hoy, string usuario);
        public int InsertMovimientoManual(RRHH_Movimientos_licencias obj);
        
    }
}

