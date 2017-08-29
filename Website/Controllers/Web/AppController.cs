using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Website.Models;
using Website.Services;
using Website.ViewModels;

namespace Website.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private IWebsiteRepository _repository;
        private ILogger<AppController> _logger;

        public AppController(IMailService mailService, IConfigurationRoot config, IWebsiteRepository repository, ILogger<AppController> logger)
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Blogs()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get blogs in Index page: {ex.Message}");
                return Redirect("/error");
            }
        }

        //public IActionResult ReaderBlogs()
        //{
        //    try
        //    {
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Failed to get blogs in Index page: {ex.Message}");
        //        return Redirect("/error");
        //    }
        //}

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com"))
            {
                ModelState.AddModelError("", "We don't support AOL Addresses");
            }
            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From Website", model.Message);
                ModelState.Clear();
                ViewBag.UserMessage = "Messege Sent";
            }
            
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }
    }
}
