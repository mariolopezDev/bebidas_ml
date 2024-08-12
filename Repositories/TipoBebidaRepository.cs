using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bebidas_ML.Data;
using Bebidas_ML.Models;

namespace Bebidas_ML.Repositories
{
    public class TipoBebidaRepository : ITipoBebidaRepository
    {
        private readonly BebidasDbContext _context;

        public TipoBebidaRepository(BebidasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoBebida>> GetAllTiposBebidasAsync()
        {
            return await _context.TiposBebida.ToListAsync();
        }

        public async Task<TipoBebida?> GetTipoBebidaByIdAsync(int id)
        {
            return await _context.TiposBebida.FindAsync(id);
        }

        public async Task<TipoBebida> CreateTipoBebidaAsync(TipoBebida tipoBebida)
        {
            _context.TiposBebida.Add(tipoBebida);
            await _context.SaveChangesAsync();
            return tipoBebida;
        }

        public async Task<TipoBebida> UpdateTipoBebidaAsync(TipoBebida tipoBebida)
        {
            _context.Entry(tipoBebida).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return tipoBebida;
        }

        public async Task<bool> DeleteTipoBebidaAsync(int id)
        {
            var tipoBebida = await _context.TiposBebida.FindAsync(id);
            if (tipoBebida == null)
            {
                return false;
            }
            _context.TiposBebida.Remove(tipoBebida);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
