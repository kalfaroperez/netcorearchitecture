using AutoMapper;
using GroupTD.ECommerce.Application.DTO;
using GroupTD.ECommerce.Application.Interface;
using GroupTD.ECommerce.Domain.Entity;
using GroupTD.ECommerce.Domain.Interface;
using GroupTD.ECommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupTD.ECommerce.Application.Main
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly ICustomersDomain _customerDomain;
        private IMapper _mapper;
        public CustomerApplication(ICustomersDomain customersDomain, IMapper mapper)
        {
            _customerDomain = customersDomain;
            _mapper = mapper;
        }

        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customerDomain.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customerDomain.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<IEnumerable<CustomersDto>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDto>>();
            try
            {
                var customer = _customerDomain.GetAll();
                
                if (response.Data != null)
                {
                    response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customer);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomersDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDto>>();
            try
            {
                var customers = await _customerDomain.GetAllAsync();
                if (customers != null)
                {
                    response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customers);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<CustomersDto> GetCustomer(string customerId)
        {
            var response = new Response<CustomersDto>();
            try
            {
                var customer = _customerDomain.GetCustomer(customerId);
                if (customer != null)
                {
                    response.Data = _mapper.Map<CustomersDto>(customer);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<CustomersDto>> GetCustomerAsync(string customerId)
        {
            var response = new Response<CustomersDto>();
            try
            {
                var customer = await _customerDomain.GetCustomerAsync(customerId);
                
                if (customer != null)
                {
                    response.Data = _mapper.Map<CustomersDto>(customer);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<bool> Insert(CustomersDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = _customerDomain.Insert(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> InsertAsync(CustomersDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = await _customerDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<bool> Update(CustomersDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = _customerDomain.Update(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitoso!!";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomersDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = await _customerDomain.UpdateAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitoso!!";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
