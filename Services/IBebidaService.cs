using System.Collections.Generic;
using System.Threading.Tasks;
using Bebidas_ML.Models;

namespace Bebidas_ML.Services
{
    public interface IBebidaService
    {
        //Task<IEnumerable<Bebida>> GetAllBebidasAsync();
        Task<IEnumerable<BebidaDto>> GetAllBebidasAsync();
        //Task<Bebida> GetBebidaByIdAsync(int id);
        Task<BebidaDto?> GetBebidaByIdAsync(int id);
        Task<Bebida> CreateBebidaAsync(Bebida bebida);
        Task<Bebida> UpdateBebidaAsync(Bebida bebida);
        Task<bool> DeleteBebidaAsync(int id);
    }
}
