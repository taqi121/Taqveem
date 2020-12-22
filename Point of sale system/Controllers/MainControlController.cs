using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace Point_of_sale_system.Controllers
{
    public class MainControlController : Controller
    {
        // GET: MainControl
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult login2()
        {
            
            List<Admin> admins = new List<Admin>();
            string username = Request["username"];
            string password = Request["pwd"];
            bool a =DAL.DAL.loginUser(username, password);
            admins = DAL.DAL.GetAdmin();
            if(a)
            {
                Session["username"] = username;
                return RedirectToAction("mainPage", "Home");
            }
            else
            {
                ViewData["PromptMessage"] = "Invalid";
                return RedirectToAction("Login", "MainControl");
            }
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        [ActionName("ForgetPassword")]
        public ActionResult ForgetPassword2()
        {
            string email = Request["email"];
            bool a = SenEmail(email);
            if(a)
            {
                ViewData["Message"] = "SendEmail";
                return View();
            }
            else
            {
                ViewData["Message"] = "Invalid";
                return View();
            }
        }
        public ActionResult RegisterUser()
        {
            return View();
        }
        public bool SenEmail(string email)
        {
            try
            { 
            using(MailMessage mm=new MailMessage("restock06@gmail.com", email))
            {
                string link = Request.Url.ToString();
                link = link.Replace("ForgetPassword", "ChangePassword");
                mm.Subject = "Reset Password";
                string body = "Hello ";
                body += "<br/><br/><br/>Please Click the Following link to Reset yOUR Password.....";
                body += "<br/><br/><a href ='" + link + "?'> <br/> Click here to activate your account.</a>";
                body += "<br/><br/> Thanks.";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smpt.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCred = new NetworkCredential("restock06@gmail.com", "Developer@123");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
            return true;
            }catch(Exception)
            {
                ViewBag.Error = "There are Some Issue kindly resolve it First";
            }
            return false;
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "MainControl");
        }
    }
}