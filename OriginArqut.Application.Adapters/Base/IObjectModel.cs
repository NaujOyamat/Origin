using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.Base
{
    /// <summary>
    /// Define los atributos y comportamientos de un objeto modelo
    /// </summary>
    public interface IObjectModel
    {
        #region Properties

        /// <summary>
        /// Obtiene la lista de propiedades que componen el modelo
        /// del objeto
        /// </summary>
        IList<string> Properties { get; }

        #endregion
    }
}
