using OriginArqut.DataAccess.Base;
using OriginArqut.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.DataAccess.Model
{
    /// <summary>
    /// Reoresenta una instancia concreta para una unidad de trabajo genérica
    /// </summary>
    public class GenericUnitOfWork : UnitOfWork
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
        public GenericUnitOfWork(IDbContext context) : base(context) { }

        #endregion

        #region Methods
        #endregion
    }
}
