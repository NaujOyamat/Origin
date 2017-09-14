using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters
{
    /// <summary>
    /// Provee métodos de extensión para distintos tipos
    /// </summary>
    public static class StaticUtilExtensions
    {
        #region Type[]

        /// <summary>
        /// Obtiene el nombre único a partir de todos los tipos que
        /// componen el arreglo
        /// </summary>
        /// <param name="types">Tipo quien extiende el método</param>
        /// <returns>Nombre único</returns>
        public static string GetUniqueName(this Type[] types)
        {
            if (types == null || types.Length == 0)
                return typeof(Type[]).FullName;

            string uniqueName = "";

            foreach (Type t in types)
            {
                uniqueName += (uniqueName == "" ? "" : "+") + t.FullName;
            }

            return uniqueName.ToLower();
        }

        #endregion
    }
}
