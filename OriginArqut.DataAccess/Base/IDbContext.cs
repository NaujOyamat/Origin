using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.DataAccess.Base
{
    /// <summary>
    /// Define los atributos y comportamientos de un contexto de base de datos
    /// </summary>
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// Obtiene el contexto interno
        /// </summary>
        DbContext Context { get; }
    }
}
