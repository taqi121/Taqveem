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
        [HttpGet]
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

            purchase p = new purchase();
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
        public ActionResult NewPurchase(List<PurchaseItem> itemss )
        {
            foreach(var file in itemss)
            {
                dbModel.PurchaseItems.Add(file);
                dbModel.SaveChanges();
            }
            return Json("output", JsonRequestBehavior.AllowGet);
        } 
        //public ActionResult saveAllPurchaseItems(PurchaseItem purchaseItem)
        //{

        //}
        [HttpGet]
        public ActionResult PurchaseData(int id)
        {
            try
            {
                Item items = dbModel.Items.Where(x => x.ID == id).FirstOrDefault();
                Item item_list = new Item
                {
                    ID = items.ID,
                    Name = items.Name,
                    Quantity = items.Quantity,
                    Barcode = items.Barcode,
                    ExpiryDate = items.ExpiryDate,
                    salesPrice = items.salesPrice,
                    price = items.price,
                    tax = items.tax,
                    Stock = items.Stock,
                    image = items.image,
                    Description = items.Description,
                    BrandID = items.BrandID,
                    categoryID = items.categoryID
                };
                //Table_Company Company_list = new Table_Company
                //{
                //    comp_id = list.comp_id,
                //    comp_name = list.comp_name,
                //    comp_Email = list.comp_Email,
                //    comp_pass = list.comp_pass,
                //    comp_phone = list.comp_phone,
                //    comp_address = list.comp_address,
                //    comp_ceo = list.comp_ceo,
                //    comp_img = list.comp_img,
                //    User_Add_FK = list.User_Add_FK



                //};
                //return new Json { Data = purchase.Name,JsonRequestBehavior.AllowGet };
                return Json(item_list, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return new JsonResult();
            }
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