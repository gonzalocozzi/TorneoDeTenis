namespace TorneoDeTenis.WebApi.Services
{
    public class RandomProvider : IRandomProvider
    {
        private readonly Random _random = new();

        public int Next(int minValue, int maxValue) => _random.Next(minValue, maxValue);
    }
}