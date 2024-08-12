using System.Collections.Generic;
using System.Threading.Tasks;
using Bebidas_ML.Models;
using Bebidas_ML.Repositories;

namespace Bebidas_ML.Services
{
    public class BebidaService : IBebidaService
    {
        private readonly IBebidaRepository _bebidaRepository;
        private readonly ITipoBebidaRepository _tipoBebidaRepository;

        public BebidaService(IBebidaRepository bebidaRepository, ITipoBebidaRepository tipoBebidaRepository)
        {
            _bebidaRepository = bebidaRepository;
            _tipoBebidaRepository = tipoBebidaRepository;
        }

        public async Task<IEnumerable<BebidaDto>> GetAllBebidasAsync()
        {
            var bebidas = await _bebidaRepository.GetAllBebidasAsync();
            return bebidas.Select(b => new BebidaDto
                    {
                    Id = b.Id,
                    Descripcion = b.Descripcion,
                    Tamano = b.Tamano,
                    PaisOrigen = b.PaisOrigen,
                    TiposBebida = b.TiposBebidaIds?.Select(id => new TipoBebidaDto
                            {
                            Id = id,
                            Descripcion = _tipoBebidaRepository.GetTipoBebidaByIdAsync(id).Result?.Descripcion
                            }).ToList()
                    });
        }

        public async Task<BebidaDto?> GetBebidaByIdAsync(int id)
        {
            var bebida = await _bebidaRepository.GetBebidaByIdAsync(id);
            if (bebida == null)
                return null;

            return new BebidaDto
            {
                Id = bebida.Id,
                   Descripcion = bebida.Descripcion,
                   Tamano = bebida.Tamano,
                   PaisOrigen = bebida.PaisOrigen,
                   TiposBebida = bebida.TiposBebidaIds?.Select(id => new TipoBebidaDto
                           {
                           Id = id,
                           Descripcion = _tipoBebidaRepository.GetTipoBebidaByIdAsync(id).Result?.Descripcion
                           }).ToList()
            };
        }
        public async Task<Bebida> CreateBebidaAsync(Bebida bebida)
        {
            return await _bebidaRepository.CreateBebidaAsync(bebida);
        }

        public async Task<Bebida> UpdateBebidaAsync(Bebida bebida)
        {
            return await _bebidaRepository.UpdateBebidaAsync(bebida);
        }

        public async Task<bool> DeleteBebidaAsync(int id)
        {
            return await _bebidaRepository.DeleteBebidaAsync(id);
        }
    }
}
