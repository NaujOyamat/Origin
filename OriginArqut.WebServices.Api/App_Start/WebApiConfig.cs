using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OriginArqut.Crosscutting.IoC.DI;
using OriginArqut.Crosscutting.IoC.Types;

namespace OriginArqut.WebServices.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Registramos los tipos en el contenedor de dependencias
            DInjectorTypes.RegisterTypes(DInjectorFactory.Instance.Injector);
            //Creamos el resolvedor de dependencias del servicio
            config.DependencyResolver = new DInjectorResolver(DInjectorFactory.Instance.Injector);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
