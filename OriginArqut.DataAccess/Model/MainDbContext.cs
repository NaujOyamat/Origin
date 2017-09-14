using OriginArqut.DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.DataAccess.Model
{
    /// <summary>
    /// Encapsula el contexto principal
    /// </summary>
    public partial class MainDbContext : DbContext, IDbContext
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// <see cref="IDbContext.Context"/>
        /// </summary>
        public DbContext Context { get { return this; } }

        #endregion

        #region Builder

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public MainDbContext() : base("name=MainDbConnection")
        {
            Database.SetInitializer<MainDbContext>(new CreateDatabaseIfNotExists<MainDbContext>());
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }

        #endregion

        #region Methods

        #endregion
    }
}
