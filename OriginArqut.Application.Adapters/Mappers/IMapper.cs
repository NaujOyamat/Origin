using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.Mappers
{
    /// <summary>
    /// Define los atributos y comportamientos de un mapeador de adaptadores
    /// </summary>
    public interface IMapper
    {
        #region Methods

        /// <summary>
        /// Limpia los adaptadores registrados
        /// </summary>
        void CleanAdapters();

        /// <summary>
        /// Registra una función adaptador de un tipo fuente a un tipo destino
        /// </summary>
        /// <typeparam name="TSource">Tipo del objeto fuente</typeparam>
        /// <typeparam name="TTarget">Tipo tipo del objeto destino</typeparam>
        /// <param name="expression">Función adaptador</param>
        void RegisterAdapter<TSource, TTarget>(Func<TSource, TTarget> expression) 
            where TSource : class, new()
            where TTarget : class, new();

        /// <summary>
        /// Registra una función adaptador de un tipo fuente a un tipo destino
        /// </summary>
        /// <param name="tSource">Tipo del objeto fuente</param>
        /// <param name="tTarget">Tipo tipo del objeto destino</param>
        /// <param name="expression">Función adaptador</param>
        void RegisterAdapter(Type tSource, Type tTarget, Func<object, object> expression);

        /// <summary>
        /// Registra una función adaptador de un arreglo de tipos fuente a un tipo destino
        /// </summary>
        /// <typeparam name="TTarget">Tipo del objeto destino</typeparam>
        /// <param name="expression">Función adaptador</param>
        void RegisterAdapter<TTarget>(Func<dynamic[], TTarget> expression)
            where TTarget : class, new();

        /// <summary>
        /// Registra una función adaptador de un arreglo de tipos fuente a un tipo destino
        /// </summary>
        /// <param name="tTarget">Tipo del objeto destino</param>
        /// <param name="expression">Función adaptador</param>
        void RegisterAdapter(Type tTarget, Func<dynamic[], dynamic> expression);

        /// <summary>
        /// Registra una función adaptador de un arreglo de tipos fuente a un tipo destino con un nombre específico
        /// </summary>
        /// <typeparam name="TTarget">Tipo del objeto destino</typeparam>
        /// <param name="name">Nombre con el que se va a registrar el adaptador</param>
        /// <param name="expression">Función adaptador</param>
        void RegisterAdapter<TTarget>(string name, Func<dynamic[], TTarget> expression)
            where TTarget : class, new();

        /// <summary>
        /// Registra una función adaptador de un arreglo de tipos fuente a un tipo destino con un nombre específico
        /// </summary>
        /// <param name="name">Nombre con el que se va a registrar el adaptador</param>
        /// <param name="tTarget">Tipo del objeto destino</param>
        /// <param name="expression">Función adaptador</param>
        void RegisterAdapter(string name, Type tTarget, Func<dynamic[], dynamic> expression);

        /// <summary>
        /// Resuelve el adaptador para un tipo fuente y un tipo destino específicos
        /// </summary>
        /// <typeparam name="TSource">Tipo del objeto fuente</typeparam>
        /// <typeparam name="TTarget">Tipo del objeto destino</typeparam>
        /// <returns>Adaptador</returns>
        Func<TSource, TTarget> ResolveAdapter<TSource, TTarget>();

        /// <summary>
        /// Resuelve el adaptador para un tipo fuente y un tipo destino específicos
        /// </summary>
        /// <param name="tSource">Tipo del objeto fuente</param>
        /// <param name="tTarget">Tipo del objeto destino</param>
        /// <returns>Adaptador</returns>
        Func<dynamic, dynamic> ResolveAdapter(Type tSource, Type tTarget);

        /// <summary>
        /// Resuelve el adaptador para un arreglo de tipos fuente y un tipo destino 
        /// </summary>
        /// <typeparam name="TTarget">Tipo del objeto destino</typeparam>
        /// <returns>Adaptador</returns>
        Func<dynamic[], TTarget> ResolveAdapter<TTarget>();

        /// <summary>
        /// Resuelve el adaptador para un arreglo de tipos fuente y un tipo destino 
        /// </summary>
        /// <param name="tTarget">Tipo del objeto destino</param>
        /// <returns>Adaptador</returns>
        Func<dynamic[], dynamic> ResolveAdapter(Type tTarget);

        /// <summary>
        /// Resuelve el adaptador para un arreglo de tipos fuente y un tipo destino con un nombre específico
        /// </summary>
        /// <typeparam name="TTarget">Tipo del objeto destino</typeparam>
        /// <param name="name">Nombre con el que se registró el adaptador</param>
        /// <returns>Adaptador</returns>
        Func<dynamic[], TTarget> ResolveAdapter<TTarget>(string name);

        /// <summary>
        /// Resuelve el adaptador para un arreglo de tipos fuente y un tipo destino con un nombre específico
        /// </summary>
        /// <param name="tTarget">Tipo del objeto destino</param>
        /// <param name="name">Nombre con el que se registró el adaptador</param>
        /// <returns>Adaptador</returns>
        Func<dynamic[], dynamic> ResolveAdapter(string name, Type tTarget);


        #endregion
    }
}
