using Customer.IO.Middleware.Api.V1.Requests.CustomerIo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.IO.Middleware.Api.Services
{
    public interface ICustomerIOService
    {
        Task<bool> CreateCustomer(CreateCustomer customer);
        Task<bool> DeleteCustomer(string identifier);

    }
}
