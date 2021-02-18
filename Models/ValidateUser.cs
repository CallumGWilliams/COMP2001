using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2001API.Models
{
    public class ValidateUser
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public int Validated { get; set; }
    }
}
