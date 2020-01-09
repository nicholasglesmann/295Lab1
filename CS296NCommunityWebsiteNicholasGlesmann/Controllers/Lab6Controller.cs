using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace CS295NCommunityWebsiteNicholasGlesmann.Controllers
{
    public class Lab6Controller : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;

        public Lab6Controller(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        // New return type #1 "ViewResult"
        public ViewResult Index()
        {
            return View();
        }

        public string About()
        {
            return "Here's an about page using a string as the return type.";
        }

        [HttpPost]
        public PhysicalFileResult Download(string fileName)
        {
            return GetFile(fileName);
        }

        [HttpPost]
        public FileResult Download2(string fileName)
        {
            return GetFile(fileName);
        }

        public PhysicalFileResult GetFile(string fileName)
        {

            string filePath = _hostingEnvironment.WebRootPath + "\\files\\" + fileName;


            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), Path.GetFileName(filePath));
        }
    }
}