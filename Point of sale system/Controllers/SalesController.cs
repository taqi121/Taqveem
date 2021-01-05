using Newtonsoft.Json;
using Point_of_sale_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Point_of_sale_system.Controllers
{
    public class SalesController : Controller
    {
        DbModelEntities dbModel = new DbModelEntities();
        // GET: Sales
        public ActionResult POS()
        {
            return View();
        }
        public ActionResult NewSale()
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

            return View();
        }
    }
}