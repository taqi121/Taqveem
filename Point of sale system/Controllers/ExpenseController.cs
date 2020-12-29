using Point_of_sale_system.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Point_of_sale_system.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult NewExpense()
        { 
            using(DbModelEntities dbmodel =new DbModelEntities())
            {
                var Exp_list = dbmodel.ExpenseCategories.ToList();
                var Ex_list = new SelectList(Exp_list, "ID", "Name");
                ViewBag.ExpenseCategory = Ex_list;
                
            }
            return View();
        }
        [HttpPost]
        public ActionResult NewExpense(Expens expens)
        {
            using(DbModelEntities dbModel=new DbModelEntities())
            {
                dbModel.Expenses.Add(expens);
                dbModel.SaveChanges();
            }
            using (DbModelEntities dbmodel = new DbModelEntities())
            {
                var Exp_list = dbmodel.ExpenseCategories.ToList();
                var Ex_list = new SelectList(Exp_list, "ID", "Name");
                ViewBag.ExpenseCategory = Ex_list;

            }
            return View();
        }
        public ActionResult ViewExpenses()
        {
            using(DbModelEntities dbmodel=new DbModelEntities())
            {
                return View(dbmodel.Expenses.ToList());
            }
        }
        public ActionResult DetailsOfExpense(int id)
        {
            using(DbModelEntities dbmodel=new DbModelEntities())
            {
                return View(dbmodel.Suppliers.Where(x => x.ID == id).FirstOrDefault());
            }
        }
        //Get Method for edit the Expenses List
        public ActionResult EditExpenses(int id)
        {
            using(DbModelEntities dbmodel=new DbModelEntities())
            {
                var Exp_list = dbmodel.ExpenseCategories.ToList();
                var Ex_list = new SelectList(Exp_list, "ID", "Name");
                ViewBag.ExpenseCategory = Ex_list;
                return View(dbmodel.Expenses.Where(x => x.ID == id).FirstOrDefault());
            }
        }
        //Post Method for edit Expenses
        [HttpPost]
        public ActionResult EditExpenses(int id,Expens expense)

        {
            try
            {
                using (DbModelEntities dbModel = new DbModelEntities())
                {

                    dbModel.Entry(expense).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                using (DbModelEntities dbmodel = new DbModelEntities())
                {
                    var Exp_list = dbmodel.ExpenseCategories.ToList();
                    var Ex_list = new SelectList(Exp_list, "ID", "Name");
                    ViewBag.ExpenseCategory = Ex_list;

                }
                return View();
            }
            catch
            {
                ViewBag.Error = "Invaliid";
            }
            return View();
        }
        [HttpPost]
        //public JsonResult deleteExpense(int Desi_id)
        //{
        //    bool result = false;
        //    try
        //    {
        //        using (DbModelEntities dbmodel = new DbModelEntities())
        //        {
        //            var del_id = dbmodel.Expenses.Where(x => x.ID == Desi_id).FirstOrDefault();
        //            dbmodel.Expenses.Remove(del_id);
        //            dbmodel.SaveChanges();
        //            result = true;
        //        }
        //    }
        //    catch
        //    {
        //        ViewBag.Msg = "Error";
        //    }
        //    return Json(result, JsonRequestBehavior.AllowGet);

        //}
        public ActionResult NewExpenseCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewExpenseCategory(ExpenseCategory expenseCategory)
        {
            using (DbModelEntities dbModel = new DbModelEntities())
            {
                dbModel.ExpenseCategories.Add(expenseCategory);
                dbModel.SaveChanges();
            }
            return View();
        }
        public ActionResult ExpenseCategoryList()
        {
            using(DbModelEntities dbModel=new DbModelEntities())
            {
                return View(dbModel.ExpenseCategories.ToList());
            }
        }
        public ActionResult EditCategory(int id)
        {
            using(DbModelEntities dbModel=new DbModelEntities())
            {
                return View(dbModel.ExpenseCategories.Where(x => x.ID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult EditCategory(int id,ExpenseCategory expenseCategory)
        {
            try
            { 
            using(DbModelEntities dbmodel=new DbModelEntities())
            {
                dbmodel.Entry(expenseCategory).State = EntityState.Modified;
                dbmodel.SaveChanges();
                return View();
            }
            }catch
            {
                return View();
            }
        }
        //public JsonResult DeeteCategory(int id)
        //{
        //    bool result = false;
        //    try
        //    {
        //        using (DbModelEntities dbmodel = new DbModelEntities())
        //        {
        //            var del_id = dbmodel.ExpenseCategories.Where(x => x.ID == id).FirstOrDefault();
        //            dbmodel.ExpenseCategories.Remove(del_id);
        //            dbmodel.SaveChanges();
        //            result = true;
        //        }
        //    }
        //    catch
        //    {
        //        ViewBag.Msg = "Error";
        //    }
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}