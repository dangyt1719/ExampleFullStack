using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_MVC_.Models;
using System.Data;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;
using static System.Web.HttpContext;
using Newtonsoft.Json;
namespace Login_MVC_.Controllers
{
    public class HomeController : Controller
    {
        
       
        // GET: Home

        public ActionResult Index()
        {
            try
            {
                Account_Curr_User qqq = new Account_Curr_User();
                Models.SubjectAddress qqq2 = new Models.SubjectAddress();
                Models.SubjectAddress qqq3 = new Models.SubjectAddress();
                Models.RecommendedPayRow qqq4 = new Models.RecommendedPayRow();
                System.Web.HttpContext currentContext = System.Web.HttpContext.Current;
                ///<summary>
                ///Получение имени абонента
                /// </summary>
                using (var client = new HttpClient())
                {
                    string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
                    client.BaseAddress = new Uri("https://172.16.0.60");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", currentContext.Session["Token"].ToString());
                    var responseTask = client.GetAsync("/api/customers/" + Session["accountData"]);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Account_Curr_User>();
                        readTask.Wait();
                        var ls = readTask.Result;
                        qqq = readTask.Result;
                        ViewData["UserInfo"] = qqq.VC_BASE_SUBJECT_NAME;
                    }
                }
                ///<summary>
                ///Получение номера тел абонента
                /// </summary>
                using (var client2 = new HttpClient())
                {
                    string baseApiAddress2 = ConfigurationManager.AppSettings["baseApiAddress"];
                    client2.BaseAddress = new Uri("https://172.16.0.60");
                    client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Token"].ToString());
                    var responseTask2 = client2.GetAsync("/api/SubjectAddressPhone/" + Session["BaseSubjID"]);
                    responseTask2.Wait();
                    var result2 = responseTask2.Result;
                    if (result2.IsSuccessStatusCode)
                    {
                        var readTask2 = result2.Content.ReadAsAsync<Models.SubjectAddress>();
                        readTask2.Wait();
                        var ls = readTask2.Result;
                        qqq2 = readTask2.Result;
                        if (qqq2.VC_VISUAL_CODE != null)
                        {
                            ViewData["UserInfo2"] = qqq2.VC_VISUAL_CODE;
                        }
                        else
                        {
                            ViewData["UserInfo2"] = "-";
                        }

                    }
                }
                ///<summary>
                ///Получение почтового адреса
                /// </summary>
                using (var client3 = new HttpClient())
                {
                    string baseApiAddress3 = ConfigurationManager.AppSettings["baseApiAddress"];
                    client3.BaseAddress = new Uri("https://172.16.0.60");
                    client3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client3.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Token"].ToString());
                    var responseTask3 = client3.GetAsync("/api/SubjectAddressEmail/" + Session["BaseSubjID"]);
                    responseTask3.Wait();
                    var result3 = responseTask3.Result;
                    if (result3.IsSuccessStatusCode)
                    {
                        var readTask3 = result3.Content.ReadAsAsync<Models.SubjectAddress>();
                        readTask3.Wait();
                        var ls = readTask3.Result;
                        qqq3 = readTask3.Result;
                        if (qqq3.VC_VISUAL_CODE != null)
                        {
                            ViewData["UserInfo3"] = qqq3.VC_VISUAL_CODE;
                        }
                        else
                        {
                            ViewData["UserInfo3"] = "-";
                        }
                    }
                }
                ///<summary>
                ///Получение списка оконченых оборудований для БИ
                /// </summary>
                Load_UserServices();
            }
            catch
            {
                RedirectToRoute(new { controller = "Account", action = "Login" });
            }      
            return View();
        }

