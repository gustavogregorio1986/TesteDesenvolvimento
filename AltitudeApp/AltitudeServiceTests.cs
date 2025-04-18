using Xunit;
using Moq;
using System;
using System.Threading.Tasks;
using TesteDesenvolvimento.Service;
using TesteDesenvolvimento.Data.Repository.Interface;
using TesteDesenvolvimento.Dominio.Dominio;
using TesteDesenvolvimento.Service.Service;

namespace AltitudeApp
{
    public class AltitudeServiceTests
    {
        private readonly AltitudeService _service;

        public AltitudeServiceTests()
        {
            _service = new AltitudeService();
        }

        [Fact]
        public void ValidarAltitude_DeveLancarExcecao_SeLongitudeMenorQueMenos90()
        {
            var altitudeInvalida = new Altitude { Longitude = -90, Latitude = 0, Radius = 90 };

            var ex = Assert.Throws<InvalidOperationException>(() => _service.ValidarAltitude(altitudeInvalida));
            Assert.Equal("A altitude não pode ser negativa.", ex.Message);
        }

        [Fact]
        public void ValidarAltitude_DeveLancarExcecao_SeLongitudeMaiorQue90()
        {
            var altitudeInvalida = new Altitude { Longitude = 90, Latitude = 0, Radius = 100 };

            var ex = Assert.Throws<InvalidOperationException>(() => _service.ValidarAltitude(altitudeInvalida));
            Assert.Equal("A altitude ultrapassa o limite permitido.", ex.Message);
        }

        [Fact]
        public void ValidarAltitude_DevePassar_SeLatitudeNosLimites()
        {
            var altitudeValida1 = new Altitude { Longitude = 0, Latitude = -180, Radius = 100 };
            var altitudeValida2 = new Altitude { Longitude = 0, Latitude = 180, Radius = 100 };

            var ex1 = Record.Exception(() => _service.ValidarAltitude(altitudeValida1));
            var ex2 = Record.Exception(() => _service.ValidarAltitude(altitudeValida2));

            Assert.Null(ex1);
            Assert.Null(ex2);
        }

        [Fact]
        public void ValidarAltitude_DevePassar_SeRadiusNosLimites()
        {
            var altitudeMin = new Altitude { Longitude = 0, Latitude = 0, Radius = 10 };
            var altitudeMax = new Altitude { Longitude = 0, Latitude = 0, Radius = 1000 };

            var exMin = Record.Exception(() => _service.ValidarAltitude(altitudeMin));
            var exMax = Record.Exception(() => _service.ValidarAltitude(altitudeMax));

            Assert.Null(exMin);
            Assert.Null(exMax);
        }


    }
}