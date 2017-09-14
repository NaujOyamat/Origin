using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OriginArqut.Application.Adapters;
using OriginArqut.Application.Adapters.DTO;
using OriginArqut.Domain.Base;
using OriginArqut.Crosscutting.IoC.DI;
using OriginArqut.Domain.Entities;
using OriginArqut.Application.Services.Base;
using OriginArqut.Application.Adapters.Base;

namespace OriginArqut.Application.Services.Inventory
{
    /// <summary>
    /// Implementación del servicio de inventario
    /// </summary>
    public class InventoryAppService : IInventoryAppService
    {
        #region Fields

        /// <summary>
        /// Unidad de trabajo del servicio
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Repositorio de productos
        /// </summary>
        private readonly IRepository<Product> _productRepo;

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="unitOfWork">Unidad de trabajo del servicio</param>
        public InventoryAppService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                new ArgumentNullException("unitOfWork");

            this._unitOfWork = unitOfWork;
            this._productRepo = this._unitOfWork.GetRepository<IRepository<Product>>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// <see cref="IInventoryAppService.GetProductById(int)"/>
        /// </summary>
        public ActionResult<object> GetProductById(int id)
        {
            try
            {
                var res = this._productRepo.GetById(id);
                return new ActionResult<object>() { IsSucessfull = true, Result = res.ToDTO(new ObjectModel("Id", "Code", "Name")) };
            }
            catch (Exception ex)
            {
                //Aqui se le da manejo a las excepciones
                return new ActionResult<object>() { IsError = true, ErrorMessage =  ex.Message};
            }
        }

        /// <summary>
        /// <see cref="IInventoryAppService.ListAllProducts"/>
        /// </summary>
        public ActionResult<IEnumerable<object>> ListAllProducts()
        {
            try
            {
                var res = this._productRepo.ListAll();
                return new ActionResult<IEnumerable<object>>() { IsSucessfull = true, Result = res.ToDTOs(new ObjectModel("Id", "Code", "Name")) };
            }
            catch (Exception ex)
            {
                //Aqui se le da manejo a las excepciones
                return new ActionResult<IEnumerable<object>>() { IsError = true, ErrorMessage = ex.Message };
            }
        }

        #endregion
    }
}
