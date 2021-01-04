using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Point_of_sale_system.Models;


namespace Point_of_sale_system.Controllers
{
    public class PurchaseController : Controller
    {
        DbModelEntities dbModel = new DbModelEntities();
        
        // GET: Purchase
        public ActionResult NewPurchase()
        {
            var supplier_list = dbModel.Suppliers.ToList();
            var suppliers_list = new SelectList(supplier_list, "ID", "Name");
            ViewBag.SupplierList = suppliers_list;
            var item_list = dbModel.Items.ToList();
            var items_list = new SelectList(item_list, "ID", "Name");
            ViewBag.ItemList = items_list;
            var Item_ki_list = dbModel.Items.ToList();
            var Items_ki_list = new SelectList(Item_ki_list, "ID", "Name", "Quantity", "ExpiryDate", "Barcode", "price");
            ViewBag.MyStates = JsonConvert.SerializeObject(Items_ki_list);

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