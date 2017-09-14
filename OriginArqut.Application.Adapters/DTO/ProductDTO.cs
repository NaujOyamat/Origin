using OriginArqut.Application.Adapters.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.DTO
{
    public class ProductDTO : IDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }

    }
}
