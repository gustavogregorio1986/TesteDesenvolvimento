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

        public AltitudeService(IAltitudeRepository altitudeRepository)
        {
            _altitudeRepository = altitudeRepository;
        }

        public async Task AdicionarAsync(Altitude altitude)
        {
            // Verifica valor inválido
            if (altitude.Longitude < -90)
                throw new InvalidOperationException("A altitude não pode ser negativa.");

            if (altitude.Longitude > 90)
                throw new InvalidOperationException("A altitude ultrapassa o limite permitido.");

            // Verifica valor inválido
            if (altitude.Latitude < -180)
                throw new InvalidOperationException("A altitude não pode ser negativa.");

            if (altitude.Latitude > 180)
                throw new InvalidOperationException("A altitude ultrapassa o limite permitido.");

            await _altitudeRepository.AdicionarAsync(altitude);
        }

        public async Task<List<Altitude>> ListarAsync()
        {
            return await _altitudeRepository.ListarAsync();
        }
    }
}
