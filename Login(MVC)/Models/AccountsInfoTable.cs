using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login_MVC_.Models
{
    public class AccountsInfoTable
    {
        public string Account { get; set; }
        public long Balance { get; set; }
        public long Current_Reserve { get; set; }
        public long Total_Reserve { get; set; }
        public long Total_Balance { get; set; }
        public long Credit_Limit { get; set; }
        public decimal RecommendedPay { get; set; }
        public int AccountsCount { get; set; }

    }
}