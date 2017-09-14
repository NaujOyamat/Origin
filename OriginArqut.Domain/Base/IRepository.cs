using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Domain.Base
{
    /// <summary>
    /// Define las propiedades y comportamientos básicos de un 
    /// repositorio
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Asigna la unidad de trabajo a la que pertenece el repositorio
        /// </summary>
        /// <param name="unitOfWork">Unidad de trabajo a la que pertenece el repositorio</param>
        void SetUnitOfWork(IUnitOfWork unitOfWork);
    }

    /// <summary>
    /// Define las propiedades y comportamientos básicos de un 
    /// repositorio de forma genérica.
    /// </summary>
    /// <typeparam name="TEntity">Tipo de entiedad que operará el repositorio</typeparam>
    public interface IRepository<TEntity> : IRepository where TEntity : class, IEntity, new()
    {
        /// <summary>
        /// Obtiene una entidad por su Id
        /// </summary>
        /// <param name="id">Id de la entidad</param>
        /// <returns>Entidad consultada</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Obtiene una entidad por su Id de forma asíncrona
        /// </summary>
        /// <param name="id">Id de la entidad</param>
        /// <returns>Entidad consultada</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Lista todas las entidades que cumplen con una expresión
        /// </summary>
        /// <param name="expression">Expresión a evaluar para realizar la consulta</param>
        /// <returns>Lista de entidades que cumplen con la expresión</returns>
        IEnumerable<TEntity> ListByExpression(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Lista todas las entidades que cumplen con una expresión de forma asíncrona
        /// </summary>
        /// <param name="expression">Expresión a evaluar para realizar la consulta</param>
        /// <returns>Lista de entidades que cumplen con la expresión</returns>
        Task<IEnumerable<TEntity>> ListByExpressionAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Lista todas las entidades
        /// </summary>
        /// <returns>Lista de entidades</returns>
        IEnumerable<TEntity> ListAll();

        /// <summary>
        /// Lista todas las entidades de forma asíncrona
        /// </summary>
        /// <returns>Lista de entidades</returns>
        Task<IEnumerable<TEntity>> ListAllAsync();

        /// <summary>
        /// Agrega una nueva entidad a la colección
        /// </summary>
        /// <param name="entity">Entidad a agregar</param>
        /// <returns>Entidad agregada a la colección</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Actualiza una entidad en la colección
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        void Update(TEntity entity);

        /// <summary>
        /// Elimina una entidad de la colección
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        void Remove(TEntity entity);
    }
}
