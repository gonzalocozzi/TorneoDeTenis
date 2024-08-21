using TorneoDeTenis.WebApi.Services;

namespace TorneoDeTenis.Tests.Services
{
    /// <summary>
    /// Clase de pruebas agregada solamente a los fines de aumentar la cobertura de código.
    /// Probar una clase de la biblioteca de .NET no tiene sentido en el marco de este proyecto
    /// </summary>
    public class RandomProviderTests
    {
        [Fact]
        public void RandomProvider_Next_DeberiaDevolverValoresDentroDelRangoEspecificado()
        {
            // Arrange
            var randomProvider = new RandomProvider();
            int minValue = 10;
            int maxValue = 20;
            bool allValuesInRange = true;

            // Act
            for (int i = 0; i < 1000; i++)
            {
                int result = randomProvider.Next(minValue, maxValue);
                if (result < minValue || result >= maxValue)
                {
                    allValuesInRange = false;
                    break;
                }
            }

            // Assert
            Assert.True(allValuesInRange, $"Todos los valores deberían estar entre {minValue} y {maxValue - 1}");
        }

        [Fact]
        public void Next_DeberiaProducirValoresDistribuidosUniformemente()
        {
            // Arrange
            var randomProvider = new RandomProvider();
            int minValue = 0;
            int maxValue = 10;
            int[] results = new int[maxValue];
            int iterations = 100000;

            // Act
            for (int i = 0; i < iterations; i++)
            {
                int result = randomProvider.Next(minValue, maxValue);
                results[result]++;
            }

            // Assert
            double expectedCount = iterations / (double)(maxValue - minValue);
            double tolerance = expectedCount * 0.1; // tolerancia de desviación del 10%

            foreach (int count in results)
            {
                Assert.InRange(count, expectedCount - tolerance, expectedCount + tolerance);
            }
        }
    }
}