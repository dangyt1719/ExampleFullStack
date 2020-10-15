using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Configuration;
using System.Web.SessionState;
using Login_MVC_.Models;
using System.Data;
using System.Web.UI;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Web.Script.Serialization;
using static System.Web.HttpContext;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Web.SessionState;



namespace Login_MVC_.Controllers
{
    public class AccountController : Controller
    {
        DataSet ds = new DataSet();
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LogOut()
        {

            Session.Remove("User");
            Session.Abandon();
            Session.Contents.RemoveAll();

            Session.Clear();

            ViewBag.scripCall = "OceniNas";
            return RedirectToRoute(new { controller = "Account", action = "Login" });
        }

        [HttpPost]
        public ActionResult VerifyAsync(Models.Account account)
        {
                try
                {
                    System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();

                    using (var client = new HttpClient())
                    {
                        string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
                        client.BaseAddress = new Uri("https://172.16.0.60");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("UTF-8").GetBytes(account.Name + ":" + account.Password));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);
                        var stringContent = new StringContent("{ \"secret\": \"q-123\" }", System.Text.Encoding.UTF8, "application/json");

                        client.DefaultRequestHeaders.Add("secret", "q-123");

                        StringContent content = new StringContent(JsonConvert.SerializeObject(account));
                        
                        HttpResponseMessage postTask = client.PostAsJsonAsync("/api/auth?secret=q-123", account).Result;

                        if (postTask.IsSuccessStatusCode)
                        {
                            var jObj2 = JsonConvert.DeserializeObject<List<string>>(postTask.Content.ReadAsStringAsync().Result);
                            account.Token = jObj2[0];
                            account.Subject_id = Convert.ToInt64(jObj2[1]);
                            Session["UserID"] = account.Subject_id;
                            Session["token"] = account.Token;
                            Session["accountData"] = account.Subject_id;
                            Session["BaseSubjID"] = Convert.ToInt64(jObj2[2]);

                       SessionIDManager Manager = new SessionIDManager();

                        Session["User"] = account.Name;
                        Session["Token"] = account.Token;
                        return RedirectToRoute(new { controller = "Home", action = "Index"});
                        }
                        else
                        {
                        ViewBag.Message = "Неправильное имя пользователя или пароль! Попробуйте еще раз!";
                        return View("Login");
                        }

                    }
                }
                catch (Exception e)
                {
              
                   
                    return View("Error");
                }

            
        }
    }
    
    public class TrustAllCertificatePolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint sp,
         X509Certificate cert, WebRequest req, int problem)
        {
            return true;
        }
    }
    public class jsondate
    {
        string token { get; set; }
        string pass { get; set; }
    }
   
}
