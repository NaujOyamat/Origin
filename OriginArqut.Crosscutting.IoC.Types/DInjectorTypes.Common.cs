using OriginArqut.Crosscutting.IoC.DI;
using OriginArqut.DataAccess.Base;
using OriginArqut.DataAccess.Model;
using OriginArqut.DataAccess.Repositories;
using OriginArqut.Domain.Base;
using OriginArqut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OriginArqut.Crosscutting.IoC.Types
{
    public partial class DInjectorTypes
    {
        /// <summary>
        /// Inyecta los tipos 
        /// </summary>
        /// <param name="injector"></param>
        private static void RegisterCommonTypes(IDInjector injector)
        {
            //Registramos el contexto principal
            injector.RegisterType<IDbContext, MainDbContext>();

            //Registramos los repositorios
            injector.RegisterType<IRepository<Category>, GenericRepository<Category>>(new object[] { injector.ResolveType<IDbContext>() });
            injector.RegisterType<IRepository<Customer>, GenericRepository<Customer>>(new object[] { injector.ResolveType<IDbContext>() });
            injector.RegisterType<IRepository<Order>, GenericRepository<Order>>(new object[] { injector.ResolveType<IDbContext>() });
            injector.RegisterType<IRepository<Product>, GenericRepository<Product>>(new object[] { injector.ResolveType<IDbContext>() });

            //Registramos las unidades de trabajo
            injector.RegisterType<IUnitOfWork, GenericUnitOfWork>(new object[] { injector.ResolveType<IDbContext>() });
        }
    }
}
