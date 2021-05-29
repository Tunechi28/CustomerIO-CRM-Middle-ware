using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.IO.Middleware.Api.V1.Requests.SalesForce
{
    public class SalesForceRequest
    {
        public EventType EventType { get; set; }
        public string email { get; set; }        
        public string first_name { get; set; }
        public string plan { get; set; }
        public string Identifier { get; set; }
    }
}
