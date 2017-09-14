using OriginArqut.Application.Services.Base;
using OriginArqut.Application.Services.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OriginArqut.WebServices.Api.Controllers
{
    public class ProductController : ApiController
    {
        #region Fields

        /// <summary>
        /// Servicio de aplicación de inventario
        /// </summary>
        private readonly IInventoryAppService _inventoryAppService;

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="inventoryAppService">Servicio de aplicación de inventario</param>
        public ProductController(IInventoryAppService inventoryAppService) : base()
        {
            if (inventoryAppService == null)
                new ArgumentNullException("inventoryAppService");

            this._inventoryAppService = inventoryAppService;
        }

        //public ProductController()
        //{
        //}

        #endregion

        #region Methods

        /// <summary>
        /// Obtiene un producto por su id
        /// </summary>
        /// <param name="id">Id del producto</param>
        /// <returns>Producto</returns>
        [HttpGet]
        [Route("api/Product/GetProductById")]
        public ActionResult<object> GetProductById(int id)
        {
            return this._inventoryAppService.GetProductById(id);
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns>Listado de productos</returns>
        [HttpGet]
        [Route("api/Product/ListAllProducts")]
        public ActionResult<IEnumerable<object>> ListAllProducts()
        {
            return this._inventoryAppService.ListAllProducts();
        }

        #endregion
    }
}
