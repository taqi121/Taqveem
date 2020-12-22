using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Point_of_sale_system.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult POS()
        {
            return View();
        }
        public ActionResult Newitem()
        {
            return View();
        }
        public ActionResult ViewItems()
        {
            return View();
        }
        public ActionResult NewCategory()
        {
            return View();
        }
        public ActionResult ViewCategories()
        {
            return View();
        }
        public ActionResult NewBrand()
        {
            return View();
        }
    }
}