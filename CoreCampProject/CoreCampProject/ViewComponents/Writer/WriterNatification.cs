using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampProject.ViewComponents.Writer
{
    public class WriterNatification:ViewComponent
    {
        NotificationManager notificationManager = new NotificationManager(new EFNotificationRepository());

        public IViewComponentResult Invoke()
        {
            var values = notificationManager.GetList();
            return View(values);
        }
    }
}
