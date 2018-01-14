namespace FunScience.Web.Controllers
{
    using FunScience.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net.Mail;
    using System.Text;

    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacts(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage
                    {
                        From = new MailAddress(model.Email)
                    };

                    StringBuilder SbBody = new StringBuilder();

                    SbBody.Append("Детайли" + Environment.NewLine);
                    SbBody.Append(Environment.NewLine);
                    SbBody.Append("Име - " + model.Name + Environment.NewLine);
                    SbBody.Append(Environment.NewLine);
                    SbBody.Append("Имейл - " + model.Email + Environment.NewLine);
                    SbBody.Append(Environment.NewLine);
                    SbBody.Append("Съдържание - " + model.Message + Environment.NewLine);

                    msz.To.Add("funsciencetheater@gmail.com"); 
                    msz.Subject = model.Subject;
                    msz.Body = SbBody.ToString();

                    SmtpClient smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",

                        Port = 587,

                        Credentials = new System.Net.NetworkCredential("funsciencetheater@gmail.com", "****************"),

                        EnableSsl = true
                    };

                    smtp.Send(msz);

                    ModelState.Clear();

                    ViewBag.Message = "Благодаря, че се свързахте с нас.";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $"Съжаляваме възникна грешка.";
                }
            }

            return View(nameof(Index));
        }
    }
}
