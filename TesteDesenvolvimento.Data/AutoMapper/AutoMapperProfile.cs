using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDesenvolvimento.Data.DTO;
using TesteDesenvolvimento.Dominio.Dominio;

namespace TesteDesenvolvimento.Data.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Altitude, AltitudeDTO>();
        }
    }
}
