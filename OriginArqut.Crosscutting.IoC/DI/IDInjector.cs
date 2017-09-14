using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Crosscutting.IoC.DI
{
    /// <summary>
    /// Define las propiedades y comportamientos de un contenedor
    /// de dependencias
    /// </summary>
    public interface IDInjector : IDisposable
    {
        /// <summary>
        /// Resulve todos los tipos registrados con distinto nombre
        /// para un mismo contrato
        /// </summary>
        /// <typeparam name="T">Contrato especificado para instanciar el tipo concreto</typeparam>
        /// <returns>Un conjunto de objetos para el contrato dado</returns>
        IEnumerable<T> ResolveAllTypes<T>();

        /// <summary>
        /// Resuelve el tipo concreto para el contrato dado
        /// </summary>
        /// <typeparam name="T">Contrato especificado para instanciar el tipo concreto</typeparam>
        /// <returns>Instancia del tipo concreto registrado para el contrato dado</returns>
        T ResolveType<T>();

        /// <summary>
        /// Resuelve el tipo concreto para el contrato dado usando parámetros específicos para la construcción
        /// </summary>
        /// <param name="parameters">Parámetros usados para la construcción de la instancia</param>
        /// <typeparam name="T">Contrato especificado para instanciar el tipo concreto</typeparam>
        /// <returns>Instancia del tipo concreto registrado para el contrato dado</returns>
        T ResolveType<T>(params KeyValuePair<string, object>[] parameters);

        /// <summary>
        /// Resuelve el tipo concreto para el contrato dado
        /// </summary>
        /// <param name="name">Nombre con que se registro el tipo</param>
        /// <typeparam name="T">Contrato especificado para instanciar el tipo concreto</typeparam>
        /// <returns>Instancia del tipo concreto registrado para el contrato dado</returns>
        T ResolveType<T>(string name);

        /// <summary>
        /// Resuelve el tipo concreto para el contrato dado usando parámetros específicos para la construcción
        /// </summary>
        /// <param name="name">Nombre con que se registro el tipo</param>
        /// <param name="parameters">Parámetros usados para la construcción de la instancia</param>
        /// <typeparam name="T">Contrato especificado para instanciar el tipo concreto</typeparam>
        /// <returns>Instancia del tipo concreto registrado para el contrato dado</returns>
        T ResolveType<T>(string name, params KeyValuePair<string, object>[] parameters);

        /// <summary>
        /// Resuelve el tipo concreto para el contrato dado
        /// </summary>
        /// <param name="t">Contrato especificado para instanciar el tipo concreto</param>
        /// <returns>Instancia del tipo concreto registrado para el contrato dado</returns>
        object ResolveType(Type t);

        /// <summary>
        /// Resulve todos los tipos registrados con distinto nombre
        /// para un mismo contrato
        /// </summary>
        /// <param name="t">Contrato especificado para instanciar el tipo concreto</param>
        /// <returns>Un conjunto de objetos para el contrato dado</returns>
        IEnumerable<object> ResolveAllTypes(Type t);

        /// <summary>
        /// Resuelve el tipo concreto para el contrato dado usando parámetros específicos para la construcción
        /// </summary>
        /// <param name="t">Contrato especificado para instanciar el tipo concreto</param>
        /// <param name="parameters">Parámetros usados para la construcción de la instancia</param>
        /// <returns>Instancia del tipo concreto registrado para el contrato dado</returns>
        object ResolveType(Type t, params KeyValuePair<string, object>[] parameters);

        /// <summary>
        /// Resuelve el tipo concreto para el contrato dado
        /// </summary>
        /// <param name="t">Contrato especificado para instanciar el tipo concreto</param>
        /// <param name="name">Nombre con que se resgistro el tipo</param>
        /// <returns>Instancia del tipo concreto registrado para el contrato dado</returns>
        object ResolveType(Type t, string name);

        /// <summary>
        /// Resuelve el tipo concreto para el contrato dado usando parámetros específicos para la construcción
        /// </summary>
        /// <param name="t">Contrato especificado para instanciar el tipo concreto</param>
        /// <param name="name">Nombre con que se resgistro el tipo</param>
        /// <param name="parameters">Parámetros usados para la construcción de la instancia</param>
        /// <returns>Instancia del tipo concreto registrado para el contrato dado</returns>
        object ResolveType(Type t, string name, params KeyValuePair<string, object>[] parameters);

        /// <summary>
        /// Registra un tipo concreto por medio de su contrato
        /// </summary>
        /// <typeparam name="T">Contrato que define las propiedades del tipo concreto</typeparam>
        /// <typeparam name="V">Tipo concreto que se usará para el contrato dado</typeparam>
        void RegisterType<T, V>() where V : class, T;

        /// <summary>
        /// Registra un tipo concreto por medio de su contrato
        /// </summary>
        /// <param name="name">Nombre conque se va a registrar el tipo</param>
        /// <typeparam name="T">Contrato que define las propiedades del tipo concreto</typeparam>
        /// <typeparam name="V">Tipo concreto que se usará para el contrato dado</typeparam>
        void RegisterType<T, V>(string name) where V : class, T;

        /// <summary>
        /// Registra un tipo concreto por medio de su contrato
        /// </summary>
        /// <param name="parameters">Lista de parámetros usados en el contructor de la instancia</param>
        /// <typeparam name="T">Contrato que define las propiedades del tipo concreto</typeparam>
        /// <typeparam name="V">Tipo concreto que se usará para el contrato dado</typeparam>
        void RegisterType<T, V>(params object[] parameters) where V : class, T;

        /// <summary>
        /// Registra un tipo concreto por medio de su contrato
        /// </summary>
        /// <param name="name">Nombre conque se va a registrar el tipo</param>
        /// <param name="parameters">Lista de parámetros usados en el contructor de la instancia</param>
        /// <typeparam name="T">Contrato que define las propiedades del tipo concreto</typeparam>
        /// <typeparam name="V">Tipo concreto que se usará para el contrato dado</typeparam>
        void RegisterType<T, V>(string name, params object[] parameters) where V : class, T;

        /// <summary>
        /// Limpia todos los tipos registrados
        /// </summary>
        void Clean();
    }
}
