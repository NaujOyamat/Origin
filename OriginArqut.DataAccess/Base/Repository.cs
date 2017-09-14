using OriginArqut.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace OriginArqut.DataAccess.Base
{
    /// <summary>
    /// Implementa las características de un repositorio
    /// y crea una abstracción como base para repositorios más concretos
    /// </summary>
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        #region Fields

        /// <summary>
        /// Instancia al contexto
        /// </summary>
        private IDbContext _context;

        /// <summary>
        /// Instancia a la colección de entidades
        /// </summary>
        private IDbSet<TEntity> _entities;

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene la instancia al contexto del repositorio
        /// </summary>
        protected IDbContext Context
        {
            get
            {
                return this._context;
            }
        }

        /// <summary>
        /// Obtiene la instancia a la colección de entidades
        /// </summary>
        protected IDbSet<TEntity> Entities
        {
            get
            {
                return this._entities;
            }
        }

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="context">Contexto de la unidad de trabajo</param>
        public Repository(IDbContext context)
        {
            this.InitializeRepository(context);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inicializa los atributos del repositorio asignando el contexto al que pertence
        /// </summary>
        /// <param name="context">Contexto al que pertenece el repositorio</param>
        private void InitializeRepository(IDbContext context)
        {
            this._context = context;
            this._entities = this._context.Context.Set<TEntity>();
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.Add(TEntity)"/>
        /// </summary>
        public TEntity Add(TEntity entity)
        {
            return this._entities.Add(entity);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.GetById(int)"/>
        /// </summary>
        public TEntity GetById(int id)
        {
            return this._entities.Find(id);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.GetByIdAsync(int)"/>
        /// </summary>
        public Task<TEntity> GetByIdAsync(int id)
        {
            return Task<TEntity>.Factory.StartNew(() => {
                return this.GetById(id);
            });
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.ListAll"/>
        /// </summary>
        public IEnumerable<TEntity> ListAll()
        {
            return this._entities.ToList();
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.ListAllAsync"/>
        /// </summary>
        public Task<IEnumerable<TEntity>> ListAllAsync()
        {
            return Task<IEnumerable<TEntity>>.Factory.StartNew(() => {
                return this.ListAll();
            });
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.ListByExpression(Expression{Func{TEntity, bool}})"/>
        /// </summary>
        public IEnumerable<TEntity> ListByExpression(Expression<Func<TEntity, bool>> expression)
        {
            return this._entities.Where(expression).ToList();
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.ListByExpressionAsync(Expression{Func{TEntity, bool}})"/>
        /// </summary>
        public Task<IEnumerable<TEntity>> ListByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return Task<IEnumerable<TEntity>>.Factory.StartNew(() => {
                return this.ListByExpression(expression);
            });
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.Remove(TEntity)"/>
        /// </summary>
        public void Remove(TEntity entity)
        {
            if (this._context.Context.Entry(entity).State == EntityState.Detached)
            {
                this._entities.Attach(entity);
            }
            this._entities.Remove(entity);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}.Update(TEntity)"/>
        /// </summary>
        public void Update(TEntity entity)
        {
            this._entities.Attach(entity);
            this._context.Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// <see cref="IRepository.SetUnitOfWork(IUnitOfWork)"/>
        /// </summary>
        public void SetUnitOfWork(IUnitOfWork unitOfWork)
        {
            if(unitOfWork is UnitOfWork)
            {
                this.InitializeRepository((unitOfWork as UnitOfWork).Context);
            }
        }

        #endregion
    }
}
