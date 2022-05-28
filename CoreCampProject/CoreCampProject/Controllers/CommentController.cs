﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EFCommentRepository());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialViewComment()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialViewComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            p.CommentStatus = true;
            p.BlogID = 1004;
            commentManager.CommentyAdd(p);
            return PartialView();
        }

        public PartialViewResult CommentListByBlog(int id)
        {
           var values= commentManager.GetList(id);
            return PartialView(values);
        }
    }
}
