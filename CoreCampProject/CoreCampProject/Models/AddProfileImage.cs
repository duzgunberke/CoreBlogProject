using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampProject.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }

        public string WriterFullName { get; set; }

        public string WriterAbout { get; set; }

        public IFormFile WriterImage { get; set; }

        public string WriterMail { get; set; }

        public string WriterPassword { get; set; }

        public bool WriterStatus { get; set; }
    }
}
