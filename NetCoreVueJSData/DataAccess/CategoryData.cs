using Microsoft.EntityFrameworkCore;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSData.Interface;
using NetCoreVueJSModels.Almacen;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSData.DataAccess
{
    public class CategoryData : ICategoryData
    {
        string DBExMessage = "Something went awfully wrong while trying to reach Database: ";
        private readonly DBContextSys _context;
        public CategoryData(DBContextSys context)
        {
            _context = context;
        }

        public async Task Create(CCategoria category)
        {
            _context.Add(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(DBExMessage + ex.GetBaseException());
            }
        }

        public async Task<List<CCategoria>> Get()
        {
            try
            {
                var categorias = await _context.categorias.ToListAsync();
                return categorias;
            }
            catch (Exception ex)
            {
                throw new Exception(DBExMessage + ex.GetBaseException());
            }
        }
        public async Task<CCategoria> Get(int? id)
        {
            try
            {
                return await _context.categorias.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(DBExMessage + ex.GetBaseException());
            }
        }

        public async Task<bool> CategoryExists(int id)
        {
            try
            {
                return await _context.categorias.AnyAsync(x => x.idcategoria == id);
            }
            catch (Exception ex)
            {
                throw new Exception(DBExMessage + ex.GetBaseException());
            }
        }

        public async Task Edit(CCategoria cCategoria)
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(DBExMessage + ex.GetBaseException());
            }
        }

        public async Task Delete (CCategoria category)
        {

            try
            {
                _context.categorias.Remove(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(DBExMessage + ex.GetBaseException());
            }
        }

        public async Task ToggleActivation(CCategoria id)
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(DBExMessage + ex.GetBaseException());
            }
        }
    }
}
