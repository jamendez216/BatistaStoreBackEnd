using Microsoft.EntityFrameworkCore;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSData.Interface;
using NetCoreVueJSModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSData.DataAccess
{
    public class SubjectData : ISubjectData
    {
        private readonly DBContextSys _context;
        public SubjectData(DBContextSys context)
        {
            this._context = context;
        }

        public async Task Create(CPerson model)
        {
            try
            {
                await _context.personas.AddAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Edit()
        {
            await _context.SaveChangesAsync();
        }

        public bool EmailExists(string email)
        {
            return _context.personas.Any(x => x.email == email);
        }

        public async Task<IEnumerable<CPerson>> Get()
        {
            try
            {
                return await _context.personas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CPerson> Get(int id)
        {
            try
            {
                return await _context.personas.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task ToggleActivation(int id)
        {
            throw new NotImplementedException();
        }
    }
}
