using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDesenvolvimento.Dominio.Dominio;

namespace TesteDesenvolvimento.Service.Service.Interface
{
    public interface IAltitudeService
    {
        Task AdicionarAsync(Altitude altitude);

        Task<List<Altitude>> ListarAsync();

        void ValidarAltitude(Altitude altitude);
    }
}
