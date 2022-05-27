using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampProject.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
          
            var writerID = c.Writers.Where(X => X.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = writerManager.GetWriterById(writerID);
            return View(values);
        }
    }
}
