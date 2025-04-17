using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDesenvolvimento.Data.Context;
using TesteDesenvolvimento.Data.Repository.Interface;
using TesteDesenvolvimento.Dominio.Dominio;

namespace TesteDesenvolvimento.Data.Repository
{
    public class AltitudeRepository : IAltitudeRepository
    {
        private readonly DbContexto _db;

        public AltitudeRepository(DbContexto db)
        {
            _db = db;
        }

        public async Task AdicionarAsync(Altitude altitude)
        {
            _db.Altitudes.Add(altitude);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Altitude>> ListarAsync()
        {
            return await _db.Altitudes.ToListAsync();
        }
    }
}
