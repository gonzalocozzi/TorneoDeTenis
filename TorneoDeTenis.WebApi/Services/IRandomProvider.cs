namespace TorneoDeTenis.WebApi.Services
{
    public interface IRandomProvider
    {
        /// <summary>
        /// Permite inyectar un proveedor de valores aleatorios con un rango de valores específico
        /// </summary>
        /// <param name="minValue">Valor mínimo del rango a devolver</param>
        /// <param name="maxValue">Valor máximo del rango a devolver</param>
        /// <returns>Valor aleatorio dentro del rango indicado</returns>
        int Next(int minValue, int maxValue);
    }
}