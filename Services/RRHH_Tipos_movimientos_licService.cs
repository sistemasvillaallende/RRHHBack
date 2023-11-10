using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using RRHHBack.Entities.RRHH;

namespace RRHHBack.Services
{
    public class Rrhh_tipos_movimientos_licService : IRRHH_Tipos_movimientos_licService
    {
        public RRHH_Tipos_movimientos_lic GetByPk(int id)
        {
            try
            {
                return RRHH_Tipos_movimientos_lic.GetByPk(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<RRHH_Tipos_movimientos_lic> read()
        {
            try
            {
                return RRHH_Tipos_movimientos_lic.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(RRHH_Tipos_movimientos_lic obj)
        {
            try
            {
                return RRHH_Tipos_movimientos_lic.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(RRHH_Tipos_movimientos_lic obj)
        {
            try
            {
                RRHH_Tipos_movimientos_lic.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(RRHH_Tipos_movimientos_lic obj)
        {
            try
            {
                RRHH_Tipos_movimientos_lic.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

