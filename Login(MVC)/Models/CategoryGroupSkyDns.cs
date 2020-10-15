using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login_MVC_.Models
{
    public class CategoryGroupSkyDns
    {
        public string group { get; set; } // название группы
        public Dictionary<string, string> categories { get; set; } // категории
    }
}