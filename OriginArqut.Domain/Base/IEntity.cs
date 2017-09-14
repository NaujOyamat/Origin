using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Domain.Base
{
    /// <summary>
    /// Define las propiedades y comportamientos básicos de una entidad
    /// </summary>
    public interface IEntity
    {
        #region Properties

        /// <summary>
        /// Obtiene o asigna el Id de la entidad
        /// </summary>
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }

        #endregion
    }
}
