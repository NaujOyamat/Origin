using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.Base
{
    /// <summary>
    /// Implementación de un objeto modelo
    /// </summary>
    public class ObjectModel : IObjectModel
    {
        #region Fields

        /// <summary>
        /// Lista de propiedades del modelo del objeto
        /// </summary>
        private IList<string> _properties;

        #endregion

        #region Properties

        /// <summary>
        /// <see cref="IObjectModel.Properties"/>
        /// </summary>
        public IList<string> Properties => this._properties;

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="properties">Propiedades del modelo del objeto</param>
        public ObjectModel(params string[] properties)
        {
            this._properties = new List<string>(properties);
        }

        #endregion

        #region Methods
        #endregion
    }
}
