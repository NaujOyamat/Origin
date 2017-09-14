using OriginArqut.Application.Adapters.Adapters;
using OriginArqut.Application.Adapters.Base;
using OriginArqut.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters
{
    /// <summary>
    /// Provee métodos de extensión para los tipos <see cref="IDTO"/>
    /// </summary>
    public static class StaticDTOExtensions
    {
        #region Adapters

        /// <summary>
        /// Instancia al adaptador estático
        /// </summary>
        private static readonly IAdapter _adapter = new StaAdapter();

        #endregion

        #region Methods

        /// <summary>
        /// Mapea las propiedades del objeto a una nueva instancia de la entidad
        /// </summary>
        /// <typeparam name="TEntity">Tipo de la entidad a mapear</typeparam>
        /// <param name="dto">Objeto que extiende el metodo</param>
        /// <returns>Entidad resultado</returns>
        public static TEntity ToEntity<TEntity>(this IDTO dto) 
            where TEntity : class, IEntity, new()
        {
            if (dto == null)
                return null;

            return (TEntity)_adapter.Adapt(dto, typeof(TEntity));
        }

        /// <summary>
        /// Mapea las propiedades de una enumeración de objetos a una enumeración de entidades
        /// </summary>
        /// <typeparam name="TEntity">Tipo de la entidad a mapear</typeparam>
        /// <param name="dto">Objeto que extiende el metodo</param>
        /// <returns>Enumeración de entidades resultado</returns>
        public static IEnumerable<TEntity> ToEntities<TEntity>(this IEnumerable<IDTO> dto)
            where TEntity : class, IEntity, new()
        {
            if (dto == null)
                return null;

            return dto.Select(d => d.ToEntity<TEntity>()).ToArray();
        }

        /// <summary>
        /// Mapea las propiedades de una colección de objetos a una colección de entidades
        /// </summary>
        /// <typeparam name="TEntity">Tipo de la entidad a mapear</typeparam>
        /// <param name="dto">Objeto que extiende el metodo</param>
        /// <returns>Colección de entidades resultado</returns>
        public static ICollection<TEntity> ToEntities<TEntity>(this ICollection<IDTO> dto)
            where TEntity : class, IEntity, new()
        {
            if (dto == null)
                return null;

            return dto.Select(d => d.ToEntity<TEntity>()).ToArray();
        }

        /// <summary>
        /// Mapea las propiedades de una lista de objetos a una lista de entidades
        /// </summary>
        /// <typeparam name="TEntity">Tipo de la entidad a mapear</typeparam>
        /// <param name="dto">Objeto que extiende el metodo</param>
        /// <returns>Lista de entidades resultado</returns>
        public static IList<TEntity> ToEntities<TEntity>(this IList<IDTO> dto)
            where TEntity : class, IEntity, new()
        {
            if (dto == null)
                return null;

            return dto.Select(d => d.ToEntity<TEntity>()).ToList();
        }

        /// <summary>
        /// Mapea las propiedades de una arreglo de objetos a una arreglo de entidades
        /// </summary>
        /// <typeparam name="TEntity">Tipo de la entidad a mapear</typeparam>
        /// <param name="dto">Objeto que extiende el metodo</param>
        /// <returns>Arreglo de entidades resultado</returns>
        public static TEntity[] ToEntities<TEntity>(this IDTO[] dto)
            where TEntity : class, IEntity, new()
        {
            if (dto == null)
                return null;

            return dto.Select(d => d.ToEntity<TEntity>()).ToArray();
        }

        #endregion
    }
}
