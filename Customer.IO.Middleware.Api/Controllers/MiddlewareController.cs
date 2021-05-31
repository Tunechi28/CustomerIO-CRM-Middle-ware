using Customer.IO.Middleware.Api.Services;
using Customer.IO.Middleware.Api.V1.Requests.CustomerIo;
using Customer.IO.Middleware.Api.V1.Requests.SalesForce;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;#

/*
@author Henry Agbasi
*/

namespace Customer.IO.Middleware.Api.Controllers
{
    [ApiController]
    public class MiddlewareController : ControllerBase
    {
        private readonly ICustomerIOService customerIOService;
        private readonly ILogger<MiddlewareController> logger;

        public MiddlewareController(ICustomerIOService customerIOService, ILogger<MiddlewareController> logger)
        {
            this.customerIOService = customerIOService;
            this.logger = logger;
        }

        [HttpGet("/Test")]
        public IActionResult Get() => Ok("Test");
        
        [HttpPost("/SalesForce")]
        public async Task<IActionResult> HandleSalesForce(SalesForceRequest request)
        {
            switch(request.EventType)
            {
                case EventType.Createcustomer:
                    {
                        var customer = new CreateCustomer
                        {
                            email = request.email,
                            first_name = request.first_name,
                        };
                        await customerIOService.CreateCustomer(customer);
                        break;
                    }
                case EventType.DeleteCustomer:
                    {
                        await customerIOService.DeleteCustomer(request.Identifier);
                        break;
                    }
                default:
                    {
                        logger.LogInformation("Salesforce event type not handled");
                        break;
                    }
            }

            return Ok();
        }
    }    
}
