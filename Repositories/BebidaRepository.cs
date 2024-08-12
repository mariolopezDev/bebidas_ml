using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bebidas_ML.Data;
using Bebidas_ML.Models;

namespace Bebidas_ML.Repositories
{
    public class BebidaRepository : IBebidaRepository
    {
        private readonly BebidasDbContext _context;

        public BebidaRepository(BebidasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bebida>> GetAllBebidasAsync()
        {
            return await _context.Bebidas.ToListAsync();
        }

        public async Task<Bebida?> GetBebidaWithTiposAsync(int id)
        {
            return await _context.Bebidas
                .Where(b => b.Id == id)
                .Select(b => new Bebida
                        {
                        Id = b.Id,
                        Descripcion = b.Descripcion,
                        Tamano = b.Tamano,
                        PaisOrigen = b.PaisOrigen,
                        TiposBebidaIds = b.TiposBebidaIds
                        })
            .FirstOrDefaultAsync();
        }

        public async Task<Bebida> GetBebidaByIdAsync(int id)
        {
            return await _context.Bebidas.FindAsync(id);
        }

        public async Task<Bebida> CreateBebidaAsync(Bebida bebida)
        {
            _context.Bebidas.Add(bebida);
            await _context.SaveChangesAsync();
            return bebida;
        }

        public async Task<Bebida> UpdateBebidaAsync(Bebida bebida)
        {
            _context.Entry(bebida).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return bebida;
        }

        public async Task<bool> DeleteBebidaAsync(int id)
        {
            var bebida = await _context.Bebidas.FindAsync(id);
            if (bebida == null)
            {
                return false;
            }
            _context.Bebidas.Remove(bebida);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
