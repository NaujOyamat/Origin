using OriginArqut.Application.Adapters.DTO;
using OriginArqut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.Mappers
{
    public partial class MapperAdapterFactory
    {
        /// <summary>
        /// Registra todos los adaptadores usados en la arquitectura
        /// </summary>
        /// <param name="mapper">Mapeador de adaptadores</param>
        private void RegisterAdapters(IMapper mapper)
        {
            //Aquí se registra los adaptadores personalizados
            mapper.RegisterAdapter<Product, ProductDTO>((p) => {
                ProductDTO dto = new ProductDTO
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    CategoryName = (p.Product_Category.Count > 0 ? p.Product_Category.FirstOrDefault().Category.Name : "")
                };
                return dto;
            });
        }
    }
}
