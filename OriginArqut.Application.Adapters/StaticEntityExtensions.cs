using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OriginArqut.Application.Adapters.Adapters;
using OriginArqut.Application.Adapters.Base;
using OriginArqut.Domain.Base;

namespace OriginArqut.Application.Adapters
{
    /// <summary>
    /// Provee métodos de extensión para los tipos <see cref="IEntity"/>
    /// </summary>
    public static class StaticEntityExtensions
    {
        #region Adapters

        /// <summary>
        /// Instancia al adaptador estático
        /// </summary>
        private static readonly IAdapter _adapter = new StaAdapter();

        /// <summary>
        /// Instancia al adaptador dinámico
        /// </summary>
        private static readonly IDynamicAdapter _dynAdapter = new DynAdapter();

        #endregion

        #region Methods

        /// <summary>
        /// Mapea las propiedades de la entidad a una nueva instancia de tipo <see cref="IDTO"/>
        /// </summary>
        /// <typeparam name="TDTO">Tipo del objeto DTO destino</typeparam>
        /// <param name="entity">Objeto quien extiende los métodos</param>
        /// <returns>Objeto DTO resultado</returns>
        public static TDTO ToDTO<TDTO>(this IEntity entity)
            where TDTO : class, IDTO, new()
        {
            if (entity == null)
                return null;

            return (TDTO)_adapter.Adapt(entity, typeof(TDTO));
        }

        /// <summary>
        /// Mapea las propiedades de una enumeración de entidades a una enumeración de dtos
        /// </summary>
        /// <typeparam name="TDTO">Tipo del objeto DTO destino</typeparam>
        /// <param name="entities">Objeto quien extiende los métodos</param>
        /// <returns>Enumeración de DTOs resultado</returns>
        public static IEnumerable<TDTO> ToDTOs<TDTO>(this IEnumerable<IEntity> entities)
            where TDTO : class, IDTO, new()
        {
            if (entities == null)
                return null;

            return entities.Select(e => e.ToDTO<TDTO>()).ToArray();
        }

        /// <summary>
        /// Mapea las propiedades de una colección de entidades a una colección de dtos
        /// </summary>
        /// <typeparam name="TDTO">Tipo del objeto DTO destino</typeparam>
        /// <param name="entities">Objeto quien extiende los métodos</param>
        /// <returns>Colección de DTOs resultado</returns>
        public static ICollection<TDTO> ToDTOs<TDTO>(this ICollection<IEntity> entities)
            where TDTO : class, IDTO, new()
        {
            if (entities == null)
                return null;

            return entities.Select(e => e.ToDTO<TDTO>()).ToArray();
        }

        /// <summary>
        /// Mapea las propiedades de una lista de entidades a una lista de dtos
        /// </summary>
        /// <typeparam name="TDTO">Tipo del objeto DTO destino</typeparam>
        /// <param name="entities">Objeto quien extiende los métodos</param>
        /// <returns>Lista de DTOs resultado</returns>
        public static IList<TDTO> ToDTOs<TDTO>(this IList<IEntity> entities)
            where TDTO : class, IDTO, new()
        {
            if (entities == null)
                return null;

            return entities.Select(e => e.ToDTO<TDTO>()).ToList();
        }

        /// <summary>
        /// Mapea las propiedades de un arreglo de entidades a un arreglo de dtos
        /// </summary>
        /// <typeparam name="TDTO">Tipo del objeto DTO destino</typeparam>
        /// <param name="entities">Objeto quien extiende los métodos</param>
        /// <returns>Arreglo de DTOs resultado</returns>
        public static TDTO[] ToDTOs<TDTO>(this IEntity[] entities)
            where TDTO : class, IDTO, new()
        {
            if (entities == null)
                return null;

            return entities.Select(e => e.ToDTO<TDTO>()).ToArray();
        }

        /// <summary>
        /// Mapea las propiedades de la entidad a un nuevo objeto dinámico
        /// </summary>
        /// <param name="entity">Objeto quien extiende los métodos</param>
        /// <param name="model">Objeto modelo usado para construir el objeto dinámico</param>
        /// <returns>Objeto dinámico resultado</returns>
        public static dynamic ToDTO(this IEntity entity, IObjectModel model = null)
        {
            if (entity == null)
                return null;

            return _dynAdapter.Adapt(entity, model);
        }

        /// <summary>
        /// Mapea las propiedades de una enumeración de entidades a una enumeración de dtos
        /// </summary>
        /// <param name="entities">Objeto quien extiende los métodos</param>
        /// <param name="model">Objeto modelo usado para construir el objeto dinámico</param>
        /// <returns>Enumeración de DTOs resultado</returns>
        public static IEnumerable<dynamic> ToDTOs(this IEnumerable<IEntity> entities, IObjectModel model = null)
        {
            if (entities == null)
                return null;

            return entities.Select(e => e.ToDTO(model)).ToArray();
        }

        /// <summary>
        /// Mapea las propiedades de una colección de entidades a una colección de dtos
        /// </summary>
        /// <param name="entities">Objeto quien extiende los métodos</param>
        /// <param name="model">Objeto modelo usado para construir el objeto dinámico</param>
        /// <returns>Colección de DTOs resultado</returns>
        public static ICollection<dynamic> ToDTOs(this ICollection<IEntity> entities, IObjectModel model = null)
        {
            if (entities == null)
                return null;

            return entities.Select(e => e.ToDTO(model)).ToArray();
        }

        /// <summary>
        /// Mapea las propiedades de una lista de entidades a una lista de dtos
        /// </summary>
        /// <param name="entities">Objeto quien extiende los métodos</param>
        /// <param name="model">Objeto modelo usado para construir el objeto dinámico</param>
        /// <returns>Lista de DTOs resultado</returns>
        public static IList<dynamic> ToDTOs(this IList<IEntity> entities, IObjectModel model = null)
        {
            if (entities == null)
                return null;

            return entities.Select(e => e.ToDTO(model)).ToList();
        }

        /// <summary>
        /// Mapea las propiedades de un arreglo de entidades a un arreglo de dtos
        /// </summary>
        /// <param name="entities">Objeto quien extiende los métodos</param>
        /// <param name="model">Objeto modelo usado para construir el objeto dinámico</param>
        /// <returns>Arreglo de DTOs resultado</returns>
        public static dynamic[] ToDTOs(this IEntity[] entities, IObjectModel model = null)
        {
            if (entities == null)
                return null;

            return entities.Select(e => e.ToDTO(model)).ToArray();
        }

        #endregion
    }
}
