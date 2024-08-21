using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TorneoDeTenis.WebApi.Controllers;
using TorneoDeTenis.WebApi.DTO;
using TorneoDeTenis.WebApi.Enums;
using TorneoDeTenis.WebApi.Models;
using TorneoDeTenis.WebApi.Services;

namespace TorneoDeTenis.Tests.Controllers
{
    public class TorneoControllerTests
    {
        private readonly Mock<ITorneoService> _mockTorneoService;
        private readonly TorneoController _controller;

        public TorneoControllerTests()
        {
            _mockTorneoService = new Mock<ITorneoService>();
            _controller = new TorneoController(_mockTorneoService.Object);
        }

        [Fact]
        public void ObtenerTorneo_CuandoModelStateEsInvalido_DeberiaDevolverBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("TipoTorneo", "Required");

            var torneoRequest = new TorneoRequest
            {
                TipoTorneo = TipoTorneo.Masculino,
                Jugadores = []
            };

            // Act
            var result = _controller.ObtenerTorneo(torneoRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public void ObtenerTorneo_CuandoLanzaExcepcion_DeberiaDevolverBadRequest()
        {
            // Arrange
            var torneoRequest = new TorneoRequest
            {
                TipoTorneo = TipoTorneo.Masculino,
                Jugadores =
                [
                    new() { Nombre = "Jugador 1", Habilidad = 80, Fuerza = 75, Velocidad = 70, TiempoReaccion = 65 },
                    new() { Nombre = "Jugador 2", Habilidad = 85, Fuerza = 80, Velocidad = 75, TiempoReaccion = 70 }
                ]
            };

            _mockTorneoService.Setup(service => service.CrearTorneo(torneoRequest)).Throws(new Exception("Excepción de prueba"));

            // Act
            var result = _controller.ObtenerTorneo(torneoRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("Excepción de prueba", badRequestResult.Value);
        }

        [Fact]
        public void ObtenerTorneo_CuandoRequestEsValido_DeberiaDevolverResultadoOk()
        {
            // Arrange
            var torneoRequest = new TorneoRequest
            {
                TipoTorneo = TipoTorneo.Masculino,
                Jugadores =
                [
                    new() { Nombre = "Jugador 1", Habilidad = 80, Fuerza = 75, Velocidad = 70, TiempoReaccion = 65 },
                    new() { Nombre = "Jugador 2", Habilidad = 85, Fuerza = 80, Velocidad = 75, TiempoReaccion = 70 },
                    new() { Nombre = "Jugador 3", Habilidad = 78, Fuerza = 74, Velocidad = 72, TiempoReaccion = 68 },
                    new() { Nombre = "Jugador 4", Habilidad = 82, Fuerza = 79, Velocidad = 76, TiempoReaccion = 66 }
                ]
            };

            var torneoVacio = new Torneo();
            _mockTorneoService.Setup(service => service.CrearTorneo(torneoRequest)).Returns(torneoVacio); // No me interesa el contenido del torneo, solamente la respuesta de la API

            // Act
            var result = _controller.ObtenerTorneo(torneoRequest);

            // Assert
            var contentResult = Assert.IsType<ContentResult>(result);
            Assert.Equal("application/json", contentResult.ContentType);
        }

        [Fact]
        public void ObtenerGanador_CuandoModelStateEsInvalido_DeberiaDevolverBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("TipoTorneo", "Required");

            // Act
            var result = _controller.ObtenerGanador(new TorneoRequest());

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public void ObtenerGanador_CuandoLanzaExcepcion_DeberiaDevolverBadRequest()
        {
            // Arrange
            var torneoRequest = new TorneoRequest
            {
                TipoTorneo = TipoTorneo.Masculino,
                Jugadores =
                [
                    new() { Nombre = "Jugador 1", Habilidad = 80, Fuerza = 70, Velocidad = 60, TiempoReaccion = 50 },
                    new() { Nombre = "Jugador 2", Habilidad = 85, Fuerza = 75, Velocidad = 65, TiempoReaccion = 55 }
                ]
            };

            _mockTorneoService.Setup(s => s.CrearTorneo(It.IsAny<TorneoRequest>())).Throws(new Exception("Excepción de prueba"));

            // Act
            var result = _controller.ObtenerGanador(torneoRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("Excepción de prueba", badRequestResult.Value);
        }

        [Fact]
        public void ObtenerGanador_CuandoCreaTorneoCorrectamente_DeberiaDevolverResultadoOkConGanadorEsperado()
        {
            // Arrange
            var torneoRequest = new TorneoRequest
            {
                TipoTorneo = TipoTorneo.Masculino,
                Jugadores =
                [
                    new() { Nombre = "Jugador 1", Habilidad = 80, Fuerza = 70, Velocidad = 60, TiempoReaccion = 50 },
                    new() { Nombre = "Jugador 2", Habilidad = 85, Fuerza = 75, Velocidad = 65, TiempoReaccion = 55 },
                    new() { Nombre = "Jugador 3", Habilidad = 78, Fuerza = 65, Velocidad = 68, TiempoReaccion = 58 },
                    new() { Nombre = "Jugador 4", Habilidad = 82, Fuerza = 72, Velocidad = 62, TiempoReaccion = 54 }
                ]
            };

            var ganadorEsperado = new Jugador("Jugador 2", 85, 75, 65, 55);

            _mockTorneoService.Setup(s => s.CrearTorneo(It.IsAny<TorneoRequest>())).Returns(new Torneo
            {
                Ganador = ganadorEsperado
            });

            // Act
            var result = _controller.ObtenerGanador(torneoRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            var actualGanador = Assert.IsType<Jugador>(okResult.Value);
            Assert.Equal(ganadorEsperado.Nombre, actualGanador.Nombre);
            Assert.Equal(ganadorEsperado.Habilidad, actualGanador.Habilidad);
            Assert.Equal(ganadorEsperado.Fuerza, actualGanador.Fuerza);
            Assert.Equal(ganadorEsperado.Velocidad, actualGanador.Velocidad);
            Assert.Equal(ganadorEsperado.TiempoReaccion, actualGanador.TiempoReaccion);
        }
    }
}