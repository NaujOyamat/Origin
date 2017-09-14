//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OriginArqut.Domain.Entities
{
    using OriginArqut.Domain.Base;
    using System;
    using System.Collections.Generic;
    
    public partial class Order : IEntity
    {
        public Order()
        {
            this.OrderDetail = new HashSet<OrderDetail>();
        }
    
        public int Id { get; set; }
        public string Code { get; set; }
        //public int IdCustomer { get; set; }
        public string Description { get; set; }
        public System.DateTime DateOrder { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}