using TorneoDeTenis.Enums;

namespace TorneoDeTenis.Services
{
    public interface IEnfrentamientoStrategyFactory
    {
        IEnfrentamientoStrategy CrearStrategy(TipoTorneo tipoTorneo);
    }
}