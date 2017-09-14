using OriginArqut.Application.Adapters.DTO;
using OriginArqut.Application.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Services.Inventory
{
    /// <summary>
    /// Define los atributos y comportamientos de un servicio de inventario
    /// </summary>
    public interface IInventoryAppService
    {
        /// <summary>
        /// Lista todos los productos
        /// </summary>
        /// <returns>Lista de todos los productos</returns>
        ActionResult<IEnumerable<object>> ListAllProducts();

        /// <summary>
        /// Obtiene un producto por su id
        /// </summary>
        /// <param name="id">Id del producto</param>
        /// <returns>Producto consultado</returns>
        ActionResult<object> GetProductById(int id);
    }
}
