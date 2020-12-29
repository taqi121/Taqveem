using Point_of_sale_system.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Point_of_sale_system.Controllers
{
    public class ItemController : Controller
    {
        DbModelEntities DbModel = new DbModelEntities();
        // GET: Item
        public ActionResult POS()
        {
            return View();
        }
        public ActionResult Newitem()
        {
            var Item_brand_List = DbModel.Brands.ToList();
            var Item_brands_list =new SelectList(Item_brand_List, "BrandID", "Name");
            ViewBag.ItemBrandList = Item_brands_list;
            var Item_category_list = DbModel.Categories.ToList();
            var Item_categories_list = new SelectList(Item_category_list, "categoryID", "Name");
            ViewBag.ItemCategoryList = Item_categories_list;
            return View();
        }
        [HttpPost]
        public ActionResult NewItem(Item item)
        {
            DbModel.Items.Add(item);
            DbModel.SaveChanges();
            return RedirectToAction("Newitem","Item");
        }
        public ActionResult ViewItems()
        {
            return View();
        }
        public ActionResult NewCategory()
        {
            var brand_list = DbModel.Brands.ToList();
            var brands_list = new SelectList(brand_list, "BrandID", "Name");
            ViewBag.BrandList = brands_list;
            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(Category category)
        {
            DbModel.Categories.Add(category);
            DbModel.SaveChanges();

            var brand_list = DbModel.Brands.ToList();
            var brands_list = new SelectList(brand_list, "BrandID", "Name");
            ViewBag.BrandList = brands_list;
            return RedirectToAction("NewCategory", "Item");
        }
        public ActionResult ItemCategoryList()
        {
            return View(DbModel.Categories.ToList());
        }
        public ActionResult EditItemCategory(int id)
        {
            var brand_list = DbModel.Brands.ToList();
            var brands_list = new SelectList(brand_list, "BrandID", "Name");
            ViewBag.BrandList = brands_list;
            return View(DbModel.Categories.Where(x => x.categoryID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditItemCategory(Category category)
        {
            DbModel.Entry(category).State = EntityState.Modified;
            DbModel.SaveChanges();
            return RedirectToAction("ItemCategoryList", "Item");
        }
        public ActionResult NewBrand()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewBrand(Brand brand)
        {
            DbModel.Brands.Add(brand);
            DbModel.SaveChanges();
            return RedirectToAction("NewBrand","Item");
        }
        public ActionResult BrandList()
        {
            return View(DbModel.Brands.ToList());
        }
        public ActionResult EditBrand(int id)
        {
            return View(DbModel.Brands.Where(x => x.BrandID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditBrand(Brand brand)
        {
            DbModel.Entry(brand).State = EntityState.Modified;
            DbModel.SaveChanges();
            return RedirectToAction("BrandList", "Item");
        }
    }
}