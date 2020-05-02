using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyTemplate.Models.Account
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string Error { get; set; }
    }
}