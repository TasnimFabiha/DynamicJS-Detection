using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using xssiServer.Models;

namespace xssiServer.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index(ScriptHolder scriptHolder)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.foodiez.com.bd/Home");
            request.CookieContainer = new CookieContainer();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //var cookies = new CookieContainer();
            //cookies.Add(response.Cookies);

            //request = (HttpWebRequest)WebRequest.Create(secondUrlWithParameters);
            //request.CookieContainer = cookies;



            ApplicationDbContext db = new ApplicationDbContext();
            db.ScriptHolders.Add(scriptHolder);
            db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}