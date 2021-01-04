using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Point_of_sale_system.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult POS()
        {
            return View();
        }

    }
}