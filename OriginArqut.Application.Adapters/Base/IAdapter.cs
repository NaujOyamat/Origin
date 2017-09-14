using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.Base
{
    /// <summary>
    /// Define los atributos y comportamientos de un adaptador de tipos
    /// </summary>
    public interface IAdapter
    {
        #region Methods

        /// <summary>
        /// Adapta un objeto fuente a un tipo destino, mapeando sus propiedades
        /// </summary>
        /// <param name="source">Objeto fuente</param>
        /// <param name="target">Tipo destino</param>
        /// <returns>Objeto de tipo destino</returns>
        object Adapt(object source, Type target);

        /// <summary>
        /// Adapta un arreglo de objetos fuente a un tipo destino, mapeando cada una de las propiedades
        /// de cada uno de los objetos fuente a cada una de las propiedades del tipo destino
        /// </summary>
        /// <param name="sources">Arreglo de objetos fuente</param>
        /// <param name="target">Tipo del objeto destino</param>
        /// <returns>Objeto destino</returns>
        object Adapt(object[] sources, Type target);

        #endregion
    }

    /// <summary>
    /// Define los atributos y comportamientos de un adaptador genérico
    /// </summary>
    /// <typeparam name="TTarget">Tipo del objeto destino</typeparam>
    public interface IAdapter<TTarget> : IAdapter where TTarget : class, new()
    {
        #region Methods

        /// <summary>
        /// Adapta un objeto fuente a un objeto <see cref="TTarget"/>
        /// </summary>
        /// <param name="source">Objeto del tipo fuente</param>
        /// <returns>Objeto del tipo destino</returns>
        TTarget Adapt(object source);

        /// <summary>
        /// Adapta un arreglo de objetos fuente a un objeto <see cref="TTarget"/>
        /// </summary>
        /// <param name="sources">Arreglo de objetos fuente</param>
        /// <returns>Objeto destino</returns>
        TTarget Adapt(object[] sources);

        #endregion
    }
}
