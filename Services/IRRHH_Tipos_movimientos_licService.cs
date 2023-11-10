using RRHHBack.Entities.RRHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace RRHHBack.Services
{
    public interface IRRHH_Tipos_movimientos_licService
    {
        public List<RRHH_Tipos_movimientos_lic> read();
        public RRHH_Tipos_movimientos_lic GetByPk(int id);
        public int insert(RRHH_Tipos_movimientos_lic obj);
        public void update(RRHH_Tipos_movimientos_lic obj);
        public void delete(RRHH_Tipos_movimientos_lic obj);
    }
}

