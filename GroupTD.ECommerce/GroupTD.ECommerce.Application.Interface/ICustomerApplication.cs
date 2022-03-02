using GroupTD.ECommerce.Application.DTO;
using GroupTD.ECommerce.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupTD.ECommerce.Application.Interface
{
    public interface ICustomerApplication
    {
        #region Metodos Sincronos
        Response<bool> Insert(CustomersDto customerDto);
        Response<bool> Update(CustomersDto customerDto);
        Response<bool> Delete(string customerId);
        Response<CustomersDto> GetCustomer(string customerId);
        Response<IEnumerable<CustomersDto>> GetAll();
        #endregion

        #region Metodos Asincronos
        Task<Response<bool>> InsertAsync(CustomersDto customerDto);
        Task<Response<bool>> UpdateAsync(CustomersDto customerDto);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomersDto>> GetCustomerAsync(string customerId);
        Task<Response<IEnumerable<CustomersDto>>> GetAllAsync();
        #endregion
    }
}
