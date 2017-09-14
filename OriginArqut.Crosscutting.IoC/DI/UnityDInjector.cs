using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Crosscutting.IoC.DI
{
    /// <summary>
    /// Implementa el contrato <see cref="IDInjector"/> bajo la
    /// tecnología de Unity
    /// </summary>
    public class UnityDInjector : IDInjector
    {
        #region Fields

        /// <summary>
        /// Instancia al contenedor de Unity
        /// </summary>
        private UnityContainer _container;

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public UnityDInjector()
        {
            this._container = new UnityContainer();
            //Ésta configuración se agrega para soportar el registro de tipos genéricos
            this._container.RegisterTypes(AllClasses.FromLoadedAssemblies(), WithMappings.FromMatchingInterface, WithName.Default);
        }

        #endregion

        #region Methods

        /// <summary>
        /// <see cref="IDInjector.Clean"/>
        /// </summary>
        public void Clean()
        {
            this._container.Dispose();
            this._container = new UnityContainer();
        }

        /// <summary>
        /// Destruye todas las referencias y tipos registrados, así como el contenedor
        /// </summary>
        public void Dispose()
        {
            this._container.Dispose();
        }

        /// <summary>
        /// <see cref="IDInjector.RegisterType{T, V}"/>
        /// </summary>
        public void RegisterType<T, V>() where V : class, T
        {
            this._container.RegisterType<T, V>();
        }

        /// <summary>
        /// <see cref="IDInjector.RegisterType{T, V}(string, object[])"/>
        /// </summary>
        public void RegisterType<T, V>(string name, params object[] parameters) where V : class, T
        {
            this._container.RegisterType<T, V>(name, new InjectionConstructor(parameters));
        }

        /// <summary>
        /// <see cref="IDInjector.RegisterType{T, V}(string)"/>
        /// </summary>
        public void RegisterType<T, V>(string name) where V : class, T
        {
            this._container.RegisterType<T, V>(name);
        }

        /// <summary>
        /// <see cref="IDInjector.RegisterType{T, V}(object[])"/>
        /// </summary>
        public void RegisterType<T, V>(params object[] parameters) where V : class, T
        {
            this._container.RegisterType<T, V>(new InjectionConstructor(parameters));
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveAllTypes{T}"/>
        /// </summary>
        public IEnumerable<T> ResolveAllTypes<T>()
        {
            return this._container.ResolveAll<T>();
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveAllTypes(Type)"/>
        /// </summary>
        public IEnumerable<object> ResolveAllTypes(Type t)
        {
            return this._container.ResolveAll(t);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType{T}"/>
        /// </summary>
        public T ResolveType<T>()
        {
            return this._container.Resolve<T>();
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType(Type)"/>
        /// </summary>
        public object ResolveType(Type t)
        {
            return this._container.Resolve(t);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType{T}(string)"/>
        /// </summary>
        public T ResolveType<T>(string name)
        {
            return this._container.Resolve<T>(name);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType(Type, string)"/>
        /// </summary>
        public object ResolveType(Type t, string name)
        {
            return this._container.Resolve(t, name);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType{T}(KeyValuePair{string, object}[])"/>
        /// </summary>
        public T ResolveType<T>(params KeyValuePair<string, object>[] parameters)
        {
            ResolverOverride[] par = (from p in parameters select new ParameterOverride(p.Key, p.Value)).ToArray();
            return this._container.Resolve<T>(par);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType{T}(string, KeyValuePair{string, object}[])"/>
        /// </summary>
        public T ResolveType<T>(string name, params KeyValuePair<string, object>[] parameters)
        {
            ResolverOverride[] par = (from p in parameters select new ParameterOverride(p.Key, p.Value)).ToArray();
            return this._container.Resolve<T>(name, par);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType(Type, KeyValuePair{string, object}[])"/>
        /// </summary>
        public object ResolveType(Type t, params KeyValuePair<string, object>[] parameters)
        {
            ResolverOverride[] par = (from p in parameters select new ParameterOverride(p.Key, p.Value)).ToArray();
            return this._container.Resolve(t, par);
        }

        /// <summary>
        /// <see cref="IDInjector.ResolveType(Type, string, KeyValuePair{string, object}[])"/>
        /// </summary>
        public object ResolveType(Type t, string name, params KeyValuePair<string, object>[] parameters)
        {
            ResolverOverride[] par = (from p in parameters select new ParameterOverride(p.Key, p.Value)).ToArray();
            return this._container.Resolve(t, name, par);
        }

        #endregion
    }
}
