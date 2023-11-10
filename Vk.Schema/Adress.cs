using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Schema
{
    public class AdressRequest
    {
        public int UserId { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; } 
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
    public class AdressResponse
    {
        public int UserId { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public  string UserName { get; set; }

    }
}
