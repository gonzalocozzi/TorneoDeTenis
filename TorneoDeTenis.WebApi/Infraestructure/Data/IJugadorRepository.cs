using TorneoDeTenis.WebApi.Models;

namespace TorneoDeTenis.WebApi.Infraestructure.Data
{
    /// <summary>
    /// Interfaz para el repositorio de Jugador que maneja las operaciones de la base de datos.
    /// </summary>
    public interface IJugadorRepository
    {
        /// <summary>
        /// Obtiene todos los jugadores de la base de datos de manera asincrónica.
        /// </summary>
        /// <returns>Una lista de todos los jugadores.</returns>
        Task<IEnumerable<Jugador>> GetAllAsync();

        /// <summary>
        /// Obtiene un jugador por su ID de manera asincrónica.
        /// </summary>
        /// <param name="id">El ID del jugador a obtener.</param>
        /// <returns>El jugador encontrado o null si no existe.</returns>
        Task<Jugador> GetByIdAsync(long id);

        /// <summary>
        /// Agrega un nuevo jugador a la base de datos de manera asincrónica.
        /// </summary>
        /// <param name="jugador">El jugador a agregar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task AddAsync(Jugador jugador);

        /// <summary>
        /// Actualiza un jugador existente en la base de datos de manera asincrónica.
        /// </summary>
        /// <param name="jugador">El jugador a actualizar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task UpdateAsync(Jugador jugador);

        /// <summary>
        /// Elimina un jugador de la base de datos por su ID de manera asincrónica.
        /// </summary>
        /// <param name="id">El ID del jugador a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// Guarda todos los cambios pendientes en la base de datos de manera asincrónica.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task SaveChangesAsync();
    }
}