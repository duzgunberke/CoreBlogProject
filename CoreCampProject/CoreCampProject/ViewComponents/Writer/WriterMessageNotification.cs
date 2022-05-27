using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampProject.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager messageManager = new Message2Manager(new EFMessage2Repository());

        public IViewComponentResult Invoke()
        {
            int id = 1;
            var values = messageManager.GetInboxListByWriter(id);
            return View(values);
        }
    }
}
