using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using xssiServer.Models;

namespace xssiServer.Controllers
{
    public class HomeController : Controller
    {

        ApplicationDbContext Db = new ApplicationDbContext();
        CookieContainer Cookies = new CookieContainer();
        public ActionResult ReqWithCookies()
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.foodiez.com.bd/Home/GetCityFromSession");
            //request.CookieContainer = new CookieContainer();

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Uri target = new Uri("http://www.foodiez.com.bd/");

            Cookies.Add(new Cookie("ASP.NET_SessionId", "wvlswgtgmf2ylobjn2kwap4v") { Domain = target.Host });
            Cookies.Add(new Cookie("_ga", "GA1.3.1782506910.1507891453") { Domain = target.Host });
            Cookies.Add(new Cookie("_gat", "1") { Domain = target.Host });
            Cookies.Add(new Cookie("_gid", "GA1.3.803010448.1508076781") { Domain = target.Host });
            Cookies.Add(new Cookie("DhakaFoodiesAuthCookie", "39E4E05A351EC4D68794E92E5700A7079E6BD5FC41E44BAA8F36B746F6C6F797F79931C95C5F5EE4AAFCF31B3196D311BFE2636BB2E783D796BEFB0E1CC9AB239E738866F2A66A2ACA8AED7104BACA268B3E6B9890DB81BBCD7EAA5BF095E724BDFD3B5FAC6BA816998FB9C1F71C10B4CF6FB670") { Domain = target.Host });


            //cookies.Add(response.Cookies);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.foodiez.com.bd/Home/GetCityFromSession");
            request.CookieContainer = Cookies;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string strResponse = reader.ReadToEnd();

            return Json(strResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {

            return View();

        }

        public ActionResult GetScriptContent()
        {

            var scripts = Db.GenericScriptHolders.ToList();
            foreach (var s in scripts)
            {
                if (s.Source != null && !s.Source.Contains("facebook"))
                {
                    var withoutLoginContent = ExecuteHttpGet(s.Source);
                    var withLoginContent = ExecuteHttpGet(s.Source, Cookies);
                    var isDynamicContent = IsDynamic(withLoginContent, withoutLoginContent);
                    Db.ScriptHolders.Add(new ScriptHolder
                    {
                        ContentWithLogin = withLoginContent,
                        ContentWithOutLogin = withoutLoginContent,
                        IsDynamic = isDynamicContent

                });
                }
                Db.SaveChanges();
            }
            return null;
        }

        /*public void GetScriptContentStatic(CookieContainer cookies = null)
        {
            var source = "http://www.foodiez.com.bd";
            var withLogin = ExecuteHttpGet(source, cookies);
            var withoutLogin = ExecuteHttpGet(source);
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine(withoutLogin);
            Debug.WriteLine(withLogin);

            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine("");
        }*/

        public bool IsDynamic(string withLogin, string withoutLogin)
        {
            
            //var scrptingEngine = new Jint.Engine();
            /*var s = scrptingEngine.Execute(withLogin);
            Debug.WriteLine(s);*/
            /*var parsewithLogin = scrptingEngine.Execute(withLogin);
            var parsewithoutLogin = scrptingEngine.Execute(withoutLogin);*/

            //var result = !parsewithLogin.Equals(parsewithoutLogin);
                //!scrptingEngine.Execute(withLogin).Equals(scrptingEngine.Execute(withoutLogin));
            var result = !withLogin.Equals(withoutLogin);
            Debug.WriteLine(result);
            return result;

        }
        public string ExecuteHttpGet(string url, CookieContainer cookies = null)
        {
            var strResponse = "";
            if (url != null && !url.Contains("facebook"))
            {
                //http://www.foodiez.com.bd/App_Style/js/custom/PageScripts/Utils.js?06012016
                Uri baseUri = new Uri(url);
                //Uri myUri = new Uri(baseUri, "App_Style/js/custom/PageScripts/Utils.js?06012016");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUri);
                if (cookies != null)
                {
                    request.CookieContainer = cookies;
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                strResponse = reader.ReadToEnd();
            }
            return strResponse;
        }

        public ActionResult Edit([Bind(Include = "Id,ContentWithLogin,ContentWithOutLogin")] ScriptHolder scriptHolder)
        {
            if (ModelState.IsValid)
            {
                /* Db.Entry(scriptHolder).State = EntityState.Modified;
                 Db.SaveChanges();
                 return RedirectToAction("Index");*/
            }
            return View(scriptHolder);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult PostScript(GenericScriptHolder genericScriptHolder)
        {
            ViewBag.Message = "Your contact page.";
            if (genericScriptHolder.Source != null)
            {
                if (!genericScriptHolder.Source.Contains("angular") && !genericScriptHolder.Source.Contains("jquery") &&
                    !genericScriptHolder.Source.Contains("bootstrap") && !genericScriptHolder.Source.Contains("facebook"))
                {
                    Db.GenericScriptHolders.Add(genericScriptHolder);
                    Db.SaveChanges();
                }
            }
            else
            {
                Db.GenericScriptHolders.Add(genericScriptHolder);
                Db.SaveChanges();
            }

            return null;
        }
    }
}