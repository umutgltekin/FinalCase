using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Schema
{
    public class UserResuest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }

    }
    public class UserResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }

        public List<AdressResponse> Addresses { get; set; }
        public  List<OrderResponse> Orders { get; set; }
    }
}
