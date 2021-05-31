using Customer.IO.Middleware.Api.V1.Requests;
using Customer.IO.Middleware.Api.V1.Requests.CustomerIo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

/*
@author Henry Agbasi
*/

namespace Customer.IO.Middleware.Api.Services
{
    public class CustomerIOService : ICustomerIOService
    {
        private readonly HttpClient client;
        private readonly ILogger<CustomerIOService> logger;

        public CustomerIOService(IHttpClientFactory httpClientFactory, ILogger<CustomerIOService> logger)
        {
            client = httpClientFactory.CreateClient("CustomerIOClient");
            this.logger = logger;
        }

        public async Task<bool> CreateCustomer(CreateCustomer customer)
        {
            string url = $"customers/{Guid.NewGuid()}";
            var response = await client.PutAsJsonAsync(url, customer);
            if (response.IsSuccessStatusCode) return true;
            else
            {
                var body = await response.Content.ReadAsStringAsync();
                logger.LogInformation(body);                
            }
            return false;
        }

        public async Task<bool> DeleteCustomer(string identifier)
        {
            string url = $"customers/{identifier}";
            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode) return true;
            else
            {
                var body = await response.Content.ReadAsStringAsync();
                logger.LogInformation(body);
            }
            return false;
        }
    }
}
