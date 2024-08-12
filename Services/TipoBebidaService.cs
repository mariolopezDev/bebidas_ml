using System.Collections.Generic;
using System.Threading.Tasks;
using Bebidas_ML.Models;
using Bebidas_ML.Repositories;

namespace Bebidas_ML.Services
{
    public class TipoBebidaService : ITipoBebidaService
    {
        private readonly ITipoBebidaRepository _tipoBebidaRepository;

        public TipoBebidaService(ITipoBebidaRepository tipoBebidaRepository)
        {
            _tipoBebidaRepository = tipoBebidaRepository;
        }

        public async Task<IEnumerable<TipoBebida>> GetAllTiposBebidasAsync()
        {
            return await _tipoBebidaRepository.GetAllTiposBebidasAsync();
        }

        public async Task<TipoBebida> GetTipoBebidaByIdAsync(int id)
        {
            return await _tipoBebidaRepository.GetTipoBebidaByIdAsync(id);
        }

        public async Task<TipoBebida> CreateTipoBebidaAsync(TipoBebida tipoBebida)
        {
            return await _tipoBebidaRepository.CreateTipoBebidaAsync(tipoBebida);
        }

        public async Task<TipoBebida> UpdateTipoBebidaAsync(TipoBebida tipoBebida)
        {
            return await _tipoBebidaRepository.UpdateTipoBebidaAsync(tipoBebida);
        }

        public async Task<bool> DeleteTipoBebidaAsync(int id)
        {
            return await _tipoBebidaRepository.DeleteTipoBebidaAsync(id);
        }
    }
}
