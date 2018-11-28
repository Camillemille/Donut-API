using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DounutAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            HttpWebRequest request = WebRequest.CreateHttp("https://grandcircusco.github.io/demo-apis/donuts.json");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:64.0) Gecko/20100101 Firefox/64.0";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //Geeting a response from the server 

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string output = reader.ReadToEnd();
                JObject parser = JObject.Parse(output);


                ViewBag.Donut = parser["results"];
                reader.Close();
                response.Close();
            }
            return View();



        }

        public ActionResult DountTime(string id)
        {
            HttpWebRequest request = WebRequest.CreateHttp($"https://grandcircusco.github.io/demo-apis/donuts/{id}.json");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:64.0) Gecko/20100101 Firefox/64.0";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //Geeting a response from the server 

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string output = reader.ReadToEnd();
                JObject parser = JObject.Parse(output);


                ViewBag.Donut = parser;
                reader.Close();
                response.Close();
            }
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