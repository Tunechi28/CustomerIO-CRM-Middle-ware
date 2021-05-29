using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.IO.Middleware.Api.V1.Requests.CustomerIo
{
    public class CreateCustomer
    {
        public string email { get; set; }
        public string created_at { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssffff");
        public string first_name { get; set; }
        public string plan { get; set; } = "basic";
    }
}
