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
        DbModelEntities Db = new DbModelEntities();
        // GET: Users
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        [ActionName("NewCustomer")]
        public ActionResult NewCustomer1(Customer customer)
        {
            using(DbModelEntities dbModel=new DbModelEntities())
            {
                dbModel.Customers.Add(customer);
                dbModel.SaveChanges();
            }
            return View();
        }
        public ActionResult Customerlist()
        {
            using(DbModelEntities dbModel=new DbModelEntities())
            {
                return View(dbModel.Customers.ToList());
            }
        }
        public ActionResult DetailsCustomers(int id)
        {
            using (DbModelEntities dbmodel=new DbModelEntities())
            {
                return View(dbmodel.Customers.Where(x=>x.ID==id).FirstOrDefault());
            }
        }
        public ActionResult Edit(int id)
        {
            using(DbModelEntities dbmodel=new DbModelEntities())
            {
                return View(dbmodel.Customers.Where(x => x.ID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit(int id,Customer customer)
        {
            using(DbModelEntities dbModel=new DbModelEntities())
            {
                dbModel.Entry(customer).State = EntityState.Modified;
                dbModel.SaveChanges();
                return RedirectToAction("Customerlist");
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
            return View();
        }
        [HttpPost]
        public ActionResult NewSupplier(Supplier supplier)
        {
            using(DbModelEntities dbmodel=new DbModelEntities())
            {
                dbmodel.Suppliers.Add(supplier);
                dbmodel.SaveChanges();
            }
            return View();
        }
        public ActionResult SupplierList()
        {
            using(DbModelEntities dbmodel =new DbModelEntities())
            {
                return View(dbmodel.Suppliers.ToList());
            }
        }
        public ActionResult DetailsSupplier(int id)
        {
            using(DbModelEntities dbmodel=new DbModelEntities())
            {
                return View(dbmodel.Suppliers.Where(x => x.ID == id).FirstOrDefault());
            }
        }
        [HttpGet]
        public ActionResult EditSupplier(int id)
        {
            using(DbModelEntities dbModel=new DbModelEntities())
            {
                return View(dbModel.Suppliers.Where(x=>x.ID==id).FirstOrDefault());
            }
        }
        [HttpPost]
        [ActionName("EditSupplier")]
        public ActionResult EditSupplier(int id,Supplier supplier)
        {
            using(DbModelEntities dbmodel=new DbModelEntities())
            {
                dbmodel.Entry(supplier).State = EntityState.Modified;
                dbmodel.SaveChanges();
                return RedirectToAction("SupplierList");
            }
        }
        public ActionResult NewEmployee()
        {
            var role_list = Db.User_Role.ToList();
            var roles_list = new SelectList(role_list, "RoleId", "Name");
            ViewBag.Role = roles_list;
            return View();
        }
        [HttpPost]
        public ActionResult NewEmployee(User user, HttpPostedFileBase ImageofUser)
        {
            try
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
                    Db.Users.Add(user);
                    Db.SaveChanges();
                    ModelState.Clear();
                    var role_list = Db.User_Role.ToList();
                    var roles_list = new SelectList(role_list, "RoleId", "Name");
                    ViewBag.Role = roles_list;
                }

            }
            catch (Exception)
            {


            }
            return RedirectToAction("NewEmployee", "Users");
        }
        public ActionResult EmployeeList()
        {
            return View(Db.Users.ToList());
        }
        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            var role_list = Db.User_Role.ToList();
            var roles_list = new SelectList(role_list, "RoleId", "Name");
            ViewBag.Role = roles_list;
            return View(Db.Users.Where(x => x.ID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditEmployee(User user, HttpPostedFileBase ImageofUser)
        {
            try
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
                    Db.Users.Add(user);
                    Db.SaveChanges();
                    ModelState.Clear();
                    var role_list = Db.User_Role.ToList();
                    var roles_list = new SelectList(role_list, "RoleId", "Name");
                    ViewBag.Role = roles_list;
                }

            }
            catch (Exception)
            {


            }
            return RedirectToAction("NewEmployee", "Users");
            
        }
        public ActionResult NewRole()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewRole(User_Role user_Role)
        {
            using(DbModelEntities dbmodel=new DbModelEntities())
            {
                dbmodel.User_Role.Add(user_Role);
                dbmodel.SaveChanges();
                return RedirectToAction("NewRole", "Users");
            }
        }
        public ActionResult EditRole(int? id)
        {
            using (DbModelEntities dbmodel = new DbModelEntities())
            {
                User_Role user_Role = dbmodel.User_Role.Find(id);
                return View(user_Role);

            }
        }
        [HttpPost]
        public ActionResult EditRole( User_Role user_Role)
        {
            using(DbModelEntities dbmodel=new DbModelEntities())
            {
                dbmodel.Entry(user_Role).State = EntityState.Modified;
                dbmodel.SaveChanges();
                return RedirectToAction("RoleList", "Users");
            }
        }
        public ActionResult RoleList()
        {
            using(DbModelEntities dbmodel=new DbModelEntities())
            {
                return View(dbmodel.User_Role.ToList());
            }
        }
    }
}