        ///<summary>
        ///Получение списка оконченых оборудований для БИ
        /// </summary>
        public ActionResult Load_UserServices()
        {
            List<Models.CustomerServices> qqq = new List<Models.CustomerServices>();
            List<Models.CategoryGroupSkyDns> qqq4 = new List<Models.CategoryGroupSkyDns>();
            decimal d = 0;

              var te = new
            {
                RecommendedPay = "-",
                AccountsCount = "-"
            };
            using (var client = new HttpClient())
            {
                string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
                client.BaseAddress = new Uri("https://172.16.0.60");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Token"].ToString());

                var responseTask = client.GetAsync("/api/CustomerServicesPPPoE/" + Session["accountData"]);
                var responseTask2 = client.GetAsync("/api/CategoriesSkyDNS");
                
                responseTask.Wait();
                responseTask2.Wait();

                var result = responseTask.Result;
                var result2 = responseTask2.Result;

                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.CustomerServices>>();
                    var readTask2 = result2.Content.ReadAsAsync<Dictionary<string,string>>();
                    readTask.Wait();
                    readTask2.Wait();
                    var ls = readTask.Result;
                    var ls2 = readTask2.Result;
                    qqq = readTask.Result;
                    ViewBag.CtgrsSkyDns = ls2;
                }

                var model = qqq;

                return View(qqq);
            }
        }

        /// <summary>
        ///  Сохранение фильтров БИ
        /// </summary>
        [HttpPost]
        public ActionResult SaveSkyDns (string[] name, string skydns)
        {
            var getvalue = name;
            Models.UserSkyDns userSkyDns = new UserSkyDns();

            userSkyDns.filter = name;

            using (var client = new HttpClient())
            {
                string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
                client.BaseAddress = new Uri("https://172.16.0.60");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Token"].ToString());

                var responseTask = client.GetAsync("/api/CustomerServicesPPPoE/" + Session["accountData"]);
                var responseTask2 = client.PutAsJsonAsync("/api/userSkyDns/"+ skydns+"/filter", name);

                //   var responseTask = client.GetAsync("/api/accounts/567911991");
                responseTask.Wait();
                responseTask2.Wait();

                var result = responseTask.Result;
                var result2 = responseTask2.Result;


                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.CustomerServices>>();
                    var readTask2 = result2.Content.ReadAsAsync<Dictionary<string, string>>();

                    readTask.Wait();
                    readTask2.Wait();

                    var ls = readTask.Result;
                    var ls2 = readTask2.Result;

                    ViewBag.CtgrsSkyDns = ls2;

                }
            }
            return Redirect(Request.UrlReferrer.ToString());
         //   return RedirectToAction("Index", "Home");
        }
        /// <summary>
        ///  Сохранение ЧБ БИ
        /// </summary>
        [HttpPost]
        public JsonResult SaveSkyDnsBlkLst(string[] name, string skydns)
        {
            var getvalue = name;
            Models.UserSkyDns userSkyDns = new UserSkyDns();
            bool Save_Result = false;
            userSkyDns.filter = name;

            using (var client = new HttpClient())
            {
                string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
                client.BaseAddress = new Uri("https://172.16.0.60");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Token"].ToString());

                var responseTask = client.GetAsync("/api/CustomerServicesPPPoE/" + Session["accountData"]);
                var responseTask2 = client.PostAsJsonAsync("/api/userSkyDns/" + skydns + "/blacklist/", name);

                //   var responseTask = client.GetAsync("/api/accounts/567911991");
                responseTask.Wait();
                responseTask2.Wait();

                var result = responseTask.Result;
                var result2 = responseTask2.Result;


                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.CustomerServices>>();
                    var readTask2 = result2.Content.ReadAsAsync<Dictionary<string, string>>();

                    readTask.Wait();
                    readTask2.Wait();

                    var ls = readTask.Result;
                    var ls2 = readTask2.Result;
                    Save_Result = true;
                    ViewBag.CtgrsSkyDns = ls2;

                }
            }
            return Json(Save_Result, JsonRequestBehavior.AllowGet);
            //   return RedirectToAction("Index", "Home");
        }
        /// <summary>
        ///  Удаление ресурса из ЧБ БИ
        /// </summary>
        [HttpPost]
        public JsonResult DeleteSkyDnsBlkLst(string[] name, string skydns)
        {
            var getvalue = name;
            Models.UserSkyDns userSkyDns = new UserSkyDns();
            bool Delete_Result = false;
            userSkyDns.filter = name;

            using (var client = new HttpClient())
            {
                string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
                client.BaseAddress = new Uri("https://172.16.0.60");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Token"].ToString());
                string userID = skydns.Remove(skydns.Length - 1);
                var responseTask = client.GetAsync("/api/CustomerServicesPPPoE/" + Session["accountData"]);
                var responseTask2 = client.DeleteAsync("/api/userSkyDns/" + skydns + "/blacklist/"+name[0]);
        
                //   var responseTask = client.GetAsync("/api/accounts/567911991");
                responseTask.Wait();
                responseTask2.Wait();

                var result = responseTask.Result;
                var result2 = responseTask2.Result;


                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.CustomerServices>>();
                    var readTask2 = result2.Content.ReadAsAsync<Dictionary<string, string>>();

                    readTask.Wait();
                    readTask2.Wait();

                    var ls = readTask.Result;
                    var ls2 = readTask2.Result;

                    ViewBag.CtgrsSkyDns = ls2;
                    Delete_Result = true;
              
                }
            }
            return Json(Delete_Result, JsonRequestBehavior.AllowGet);
            //   return RedirectToAction("Index", "Home");
        }
        /// <summary>
        ///  Сохранение БС БИ
        /// </summary>
        [HttpPost]
        public JsonResult SaveSkyDnsWhtLst(string[] name, string skydns)
        {
            var getvalue = name;
            Models.UserSkyDns userSkyDns = new UserSkyDns();
            bool Save_Result = false;
            userSkyDns.filter = name;

            using (var client = new HttpClient())
            {
                string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
                client.BaseAddress = new Uri("https://172.16.0.60");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Token"].ToString());

                var responseTask = client.GetAsync("/api/CustomerServicesPPPoE/" + Session["accountData"]);
                var responseTask2 = client.PostAsJsonAsync("/api/userSkyDns/" + skydns + "/whitelist/", name);

                //   var responseTask = client.GetAsync("/api/accounts/567911991");
                responseTask.Wait();
                responseTask2.Wait();

                var result = responseTask.Result;
                var result2 = responseTask2.Result;


                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.CustomerServices>>();
                    var readTask2 = result2.Content.ReadAsAsync<Dictionary<string, string>>();

                    readTask.Wait();
                    readTask2.Wait();

                    var ls = readTask.Result;
                    var ls2 = readTask2.Result;
                    Save_Result = true;
                    ViewBag.CtgrsSkyDns = ls2;

                }
            }
            return Json(Save_Result, JsonRequestBehavior.AllowGet);
            //   return RedirectToAction("Index", "Home");
        }
        /// <summary>
        ///  Удаление ресурса из БС БИ
        /// </summary>
        [HttpPost]
        public JsonResult DeleteSkyDnsWhtLst(string[] name, string skydns)
        {
            var getvalue = name;
            Models.UserSkyDns userSkyDns = new UserSkyDns();
            bool Delete_Result = false;
            userSkyDns.filter = name;

            using (var client = new HttpClient())
            {
                string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
                client.BaseAddress = new Uri("https://172.16.0.60");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Token"].ToString());
                string userID = skydns.Remove(skydns.Length - 1);
                var responseTask = client.GetAsync("/api/CustomerServicesPPPoE/" + Session["accountData"]);
                var responseTask2 = client.DeleteAsync("/api/userSkyDns/" + skydns + "/whitelist/" + name[0]);

                //   var responseTask = client.GetAsync("/api/accounts/567911991");
                responseTask.Wait();
                responseTask2.Wait();

                var result = responseTask.Result;
                var result2 = responseTask2.Result;


                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.CustomerServices>>();
                    var readTask2 = result2.Content.ReadAsAsync<Dictionary<string, string>>();

                    readTask.Wait();
                    readTask2.Wait();

                    var ls = readTask.Result;
                    var ls2 = readTask2.Result;

                    ViewBag.CtgrsSkyDns = ls2;
                    Delete_Result = true;
                }
            }
            return Json(Delete_Result, JsonRequestBehavior.AllowGet);
            //   return RedirectToAction("Index", "Home");
        }

        /// <summary>
        ///  Получение Фильтров, ЧБ и БС БИ абонента
        /// </summary>
        public Models.UserSkyDns SkyDnsFilters(Models.CustomerServices customerServices, HttpSessionStateBase sessionStateBase)
        {

            Models.UserSkyDns qqq = new Models.UserSkyDns();


            using (var client = new HttpClient())
            {
                string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
                client.BaseAddress = new Uri("https://172.16.0.60");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionStateBase["Token"].ToString());

                var responseTask = client.GetAsync("/api/UserSkyDNS/" + customerServices.VC_LOGIN);

                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Models.UserSkyDns>();

                    readTask.Wait();

                    var ls = readTask.Result;

                    qqq = readTask.Result;
                }

                var model = qqq;

                return qqq;
            }           
        }
        /// <summary>
        ///  Получение ЧС БИ 
        /// </summary>
        public JsonResult BlkList(string customerServices, string sessionStateBase)
        {

            Models.UserSkyDns qqq = new Models.UserSkyDns();
            string[] blklist2 = null;
            List<BWLists> blklist = new List<BWLists>();
            using (var client = new HttpClient())
            {
                string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
                client.BaseAddress = new Uri("https://172.16.0.60");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionStateBase.ToString());

                var responseTask = client.GetAsync("/api/UserSkyDNS/" + customerServices);

                //   var responseTask = client.GetAsync("/api/accounts/567911991");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Models.UserSkyDns>();

                    readTask.Wait();

                    var ls = readTask.Result;

                    qqq = readTask.Result;
                }

                var model = qqq;
                blklist2 = qqq.blacklist;
                //  blklist =blklist2.ToList();
                BWLists bWLists = new BWLists();
                if(blklist2==null)
                {
                    blklist = null;
                }
                else
                {
                    foreach (string s in blklist2)
                    {
                        bWLists.name = s;
                        blklist.Add(bWLists);
                        bWLists = new BWLists();
                    }
                }
              
              
                //  blklist.Add(qqq.blacklist);
                return Json(blklist, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        ///  Получение БС БИ
        /// </summary>
        public JsonResult WhtList(string customerServices, string sessionStateBase)
        {

            Models.UserSkyDns qqq = new Models.UserSkyDns();
            string[] whtlist2 = null;
            List<BWLists> whtlist = new List<BWLists>();
            using (var client = new HttpClient())
            {
                string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
                client.BaseAddress = new Uri("https://172.16.0.60");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionStateBase.ToString());

                var responseTask = client.GetAsync("/api/UserSkyDNS/" + customerServices);

                //   var responseTask = client.GetAsync("/api/accounts/567911991");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Models.UserSkyDns>();

                    readTask.Wait();

                    var ls = readTask.Result;

                    qqq = readTask.Result;
                }

                var model = qqq;
                whtlist2 = qqq.whitelist;
                //  blklist =blklist2.ToList();
                BWLists bWLists = new BWLists();
                if(whtlist2==null)
                {
                    whtlist = null;
                }
                else
                {
                    foreach (string s in whtlist2)
                    {
                        bWLists.name = s;
                        whtlist.Add(bWLists);
                        bWLists = new BWLists();
                    }

                }
                

                //  blklist.Add(qqq.blacklist);
                return Json(whtlist, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        ///  Получение таблицы списка лицевых счетов абонента
        /// </summary>
        public JsonResult Load_userinfotable(Models.Accounts accs)
        {
            List<Models.Accounts> qqq = new List<Models.Accounts>();
            Models.RecommendedPayRow qqq4 = new Models.RecommendedPayRow();
            decimal d = 0;
            var te = new
            {
                RecommendedPay = "-",
                AccountsCount = "-"
            };
            using (var client = new HttpClient())
            {
                string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
                client.BaseAddress = new Uri("https://172.16.0.60");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Token"].ToString());

                var responseTask = client.GetAsync("/api/CustomerAccounts/" + Session["accountData"]);
                //   var responseTask = client.GetAsync("/api/accounts/567911991");
                responseTask.Wait();

                var result = responseTask.Result;


                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.Accounts>>();

                    readTask.Wait();

                    var ls = readTask.Result;

                    qqq = readTask.Result;

                    for (int i = 0; i < qqq.Count; i++)
                    {
                        d += MyFunc(qqq[i].N_ACCOUNT_ID.ToString());

                    }
                    AccountsInfoTable qwe = new AccountsInfoTable();
                    qwe.Credit_Limit = Convert.ToInt64(d);
                    
                }
                AccountsInfoTable accountsInfoTable = new AccountsInfoTable();
                accountsInfoTable.RecommendedPay = d;
                accountsInfoTable.AccountsCount = qqq.Count;

                

                return Json(accountsInfoTable, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        ///  Получение таблицы списка лицевых счетов абонента
        /// </summary>
        public JsonResult Load_infotable(Models.Accounts accs)
    {
        List<Models.Accounts> qqq = new List<Models.Accounts>();
        Models.RecommendedPayRow qqq4 = new Models.RecommendedPayRow();
        decimal d = 0;
            decimal q = 0;
        using (var client = new HttpClient())
        {
            string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
            client.BaseAddress = new Uri("https://172.16.0.60");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Token"].ToString());

            var responseTask = client.GetAsync("/api/CustomerAccounts/" + Session["accountData"]);
            //   var responseTask = client.GetAsync("/api/accounts/567911991");
            responseTask.Wait();

            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Models.Accounts>>();

                readTask.Wait();

                var ls = readTask.Result;

                qqq = readTask.Result;

                for (int i = 0; i < qqq.Count; i++)
                {
                    d = MyFunc(qqq[i].N_ACCOUNT_ID.ToString());
                    
                    qqq[i].RecPay = d;
                }
            }
            return Json(qqq, JsonRequestBehavior.AllowGet);         
        }
    }
        /// <summary>
        /// Получение общего рекомендуемого платежа
        /// </summary>
        public decimal MyFunc(string s)
        {
            List<Models.RecommendedPayRow> lsq = new List<Models.RecommendedPayRow>();
            decimal a = 0;
            using (var client4 = new HttpClient())
            {
                string baseApiAddress4 = ConfigurationManager.AppSettings["baseApiAddress"];
                client4.BaseAddress = new Uri("https://172.16.0.60");
                client4.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client4.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Token"].ToString());
                var responseTask4 = client4.GetAsync("/api/AccountRecommendedPaySum/"+s);
                responseTask4.Wait();
                var result4 = responseTask4.Result;
                if (result4.IsSuccessStatusCode)
                {
                    var readTask4 = result4.Content.ReadAsAsync<decimal>();
                    readTask4.Wait();
                   
                    a= readTask4.Result;
                    
                }
            }
            return a;
        }

        
    }
}
        
  
