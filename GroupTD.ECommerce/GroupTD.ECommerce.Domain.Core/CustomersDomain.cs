
using GroupTD.ECommerce.Infraestructure.Interface;

using System.Threading.Tasks;
using System.Collections.Generic;
using GroupTD.ECommerce.Domain.Interface;
using GroupTD.ECommerce.Domain.Entity;

namespace GroupTD.ECommerce.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly ICustomersRepository _customersRepository;
        public CustomersDomain(ICustomersRepository customersRepository) {
            _customersRepository = customersRepository;
        }

        #region Metodos Sincronos
        public bool Insert(Customers customer)
        {
            return _customersRepository.Insert(customer);
        }
        public Customers GetCustomer(string customerId)
        {
            return _customersRepository.GetCustomer(customerId);
        }
        public IEnumerable<Customers> GetAll()
        {
            return _customersRepository.GetAll();
        }
        public bool Delete(string customerId)
        {
            return _customersRepository.Delete(customerId);
        }
        public bool Update(Customers customer)
        {
            if (customer != null)
            {
                return _customersRepository.Update(customer);
            }
            return false;
        }
        #endregion

        #region Metodos Asincronos
        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _customersRepository.DeleteAsync(customerId);
        }
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _customersRepository.GetAllAsync();
        }
        public async  Task<Customers> GetCustomerAsync(string customerId)
        {
            return await _customersRepository.GetCustomerAsync(customerId);   
        }
        public async Task<bool> InsertAsync(Customers customer)
        {
            return await (_customersRepository.InsertAsync(customer));
        }

        public async Task<bool> UpdateAsync(Customers customer)
        {
            if (customer != null)
            {
                return await _customersRepository.UpdateAsync(customer);
            }
            return  await Task.FromResult(false);
        }

        #endregion
    }
}
