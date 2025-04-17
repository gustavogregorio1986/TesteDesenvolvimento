using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDesenvolvimento.Data.DTO
{
    public class AltitudeDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A Latitude é obrigatório.")]
        [Range(-90, 90, ErrorMessage = "A latitude deve estar entre -90 e 90.")]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "A Longitude é obrigatório.")]
        [Range(-180, 180, ErrorMessage = "A latitude deve estar entre -180 e 180.")]
        public decimal Longitude { get; set; }

        [Required(ErrorMessage = "O raio é obrigatório.")]
        [Range(10, 1000, ErrorMessage = "O raio deve estar entre 10 e 1000 metros.")]
        public int Radius { get; set; }
    }
}
