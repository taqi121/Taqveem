using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
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
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult login2(string email, string password,bool rememberMe=true,string ReturnUrl="")
        {
            try
            {
                string message = "";
                var passss = Crypto.Hash(password);
                //var login_admin = dbmodel.Admins.Where(x => x.Username == email && x.password == password).SingleOrDefault();
                var login_user = dbmodel.Admins.Where(x => x.Username == email && x.password == passss).SingleOrDefault();
                if (login_user != null)
                {
                    //int timeout = FielNameFromDatabase ? 525600 : 20; THis is to save cookie remember for one year 525600 min = 1 year
                    int timeout = rememberMe ? 525600 : 20; //THis is to save cookie remember for one year 525600 min = 1 year
                    var ticket = new FormsAuthenticationTicket(email, rememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);

                    if(Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        Session["User_Id"] = login_user.ID.ToString();
                        Session["UserName"] = login_user.Name.ToString();
                        return RedirectToAction("mainPage", "Home");
                    }

                }
                else
                {
                    message = "Invalid Credential Applied";
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
        
        //Verify Account  

        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            
                dbmodel.Configuration.ValidateOnSaveEnabled = false; // This line I have added here to avoid 
                                                                // Confirm password does not match issue on save changes
                //var v = dbmodel.Admins.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                //var v = dbmodel.Admins.Where(a => a.Username == new Guid(id)).FirstOrDefault();
                //////if (v != null)
                //////{
                //////    v.IsEmailVerified = true;
                //////    dc.SaveChanges();
                //////    Status = true;
                //////}
                //////else
                //////{
                //////    ViewBag.Message = "Invalid Request";
                //////}
            ViewBag.Status = Status;
            return View();
        }

           //Register New User
        [HttpGet]
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
        [HttpPost]
        public ActionResult Logout()
        {

            Session.Abandon();
            FormsAuthentication.SignOut();
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

            //var verifyUrl = "/User/VerifyAccount/" + activationCode;
            var verifyUrl = "/MainControl/"+emailFor+"/" + activationCode;
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
        [HttpGet]
        public ActionResult ForgetPassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string EmailID)
        {
            //Verify Email ID
            //Generate Reset Password Link
            //Send Email

            string message = "";
            bool status = false;

            var account = dbmodel.Admins.Where(x => x.Username == EmailID).FirstOrDefault();
            if(account != null)
            {
                //Send Email for Reset Password
                string resetCode = Guid.NewGuid().ToString();
                SendVerificationEmailLink(account.Username, resetCode, "ResetPassword");
                account.resetPasswordCode = resetCode;
                //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
                //in our model class
                dbmodel.Configuration.ValidateOnSaveEnabled = false;
                dbmodel.SaveChanges();
            }
            else
            {
                message = "Account not Found";
            }
            return View();
        }
        public ActionResult resetPassword(string id)
        {
            //Verify the reset password link
            //find account associated with this link
            //redirect to reset password page
            var user = dbmodel.Admins.Where(x => x.resetPasswordCode == id).FirstOrDefault();
            if(user !=null)
            {
                ResetPasswordModel resetPasswordModel=new ResetPasswordModel();
                resetPasswordModel.ResetCode = id;
                return View(resetPasswordModel);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult resetPassword(ResetPasswordModel model)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                var user = dbmodel.Admins.Where(a => a.resetPasswordCode == model.ResetCode).FirstOrDefault();
                if (user != null)
                {
                    user.password = Crypto.Hash(model.newPassword);

                    user.resetPasswordCode = "";
                    dbmodel.Configuration.ValidateOnSaveEnabled = false;
                    dbmodel.SaveChanges();
                    message = "New password Update Successfully";
                }
            }
            else
            {
                message = "Some Thing is Invalid";
            }
            ViewBag.message = message;
            return View(model);
        }
    }
    
}