using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace Login_MVC_.Models
{
    public class Account
    {
 
        public string Name { get; set; }
        public string Password { get; set; }
        public string FULLNAME { get; set; }
        public long Subject_id { get; set; }
        public string Token { get; set; }
        public long Base_Subject_Id { get; set; }

      
    }
}