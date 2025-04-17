using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDesenvolvimento.Dominio.Dominio;

namespace TesteDesenvolvimento.Data.Repository.Interface
{
    public interface IAltitudeRepository
    {
        Task AdicionarAsync(Altitude altitude);

        Task<List<Altitude>> ListarAsync();
    }
}
