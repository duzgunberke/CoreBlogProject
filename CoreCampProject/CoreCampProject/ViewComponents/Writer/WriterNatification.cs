﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampProject.ViewComponents.Writer
{
    public class WriterNatification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}