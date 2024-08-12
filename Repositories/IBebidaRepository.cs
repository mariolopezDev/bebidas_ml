using System.Collections.Generic;
using System.Threading.Tasks;
using Bebidas_ML.Models;

namespace Bebidas_ML.Repositories
{
    public interface IBebidaRepository
    {
        Task<IEnumerable<Bebida>> GetAllBebidasAsync();
        Task<Bebida> GetBebidaByIdAsync(int id);
        Task<Bebida?> GetBebidaWithTiposAsync(int id);
        Task<Bebida> CreateBebidaAsync(Bebida bebida);
        Task<Bebida> UpdateBebidaAsync(Bebida bebida);
        Task<bool> DeleteBebidaAsync(int id);
    }
}
