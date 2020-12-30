using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Point_of_sale_system.Models;


namespace Point_of_sale_system.Controllers
{
    public class PurchaseController : Controller
    {
        DbModelEntities dbModel = new DbModelEntities();
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
        // GET: Purchase
        public ActionResult NewPurchase()
        {
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
            return View();
        }
        [HttpPost]
        public ActionResult newPurchase(purchase purchase)
        {
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
            return View();
        }
        public ActionResult PurchaseList()
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(dbModel.purchases.ToList());
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
        public ActionResult EditPurchase(int id)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(dbModel.purchases.Where(x => x.ID == id).FirstOrDefault());
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
        public ActionResult EditPurchase(purchase purchase)
        {
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
            return View();
        }

    }
}