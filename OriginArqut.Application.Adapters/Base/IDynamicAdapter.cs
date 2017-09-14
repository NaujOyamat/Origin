using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.Base
{
    /// <summary>
    /// Define los atributos y comportamientos de un adaptador dinámico
    /// </summary>
    public interface IDynamicAdapter
    {
        #region Methods

        /// <summary>
        /// Adapta un objeto fuente a un objeto dinámico destino 
        /// </summary>
        /// <param name="source">Objeto del tipo fuente</param>
        /// <param name="model">Modelo del objeto dinámico destino. Si no se proporciona, el objeto destino
        /// tendrá todas las propiedades del objeto fuente</param>
        /// <returns>Objeto dinámico destino</returns>
        dynamic Adapt(object source, IObjectModel model = null);

        /// <summary>
        /// Adapta un arreglo de objetos fuente a un objeto dinámico destino 
        /// </summary>
        /// <param name="sources">Arreglo de objeto fuente</param>
        /// <param name="model">Modelo del objeto dinámico destino. Si no se proporciona, el objeto destino
        /// tendrá todas las propiedades de los objetos fuente</param>
        /// <returns>Objeto dinámico destino</returns>
        dynamic Adapt(object[] sources, IObjectModel model = null);

        #endregion
    }
}
