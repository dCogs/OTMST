using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace OTMST.Controllers
{
    public class HomeController : Controller
    {

        [OutputCache(Duration = 0, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Sent()
        {
            ViewBag.Message = "Email sent";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(OTMST.Models.MVCEmail model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("daniel.cogswell@gmail.com"));  // replace with valid value 
                message.To.Add(new MailAddress("joybridy@yahoo.com"));
                message.From = new MailAddress("postmaster@danielcogswell.com");  // replace with valid value
                message.Subject = "OTMST inquiry from web";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient("localhost"))
                {
                    //var credential = new NetworkCredential
                    //{
                    //    UserName = "user@outlook.com",  // replace with valid value
                    //    Password = "password"  // replace with valid value
                    //};
                    //smtp.Credentials = credential;
                    //smtp.Host = "smtp-mail.outlook.com";
                    //smtp.Port = 587;
                    //smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();
                Exception ex = filterContext.Exception;
                //do something with these details here
                RedirectToAction("Error", "Home");
            }
        }

        public ActionResult Error()
        {
            return View();
            //return RedirectToAction("Error", "Home");
        }


    }
}