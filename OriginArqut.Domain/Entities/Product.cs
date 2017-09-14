using OriginArqut.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Domain.Entities
{
    public class Product : IEntity
    {
        public Product()
        {
            this.OrderDetail = new HashSet<OrderDetail>();
            this.Product_Category = new HashSet<Product_Category>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<Product_Category> Product_Category { get; set; }
    }
}
