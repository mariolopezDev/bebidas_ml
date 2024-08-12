using System.Collections.Generic;
using System.Threading.Tasks;
using Bebidas_ML.Models;

namespace Bebidas_ML.Services
{
    public interface ITipoBebidaService
    {
        Task<IEnumerable<TipoBebida>> GetAllTiposBebidasAsync();
        Task<TipoBebida> GetTipoBebidaByIdAsync(int id);
        Task<TipoBebida> CreateTipoBebidaAsync(TipoBebida tipoBebida);
        Task<TipoBebida> UpdateTipoBebidaAsync(TipoBebida tipoBebida);
        Task<bool> DeleteTipoBebidaAsync(int id);
    }
}
