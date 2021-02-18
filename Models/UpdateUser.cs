using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2001API.Models
{
    public class UpdateUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        public int id { get; set; }
    }
}
