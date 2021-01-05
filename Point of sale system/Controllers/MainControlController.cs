using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Point_of_sale_system.Models;

namespace Point_of_sale_system.Controllers
{
    public class MainControlController : Controller
    {
        DbModelEntities dbmodel = new DbModelEntities();
        // GET: MainControl
        [Authorize(Roles = "Admin,Customer")]
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
        public ActionResult login2(string email, string password)
        {
            try
            {

                var passss = Crypto.Hash(password);
                //var login_admin = dbmodel.Admins.Where(x => x.Username == email && x.password == password).SingleOrDefault();
                var login_user = dbmodel.Users.Where(x => x.email == email && x.password == passss).SingleOrDefault();
                if (login_user != null)
                {
                    Session["User_Id"] = login_user.ID.ToString();
                    Session["UserName"] = login_user.Name.ToString();
                    return RedirectToAction("mainPage", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch (Exception)
            {
                ViewBag.inco = "Something Invalid";
                return View();
            }
            //List<Admin> admins = new List<Admin>();
            //string username = Request["username"];
            //string password = Request["pwd"];
            //bool a =DAL.DAL.loginUser(username, password);
            //admins = DAL.DAL.GetAdmin();
            //if(a)
            //{
            //    Session["username"] = username;
            //    return RedirectToAction("mainPage", "Home");
            //}
            //else
            //{
            //    ViewData["PromptMessage"] = "Invalid";
            //    return RedirectToAction("Login", "MainControl");
            //}
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        [ActionName("ForgetPassword")]
        public ActionResult ForgetPassword2()
        {
            //string email = Request["email"];
            //bool a = SendEmail(email);
            //if (a)
            //{
            //    ViewData["Message"] = "SendEmail";
            //    return View();
            //}
            //else
            //{
            //    ViewData["Message"] = "Invalid";
            //    return View();
            //}
            return View();
        }
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser([Bind(Exclude = "IsEmailVerified")] Admin admin)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if(ModelState.IsValid)
            {
                #region //Email is already Exist 
                var isExist = IsEmailExist(admin.Username);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(admin);
                }
                #endregion

                #region Generate Activation Code 
                //admin.ActivationCode = Guid.NewGuid();
                #endregion

                #region  Password Hashing 
                admin.password = Crypto.Hash(admin.password);
                //user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword); //
                #endregion
                var IsEmailVerified = false;
                //admin.ID = 5;
                #region Save to Database
                
                    dbmodel.Admins.Add(admin);
                    dbmodel.SaveChanges();

                //Send Email to User
                SendVerificationEmailLink(admin.Username, "ABC123");
                    message = "Registration successfully done. Account activation link " +
                        " has been sent to your email id:" + admin.Username;
                    Status = true;
                
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(admin);
        }

        //public bool SenEmail(string email)
        //{
        //    try
        //    { 
        //    using(MailMessage mm=new MailMessage("restock06@gmail.com", email))
        //    {
        //        string link = Request.Url.ToString();
        //        link = link.Replace("ForgetPassword", "ChangePassword");
        //        mm.Subject = "Reset Password";
        //        string body = "Hello ";
        //        body += "<br/><br/><br/>Please Click the Following link to Reset yOUR Password.....";
        //        body += "<br/><br/><a href ='" + link + "?'> <br/> Click here to activate your account.</a>";
        //        body += "<br/><br/> Thanks.";
        //        mm.Body = body;
        //        mm.IsBodyHtml = true;
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smpt.gmail.com";
        //        smtp.EnableSsl = true;
        //        NetworkCredential networkCred = new NetworkCredential("restock06@gmail.com", "Developer@123");
        //        smtp.UseDefaultCredentials = true;
        //        smtp.Credentials = networkCred;
        //        smtp.Port = 587;
        //        smtp.Send(mm);
        //    }
        //    return true;
        //    }catch(Exception)
        //    {
        //        ViewBag.Error = "There are Some Issue kindly resolve it First";
        //    }
        //    return false;
        //}
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "MainControl");
        }
        [NonAction]
        public bool IsEmailExist(string emailID)
        {
                var v = dbmodel.Admins.Where(a => a.Username == emailID).FirstOrDefault();
                return v != null;   
        }
        [NonAction]
        public void SendVerificationEmailLink(string emailid,string activationCode, string emailFor = "VerifyAccount")
        {
            //var scheme = Request.Url.Scheme;
            //var host = Request.Url.Host;
            //var port = Request.Url.Port;

            var verifyUrl = "/User/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("gareenhacker21@gmail.com", "malik taqi");
            var toEmail = new MailAddress(emailid);
            var fromEmailPassword = "taqveem123";
            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";
                body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
                    " successfully created. Please click on the below link to verify your account" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/>br/>We got request for reset your account password. Please click on the below link to reset your password" +
                    "<br/><br/><a href=" + link + ">Reset Password link</a>";
            }
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
    }
}