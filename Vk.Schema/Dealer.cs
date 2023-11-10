﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Schema
{
    public class DealerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
    }
    public class DealerResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public List<ProductResponse> Products { get; set; }
    }
}
