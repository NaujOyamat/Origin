using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Crosscutting.IoC.DI
{
    /// <summary>
    /// Encapsula la única instancia al contenedor de dependecias
    /// de toda la aquitectura
    /// </summary>
    public class DInjectorFactory
    {
        #region Singleton

        /// <summary>
        /// Única instancia de la clase
        /// </summary>
        private static DInjectorFactory _instance;

        /// <summary>
        /// Obtiene l aúnica instancia de la clase
        /// </summary>
        public static DInjectorFactory Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DInjectorFactory();
                }
                return _instance;
            }
        }

        #endregion

        #region Fields

        /// <summary>
        /// Instancia al inyector de dependencias
        /// </summary>
        private readonly IDInjector _injector;

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene la instancia al contenedor
        /// </summary>
        public IDInjector Injector
        {
            get
            {
                return this._injector;
            }
        }

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una instancia de la clase
        /// </summary>
        private DInjectorFactory()
        {
            this._injector = new UnityDInjector();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <see cref="IDInjector.ResolveType{T}"/>
        /// </summary>
        public T Resolve<T>()
        {
            return this._injector.ResolveType<T>();
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveAllTypes{T}"/>
        /// </summary>
        public IEnumerable<T> ResolveAllTypes<T>()
        {
            return this._injector.ResolveAllTypes<T>();
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType{T}(string)"/>
        /// </summary>
        public T Resolve<T>(string name)
        {
            return this._injector.ResolveType<T>(name);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType{T}(KeyValuePair{string, object}[])"/>
        /// </summary>
        public T Resolve<T>(params KeyValuePair<string, object>[] parameters)
        {
            return this._injector.ResolveType<T>(parameters);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType{T}(string, KeyValuePair{string, object}[])"/>
        /// </summary>
        public T Resolve<T>(string name, params KeyValuePair<string, object>[] parameters)
        {
            return this._injector.ResolveType<T>(name, parameters);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType(Type)"/>
        /// </summary>
        public object Resolve(Type t)
        {
            return this._injector.ResolveType(t);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveAllTypes(Type)"/>
        /// </summary>
        public IEnumerable<object> ResolveAllTypes(Type t)
        {
            return this._injector.ResolveAllTypes(t);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType(Type, string)"/>
        /// </summary>
        public object Resolve(Type t, string name)
        {
            return this._injector.ResolveType(t, name);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType(Type, KeyValuePair{string, object}[])"/>
        /// </summary>
        public object Resolve(Type t, params KeyValuePair<string, object>[] parameters)
        {
            return this._injector.ResolveType(t, parameters);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType(Type, string, KeyValuePair{string, object}[])"/>
        /// </summary>
        public object Resolve(Type t, string name, params KeyValuePair<string, object>[] parameters)
        {
            return this._injector.ResolveType(t, name, parameters);
        }

        #endregion
    }
}
