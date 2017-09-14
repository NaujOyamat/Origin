using OriginArqut.DataAccess.Base;
using OriginArqut.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.DataAccess.Repositories
{
    /// <summary>
    /// Representa una instancia concreta para un repositorio genérico
    /// </summary>
    public class GenericRepository<TEntity> : Repository<TEntity> where TEntity : class, IEntity, new()
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="context">Contexto de la unidad de trabajo</param>
        public GenericRepository(IDbContext context) : base(context) { }

        #endregion

        #region Methods
        #endregion
    }
}
