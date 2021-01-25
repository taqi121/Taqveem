using Point_of_sale_system.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Point_of_sale_system.Controllers
{
    public class UsersController : Controller
    {
        DbModelEntities Dbmodel = new DbModelEntities();
        //try
        //{
        //    if (Session["UserName"] != null)
        //    {

        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "MainControl");
        //    }
        //}
        //catch
        //{
        //    return View();
        //}
        // GET: Users
        public ActionResult NewCustomer()
        {
            
            try
            {
                if (Session["UserName"] != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
            
        }
        [HttpPost]
        [ActionName("NewCustomer")]
        public ActionResult NewCustomer1(Customer customer)
        {
            try
            {
                if (Session["UserName"] != null)
                {

                    Dbmodel.Customers.Add(customer);
                    Dbmodel.SaveChanges();
                    
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
            
        }
        public ActionResult Customerlist()
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(Dbmodel.Customers.ToList());
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
            
            
        }
        public ActionResult DetailsCustomers(int id)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(Dbmodel.Customers.Where(x => x.ID == id).FirstOrDefault());
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
            
            
        }
        public ActionResult Edit(int id)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(Dbmodel.Customers.Where(x => x.ID == id).FirstOrDefault());
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
            
            
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit(int id,Customer customer)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    Dbmodel.Entry(customer).State = EntityState.Modified;
                    Dbmodel.SaveChanges();
                    return RedirectToAction("Customerlist");
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
            
            
        }
        //public ActionResult DeleteCustomer(int id)
        //{
        //    Customer customer;
        //    using (DbModelEntities dbmodel = new DbModelEntities())
        //    {
        //        customer = dbmodel.Customers.Where(x => x.ID == id).FirstOrDefault();
        //        dbmodel.Customers.Remove(customer);
        //        dbmodel.SaveChanges();
        //    }
        //    return RedirectToAction("CustomerList");
        //    //bool a = DeleteCustomerData(customer);
        //    //if(a)
        //    //{
        //    //    ViewData["Message"] = "Delete";
        //    //    return RedirectToAction("CustomerList");
        //    //}
        //    //else
        //    //{
        //    //    ViewData["Message"] = "Error";
        //    //    return View();
        //    //}
        //}
        //public bool DeleteCustomerData(Customer customer)
        //{
        //    using(DbModelEntities dbmodel=new DbModelEntities())
        //    {

        //    }
        //    return true;
        //}
        [HttpGet]
        public ActionResult NewSupplier()
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult NewSupplier(Supplier supplier)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    Dbmodel.Suppliers.Add(supplier);
                    Dbmodel.SaveChanges();

                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
          
        }
        [HttpPost]
        public ActionResult NewSupplierThroughModel(Supplier supplier)
        {
            try
            {
                if (Session["UserName"] != null)
                {

                    Dbmodel.Suppliers.Add(supplier);
                    Dbmodel.SaveChanges();

                    return RedirectToAction("NewPurchase", "Purchase");
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SupplierList()
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(Dbmodel.Suppliers.ToList());
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
            
            
        }
        public ActionResult DetailsSupplier(int id)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(Dbmodel.Suppliers.Where(x => x.ID == id).FirstOrDefault());
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
            
            
        }
        [HttpGet]
        public ActionResult EditSupplier(int id)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(Dbmodel.Suppliers.Where(x => x.ID == id).FirstOrDefault());
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
            
            
        }
        [HttpPost]
        [ActionName("EditSupplier")]
        public ActionResult EditSupplier(int id,Supplier supplier)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    
                    Dbmodel.Entry(supplier).State = EntityState.Modified;
                    Dbmodel.SaveChanges();
                    return RedirectToAction("SupplierList");
                    
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
            
        }
        public ActionResult NewEmployee()
        {
            try
            { 
                if(Session["UserName"] != null)
                { 
                    var role_list = Dbmodel.User_Role.ToList();
                    var roles_list = new SelectList(role_list, "RoleId", "Name");
                    ViewBag.Role = roles_list;
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult NewEmployee(User user, HttpPostedFileBase ImageofUser)
        {
            try
            {
                if(Session["UserName"] != null)
                { 
                var DateeTime = DateTime.Now.ToString("yyyyMMdd_hhssms");
                var fname = ImageofUser.FileName;
                var fullnamee = DateeTime + "_" + fname;
                var ext = Path.GetExtension(fname);
                var extension = ext.ToLower();
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    var path = Server.MapPath("~/Photo");
                    var fullpath = Path.Combine(path, fullnamee);
                    ImageofUser.SaveAs(fullpath);
                    user.image = fullnamee;
                    //comp.User_Add_FK = Convert.ToInt32(Session["User_Add_id"].ToString());
                    user.password = Crypto.Hash(user.password);
                    user.cpassword = Crypto.Hash(user.cpassword);
                    Dbmodel.Users.Add(user);
                    Dbmodel.SaveChanges();
                    ModelState.Clear();
                    var role_list = Dbmodel.User_Role.ToList();
                    var roles_list = new SelectList(role_list, "RoleId", "Name");
                    ViewBag.Role = roles_list;
                }
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }

            }
            catch (Exception)
            {


            }
            return RedirectToAction("NewEmployee", "Users");
        }
        public ActionResult EmployeeList()
        {
            try
            {
                if(Session["UserName"]!=null)
                {
                    return View(Dbmodel.Users.ToList());

                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
     //   [Authorize(Roles ="Admin")]
        public ActionResult EditEmployee(int id)
        {
            try
            { 
                if(Session["UserName"] != null)
                { 
                    var role_list = Dbmodel.User_Role.ToList();
                    var roles_list = new SelectList(role_list, "RoleId", "Name");
                    ViewBag.Role = roles_list;
                    return View(Dbmodel.Users.Where(x => x.ID == id).FirstOrDefault());
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch(Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ActionName("EditEmployee")]
        public ActionResult EditEmployee(User user, HttpPostedFileBase ImageofUser)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    var DateeTime = DateTime.Now.ToString("yyyyMMdd_hhssms");
                    var fname = ImageofUser.FileName;
                    var fullnamee = DateeTime + "_" + fname;
                    var ext = Path.GetExtension(fname);
                    var extension = ext.ToLower();
                    if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                    {
                        var path = Server.MapPath("~/Photo");
                        var fullpath = Path.Combine(path, fullnamee);
                        ImageofUser.SaveAs(fullpath);
                        user.image = fullnamee;
                        //comp.User_Add_FK = Convert.ToInt32(Session["User_Add_id"].ToString());
                        //    user.password = Crypto.Hash(user.password);
                        //    user.cpassword = Crypto.Hash(user.cpassword);
                        Dbmodel.Entry(user).State = EntityState.Modified;
                        Dbmodel.SaveChanges();
                        ModelState.Clear();
                        var role_list = Dbmodel.User_Role.ToList();
                        var roles_list = new SelectList(role_list, "RoleId", "Name");
                        ViewBag.Role = roles_list;
                    }
                    return RedirectToAction("EmployeeList", "Users");

                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }


            }
            catch (Exception)
            {
                return RedirectToAction("", "");

            }
            
            
        }
        public ActionResult EmployeeDetails(int id)
        {
            //List<User> EmployeeList = Db.Users.ToList();
            //EmployeeViewModel employeeVM = new EmployeeViewModel();
            //List<EmployeeViewModel> employeeVMList = EmployeeList.Select(x => new EmployeeViewModel
            //{
            //    Name = x.Name,
            //    FatherName = x.FatherName,
            //    Bio = x.Bio,
            //    Addres = x.Addres,
            //    stateOfCountry = x.stateOfCountry,
            //    city = x.city,
            //    Mobile = x.Mobile,
            //    email = x.email,
            //    country = x.country,
            //    CollegeName = x.CollegeName,
            //    cpassword = x.cpassword,
            //    password = x.password,
            //    image = x.image,
            //    DegreeName = x.DegreeName,
            //    startDate = x.startDate,
            //    EndDate = x.EndDate,
            //    RoleID = x.RoleID,
            //    RoleName = x.User_Role.Name

            //}).ToList();
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(Dbmodel.Users.Where(x => x.ID == id).FirstOrDefault());
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch (Exception)
            {
                return View();
            }
        }
        public ActionResult NewRole()
        {
            try
            {
                if(Session["UserName"]!=null)
                {

                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult NewRole(User_Role user_Role)
        {
            try
            {
                if (Session["UserName"] != null)
                {

                    Dbmodel.User_Role.Add(user_Role);
                    Dbmodel.SaveChanges();
                    return RedirectToAction("NewRole", "Users");
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }catch
            {
                return View();
            }
        }
        public ActionResult EditRole(int? id)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    User_Role user_Role = Dbmodel.User_Role.Find(id);
                    return View(user_Role);
                }else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult EditRole( User_Role user_Role)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    Dbmodel.Entry(user_Role).State = EntityState.Modified;
                    Dbmodel.SaveChanges();
                    return RedirectToAction("RoleList", "Users");
                }else
                {
                    return RedirectToAction("Login", "MainCOntrol");
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult RoleList()
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(Dbmodel.User_Role.ToList());
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}