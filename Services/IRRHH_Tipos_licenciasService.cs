using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHHBack.Entities.RRHH;

namespace RRHHBack.Services
{
    public interface IRRHH_Tipos_licenciasService
    {
        public List<RRHH_Tipos_licencias> read();
        public RRHH_Tipos_licencias getByPk(int id);
        public int insert(RRHH_Tipos_licencias obj);
        public void update(RRHH_Tipos_licencias obj);
        public void delete(RRHH_Tipos_licencias obj);
        

    }
}

