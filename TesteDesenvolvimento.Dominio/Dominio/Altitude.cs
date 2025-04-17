using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDesenvolvimento.Dominio.Dominio
{
    public class Altitude
    {
        public Guid Id { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int Radius { get; set; }
    }
}
