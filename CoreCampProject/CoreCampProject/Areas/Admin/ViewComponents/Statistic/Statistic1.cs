using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreCampProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = blogManager.GetList().Count();
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();

            string api = "a1d8b090fe6c3cd605903a62c9c864ab";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=kocaeli&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
