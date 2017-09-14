using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Domain.Base
{
    /// <summary>
    /// Define las propiedades y comportamientos de una unidad de trabajo
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Obtiene un repositorio del tipo especificado
        /// </summary>
        /// <typeparam name="TRepository">Tipo de repositorio requerido</typeparam>
        /// <returns>Respositorio obtenido</returns>
        TRepository GetRepository<TRepository>() where TRepository : IRepository;

        /// <summary>
        /// Deshace los cambios realizados en el contexto antes de una operación <see cref="CommitChanges"/>
        /// </summary>
        void RollbackChanges();

        /// <summary>
        /// Deshace los cambios realizados en el contexto antes de una operación <see cref="CommitChanges"/> de forma asíncrona
        /// </summary>
        Task RollbackChangesAsync();

        /// <summary>
        /// Graba los cambios realizados en los repositorios en la misma transacción
        /// </summary>
        void CommitChanges();

        /// <summary>
        /// Graba los cambios realizados en los repositorios en la misma transacción de forma asíncrona
        /// </summary>
        Task CommitChangesAsync();
    }
}
