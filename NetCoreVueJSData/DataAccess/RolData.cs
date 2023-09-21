using Microsoft.EntityFrameworkCore;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSData.Interface;
using NetCoreVueJSModels.Accesos;
using NetCoreVueJSModels.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSData.DataAccess
{
    public class RolData : IRolData
    {
        string DBExMessage = "Something went awfully wrong while trying to reach Database: ";

        private readonly DBContextSys _context;
        public RolData(DBContextSys context)
        {
            _context = context;
        }
        public async Task<List<CRol>> Get(bool isValList = false)
        {
            try
            {
                if (isValList) {
                    return await _context.roles.ToListAsync();
                }
                else
                {
                    return await _context.roles.Where(x => x.condicion).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(DBExMessage + ex.GetBaseException());
            }
        }

    }
}
