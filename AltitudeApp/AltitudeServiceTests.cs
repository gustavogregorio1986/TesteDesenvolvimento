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
        [Fact]
        public async Task Deve_Lancar_Excecao_Quando_Longitude_For_Menor_Que_Menos90()
        {
            // Arrange
            var altitudeInvalida = new Altitude { Longitude = -100, Latitude = 0 };
            var mockRepo = new Mock<IAltitudeRepository>();
            var service = new AltitudeService(mockRepo.Object);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.AdicionarAsync(altitudeInvalida));
            Assert.Equal("A altitude não pode ser negativa.", ex.Message);
        }
    }
}