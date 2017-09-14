using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OriginArqut.Crosscutting.IoC.DI;
using OriginArqut.Crosscutting.IoC.Types;
using OriginArqut.Domain.Base;
using OriginArqut.Domain.Entities;
using OriginArqut.Application.Adapters;
using OriginArqut.Application.Adapters.Base;
using OriginArqut.Application.Adapters.Mappers;
using System.Dynamic;
using OriginArqut.Application.Adapters.DTO;

namespace TestClient.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DInjectorFactory IoC = DInjectorFactory.Instance;
            DInjectorTypes.RegisterTypes(IoC.Injector);

            MapperAdapterFactory mapper = MapperAdapterFactory.Instance;

            var unit = IoC.Resolve<IUnitOfWork>();
            var productRep = unit.GetRepository<IRepository<Product>>();
            var CatRep = unit.GetRepository<IRepository<Category>>();

            var product = productRep.ListAll();
            var cat = CatRep.GetById(1);

            var res = product.ToDTOs().ToList();

            System.Console.WriteLine($"{res[0].Code} - {res[0].Name}");

            System.Console.ReadKey();
        }
    }
}
