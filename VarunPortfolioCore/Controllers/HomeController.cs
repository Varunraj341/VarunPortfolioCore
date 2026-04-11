using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using VarunPortfolioCore.Models;

namespace VarunPortfolioCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult PhotoStudio()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult DressShop()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Gym()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult SendMail([FromBody] FormData model)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("varunraj.techdev@gmail.com");
                mail.To.Add("varunraj.techdev@gmail.com");

                mail.Subject = "New Project Request";

                mail.Body = $"Name: {model.Name}\n" +
                            $"Phone: {model.Phone}\n" +
                            $"Email: {model.Email}\n" +
                            $"Type: {model.Type}\n" +
                            $"Message: {model.Message}";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("varunraj.techdev@gmail.com", "advx ksvw btum xzeo");
                smtp.EnableSsl = true;

                smtp.Send(mail);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
    public class FormData
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
