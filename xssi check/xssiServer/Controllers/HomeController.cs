﻿using System;
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
        //public CookieContainer Cookies = new CookieContainer();
        /*public ActionResult ReqWithCookies()
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.foodiez.com.bd/Home/GetCityFromSession");
            //request.CookieContainer = new CookieContainer();

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Uri target = new Uri("http://localhost/demo/userInformationView.php");

            Cookies.Add(new Cookie("__RequestVerificationToken", "05QKJgFJ8ZGk6KmgD1QR6RjeW1sHUwx5JGERq2NTUW0GXp7Hbu1Cs2cgQmkZ3-QFvynb876pKezKp-CvIoZmYF-8p28365lcvUK0be4eMf81") { Domain = target.Host });
            Cookies.Add(new Cookie("io", "rVBILLp7745vDsrDAAAA") { Domain = target.Host });
            Cookies.Add(new Cookie("PHPSESSID", "ktt4a4eue8cpq60evul997dia1") { Domain = target.Host });


            //Cookies.Add(response.Cookies);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/demo/userInformationView.php");
            request.CookieContainer = Cookies;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string strResponse = reader.ReadToEnd();

            return Json(strResponse, JsonRequestBehavior.AllowGet);
        }*/



        public ActionResult Index()
        {

            return View();

        }

        public ActionResult GetScriptContent()
        {
            var cookies = GetCookie();

            var scripts = Db.GenericScriptHolders.ToList();
            foreach (var s in scripts)
            {
                if (s.Content != null)
                {
                    var withoutLoginContent = ExecuteHttpGet(s.Source);

                    if (!withoutLoginContent.Contains(s.Content))
                    {
                        Db.ScriptHolders.Add(new ScriptHolder
                        {
                            ContentWithLogin = s.Content,
                            ContentWithOutLogin = "",
                            IsDynamic = true,
                            Source = s.Source,
                            Number = s.Number
                        });

                    }
                }
                if (s.Source != null && s.Content == null)
                {
                    var withLoginContent = ExecuteHttpGet(s.Source, cookies);
                    if (string.IsNullOrEmpty(withLoginContent))
                    {
                        continue;
                    }
                    var withoutLoginContent = ExecuteHttpGet(s.Source);
                    var isDynamicContent = IsDynamic(withLoginContent, withoutLoginContent);
                    Db.ScriptHolders.Add(new ScriptHolder
                    {
                        ContentWithLogin = withLoginContent,
                        ContentWithOutLogin = withoutLoginContent,
                        IsDynamic = isDynamicContent,
                        Source = s.Source,
                        Number = s.Number
                    });
                }

                Db.SaveChanges();
            }

            var genericScripts = Db.ScriptHolders.Count();
            var dynamic = Db.ScriptHolders.Where(s => s.IsDynamic).ToList();
            var dynamicCount = dynamic.Count();
            using (var file = new StreamWriter(@"C:\Users\Public\dynamic.txt"))
            {
                var count = 0;
                foreach (var line in dynamic)
                {
                    count++;
                    file.WriteLine(count);
                    file.WriteLine(line.ContentWithLogin);
                    file.WriteLine();
                    file.WriteLine();
                }
            }
            var notdynamic = Db.ScriptHolders.Count(s => !s.IsDynamic);


            return Json(new { genericScripts, dynamicCount, notdynamic});
        }



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
            try
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
            catch (WebException ex)
            {
                return null;
                //HttpWebResponse webResponse = (HttpWebResponse)ex.Response;
                //if (webResponse.StatusCode != HttpStatusCode.OK)
                //{
                //    continue;
                //}
                //else
                //{
                //    throw;
                //}
            }

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
        public ActionResult PostCookies(string cookies, string url)
        {
            Db.CookiesTables.Add(new CookiesTable
            {
                Cookies = cookies,
                TargetUrl = url
            });
            Db.SaveChanges();
            return null;
        }

        public CookieContainer GetCookie()
        {

            var cookieProperty = Db.CookiesTables.ToList().FirstOrDefault();


            var target = new Uri(cookieProperty.TargetUrl);
            var createdCookies = new CookieContainer();

            var splitWithSemicolon = cookieProperty.Cookies.Split(';');
            foreach (var splitted in splitWithSemicolon)
            {
                var cookieValue = splitted.Split('=');
                if (cookieValue.Length > 1)
                {
                    createdCookies.Add(new Cookie(cookieValue[0].Trim(), Server.UrlEncode(cookieValue[1].Trim()))
                    {
                        Domain = target.Host
                    });
                }

            }
            return createdCookies;
        }


        public ActionResult DeleteTableData()
        {
            Db.Database.ExecuteSqlCommand("TRUNCATE TABLE CookiesTable");
            Db.Database.ExecuteSqlCommand("TRUNCATE TABLE ScriptHolder");
            Db.Database.ExecuteSqlCommand("TRUNCATE TABLE GenericScriptHolder");
            return null;
        }


        [HttpPost]
        public ActionResult PostScript(GenericScriptHolder genericScriptHolder)
        {
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