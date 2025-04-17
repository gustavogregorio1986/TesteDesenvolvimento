using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDesenvolvimento.Data.Repository.Interface;
using TesteDesenvolvimento.Dominio.Dominio;
using TesteDesenvolvimento.Service.Service.Interface;

namespace TesteDesenvolvimento.Service.Service
{
    public class AltitudeService : IAltitudeService
    {
        private readonly IAltitudeRepository _altitudeRepository;

        public async Task AdicionarAsync(Altitude altitude)
        {
            await _altitudeRepository.AdicionarAsync(altitude);
        }

        public async Task<List<Altitude>> ListarAsync()
        {
            return await _altitudeRepository.ListarAsync();
        }
    }
}
