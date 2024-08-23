using TorneoDeTenis.WebApi.Models;

namespace TorneoDeTenis.WebApi.Infraestructure.Data
{
    /// <summary>
    /// Interfaz para el repositorio de Torneo que maneja las operaciones de la base de datos.
    /// </summary>
    public interface ITorneoRepository
    {
        /// <summary>
        /// Obtiene todos los torneos de la base de datos de manera asincrónica.
        /// </summary>
        /// <returns>Una lista de todos los torneos.</returns>
        Task<IEnumerable<Torneo>> GetAllAsync();

        /// <summary>
        /// Obtiene un torneo por su ID de manera asincrónica.
        /// </summary>
        /// <param name="id">El ID del torneo a obtener.</param>
        /// <returns>El torneo encontrado o null si no existe.</returns>
        Task<Torneo> GetByIdAsync(long id);

        /// <summary>
        /// Agrega un nuevo torneo a la base de datos de manera asincrónica.
        /// </summary>
        /// <param name="torneo">El torneo a agregar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task AddAsync(Torneo torneo);

        /// <summary>
        /// Actualiza un torneo existente en la base de datos de manera asincrónica.
        /// </summary>
        /// <param name="torneo">El torneo a actualizar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task UpdateAsync(Torneo torneo);

        /// <summary>
        /// Elimina un torneo de la base de datos por su ID de manera asincrónica.
        /// </summary>
        /// <param name="id">El ID del torneo a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// Guarda todos los cambios pendientes en la base de datos de manera asincrónica.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task SaveChangesAsync();
    }
}