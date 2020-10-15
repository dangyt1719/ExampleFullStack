using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login_MVC_.Models
{
    public class UserSkyDns
    {
        public string[] filter { get; set; } // массив идентификаторов запрещенных категорий
        public string[] ip { get; set; } // массив IP
        public string[] whitelist { get; set; } // массив адресов белого списка
        public string[] blacklist { get; set; } // массив адресов черного списка
    }
}