﻿using CreativeIndustries.API.DXS;
using CreativeIndustries.DS.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreativeIndustries.API.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class EmailController : Controller
    {
        private readonly IMailService _mail;

        public EmailController(IMailService mail)
        {
            _mail = mail;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailDataViewModel emailData)
        {
            bool result = _mail.Send(emailData);
            if (result)
            {
                return RedirectToAction("SentEmail");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. The Mail could not be sent.");
            }
        }

        public IActionResult SentEmail()
        {
            ViewData["Success"] = "Email has been sent successfully!";
            return View();
        }
    }
}
