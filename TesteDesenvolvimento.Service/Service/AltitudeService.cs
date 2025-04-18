using System;
using System.Collections.Generic;
using System.Drawing;
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

        public AltitudeService()
        {
            
        }

        public AltitudeService(IAltitudeRepository altitudeRepository)
        {
            _altitudeRepository = altitudeRepository;
        }

        public async Task AdicionarAsync(Altitude altitude)
        {
            ValidarAltitude(altitude);

            await _altitudeRepository.AdicionarAsync(altitude);
        }

        public async Task<List<Altitude>> ListarAsync()
        {
            return await _altitudeRepository.ListarAsync();
        }

        public void ValidarAltitude(Altitude altitude)
        {
            // Verifica valor inválido para Longitude
            if (altitude.Longitude < -90)
                throw new InvalidOperationException("A altitude não pode ser negativa.");

            if (altitude.Longitude > 90)
                throw new InvalidOperationException("A altitude ultrapassa o limite permitido.");

            // Verifica valor inválido para Latitude
            if (altitude.Latitude < -180)
                throw new InvalidOperationException("A altitude não pode ser negativa.");

            if (altitude.Latitude > 180)
                throw new InvalidOperationException("A altitude ultrapassa o limite permitido.");

            // Verifica valor inválido para Radius
            if (altitude.Radius < 10)
                throw new InvalidOperationException("A altitude não pode ser menor que 10 metros.");

            if (altitude.Radius > 1000)
                throw new InvalidOperationException("A altitude não pode ser maior que 1000 metros (1 km).");
        }
    }
}
