using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreCampProject.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampProject.Controllers
{
    
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        
        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            Context c = new Context();
            var writerName = c.Writers.Where(X => X.WriterMail == userMail).Select(y => y.WriterFullName).FirstOrDefault();
            ViewBag.v2 = writerName;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(X => X.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var writerValues = writerManager.TGetById(writerID);
            return View(writerValues);
        }

        
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            WriterValidator writerValidations = new WriterValidator();
            ValidationResult results = writerValidations.Validate(p);
            if (results.IsValid)
            {
                writerManager.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer writer = new Writer();
            if(p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterMail = p.WriterMail;
            writer.WriterFullName = p.WriterFullName;
            writer.WriterPassword = p.WriterPassword;
            writer.WriterStatus = true;
            writer.WriterAbout = p.WriterAbout;
            writerManager.TAdd(writer);
            return View("Index","Dashboard");
        }
    }
}
