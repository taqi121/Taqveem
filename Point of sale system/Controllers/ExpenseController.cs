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
                return View();
            }
        }
        [HttpPost]
        public ActionResult NewExpense(Expens expens)
        {
            using(DbModelEntities dbModel=new DbModelEntities())
            {
                dbModel.Expenses.Add(expens);
                dbModel.SaveChanges();
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
    }
}