using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHHBack.Entities.RRHH;

namespace RRHHBack.Services
{
    public interface IRRHH_Seteo_licenciasService
    {
        public List<RRHH_Seteo_licencias> read();
        public RRHH_Seteo_licencias getByPk(int id);
        public int insert(RRHH_Seteo_licencias obj);
        public void update(RRHH_Seteo_licencias obj);
        public void delete(RRHH_Seteo_licencias obj);
    }
}

