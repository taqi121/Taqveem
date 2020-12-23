using Point_of_sale_system.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Point_of_sale_system.Controllers
{
    public class UsersController : Controller
    {
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
        public ActionResult DeleteCustomer(int id)
        {
            Customer customer;
            using (DbModelEntities dbmodel = new DbModelEntities())
            {
                customer = dbmodel.Customers.Where(x => x.ID == id).FirstOrDefault();
                dbmodel.Customers.Remove(customer);
                dbmodel.SaveChanges();
            }
            return RedirectToAction("CustomerList");
            //bool a = DeleteCustomerData(customer);
            //if(a)
            //{
            //    ViewData["Message"] = "Delete";
            //    return RedirectToAction("CustomerList");
            //}
            //else
            //{
            //    ViewData["Message"] = "Error";
            //    return View();
            //}
        }
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
        public ActionResult NewEmployee()
        {
            return View();
        }
        public ActionResult EmployeeList()
        {
            return View();
        }
        public ActionResult NewRole()
        {
            return View();
        }
        public ActionResult RoleList()
        {
            return View();
        }
    }
}