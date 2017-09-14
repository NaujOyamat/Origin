
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using OriginArqut.Crosscutting.IoC.DI;

namespace OriginArqut.WebServices.Api
{
    /// <summary>
    /// Provee una implementación <see cref="IDependencyResolver"/>
    /// para inyectar las dependencias por medio del contenedor de
    /// dependencias de la arquitectura
    /// </summary>
    public class DInjectorResolver : IDependencyResolver
    {
        #region Fields

        /// <summary>
        /// Instancia al contenedor de dependencias de la arquitectura
        /// </summary>
        private readonly IDInjector _container;

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="container">Contenedor de dependencias de la arquitectura</param>
        public DInjectorResolver(IDInjector container)
        {
            this._container = container ?? throw new ArgumentNullException("container");
        }

        #endregion

        #region Methods

        /// <summary>
        /// <see cref="IDependencyResolver.BeginScope"/>
        /// </summary>
        public IDependencyScope BeginScope()
        {
            return new DInjectorResolver(_container);
        }

        /// <summary>
        /// <see cref="IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            _container.Dispose();
        }

        /// <summary>
        /// <see cref="IDependencyScope.GetService(Type)"/>
        /// </summary>
        public object GetService(Type serviceType)
        {
            try
            {
                return _container.ResolveType(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// <see cref="IDependencyScope.GetServices(Type)"/>
        /// </summary>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAllTypes(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        #endregion
    }
}