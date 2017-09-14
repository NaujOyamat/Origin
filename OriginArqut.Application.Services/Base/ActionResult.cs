using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OriginArqut.Application.Services.Base
{
    /// <summary>
    /// Encapsula el resultado de la ejecución de una acción en el servicio
    /// </summary>
    /// <typeparam name="TResult">Tipo del objeto resultado de la acción</typeparam>
    public class ActionResult<TResult>
    {
        #region Properties

        /// <summary>
        /// Obtiene o asigna un valor que indica si la acción terminó
        /// de forma exitosa o no
        /// </summary>
        public bool IsSucessfull { get; set; }

        /// <summary>
        /// Obtiene o asigna un valor que indica si ocurrió un error
        /// no controlado al ejecutar la acción
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Obtiene o asigna el mensaje del error que ocurrió al
        /// ejecutar la acción
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Obtiene o asigna un conjunto de mensajes que se pueden generar
        /// al ejecutar la acción
        /// </summary>
        public IEnumerable<string> Messages { get; set; }

        /// <summary>
        /// Obtiene o asigna el objeto resultado de la acción
        /// </summary>
        public TResult Result { get; set; }

        #endregion
    }
}