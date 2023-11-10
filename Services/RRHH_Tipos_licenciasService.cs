using RRHHBack.Entities.RRHH;

namespace RRHHBack.Services
{
    public class RRHH_Tipos_licenciasService : IRRHH_Tipos_licenciasService
    {
        public RRHH_Tipos_licencias getByPk(int id)
        {
            try
            {
                return RRHH_Tipos_licencias.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<RRHH_Tipos_licencias> read()
        {
            try
            {
                return RRHH_Tipos_licencias.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(RRHH_Tipos_licencias obj)
        {
            try
            {
                return RRHH_Tipos_licencias.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(RRHH_Tipos_licencias obj)
        {
            try
            {
                RRHH_Tipos_licencias.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(RRHH_Tipos_licencias obj)
        {
            try
            {
                RRHH_Tipos_licencias.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}

