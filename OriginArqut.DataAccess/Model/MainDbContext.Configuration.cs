using OriginArqut.DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.DataAccess.Model
{
    public partial class MainDbContext : DbContext, IDbContext
    {
        #region Configuration

        /// <summary>
        /// Aqui configuramos nuestro modelo
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
