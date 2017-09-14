using OriginArqut.Domain.Entities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OriginArqut.DataAccess.Base;

namespace OriginArqut.DataAccess.Model
{
    public partial class MainDbContext : DbContext, IDbContext
    {
        #region Entidades

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Product_Category> Product_Category { get; set; }

        #endregion
    }
}
