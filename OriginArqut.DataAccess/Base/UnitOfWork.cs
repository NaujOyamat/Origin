using OriginArqut.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OriginArqut.Crosscutting.IoC.DI;

namespace OriginArqut.DataAccess.Base
{
    /// <summary>
    /// Implementa los atributos de una unidad de trabajo
    /// y crea una abstracción para unidades de trabajo más concretas
    /// </summary>
    public abstract class UnitOfWork : IUnitOfWork
    {
        #region Fields

        /// <summary>
        /// Instancia al contenedor de instancias
        /// </summary>
        private readonly DInjectorFactory _injector;

        /// <summary>
        /// Instancia al contexto
        /// </summary>
        private readonly IDbContext _context;

        /// <summary>
        /// Lista de repositorios que conforman la unida de trabajo
        /// </summary>
        private readonly List<IRepository> _repositories;

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene la instancia al contexto
        /// </summary>
        public IDbContext Context
        {
            get
            {
                return this._context;
            }
        }

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="context">Contexto de la unidad de trabajo</param>
        public UnitOfWork(IDbContext context)
        {
            this._context = context;
            this._repositories = new List<IRepository>();
            this._injector = DInjectorFactory.Instance;
        }

        #endregion

        #region Methods

        /// <summary>
        /// <see cref="IUnitOfWork.CommitChanges"/>
        /// </summary>
        public void CommitChanges()
        {
            this._context.Context.SaveChanges();
        }

        /// <summary>
        /// <see cref="IUnitOfWork.CommitChangesAsync"/>
        /// </summary>
        public Task CommitChangesAsync()
        {
            return this._context.Context.SaveChangesAsync();
        }

        /// <summary>
        /// Destruye todas las referencias de los objetos contenidos
        /// </summary>
        public void Dispose()
        {
            this._context.Dispose();
        }

        /// <summary>
        /// <see cref="IUnitOfWork.GetRepository{TRepository}"/>
        /// </summary>
        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            //Buscamos el repositorio en la lista interna
            var result = this._repositories.Where((r) => (r.GetType().GetGenericArguments().Length > 0 && typeof(TRepository).GetGenericArguments().Length > 0 && r.GetType().GetGenericArguments()[0].Equals(typeof(TRepository).GetGenericArguments()[0])) || r.GetType().Equals(typeof(TRepository))).ToList();
            if (result.Count > 0)
                return ((TRepository)result[0]);

            //Si no, lo construimos por medio del contenedor de instancias
            var rep = this._injector.Resolve<TRepository>();
            //Reasignamos la unidad de trabajo al nuevo repositorio
            //para que esté en el mismo contexto
            rep.SetUnitOfWork(this);
            this._repositories.Add(rep);

            return rep;
        }

        /// <summary>
        /// <see cref="IUnitOfWork.RollbackChanges"/>
        /// </summary>
        public void RollbackChanges()
        {
            this._context.Context.ChangeTracker.Entries().ToList().ForEach((e) => {
                e.State = EntityState.Unchanged;
                e.Reload();
            });
        }

        /// <summary>
        /// <see cref="IUnitOfWork.RollbackChangesAsync"/>
        /// </summary>
        public Task RollbackChangesAsync()
        {
            return Task.Factory.StartNew(this.RollbackChanges);
        }

        #endregion
    }
}
