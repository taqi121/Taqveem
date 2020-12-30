using Point_of_sale_system.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
            
            try
            {
                if (Session["UserName"] != null)
                {

                    var Item_brand_List = DbModel.Brands.ToList();
                    var Item_brands_list = new SelectList(Item_brand_List, "BrandID", "Name");
                    ViewBag.ItemBrandList = Item_brands_list;
                    var Item_category_list = DbModel.Categories.ToList();
                    var Item_categories_list = new SelectList(Item_category_list, "categoryID", "Name");
                    ViewBag.ItemCategoryList = Item_categories_list;
                    return View();
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
        public ActionResult NewItem(Item item, HttpPostedFileBase Imageee)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    var DateeTime = DateTime.Now.ToString("yyyyMMdd_hhssms");
                    var fname = Imageee.FileName;
                    var fullnamee = DateeTime + "_" + fname;
                    var ext = Path.GetExtension(fname);
                    var extension = ext.ToLower();
                    if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                    {
                        var path = Server.MapPath("~/Photo");
                        var fullpath = Path.Combine(path, fullnamee);
                        Imageee.SaveAs(fullpath);
                        item.image = fullnamee;
                        //comp.User_Add_FK = Convert.ToInt32(Session["User_Add_id"].ToString());
                        item.Barcode = Crypto.Hash(item.Barcode);
                        DbModel.Items.Add(item);
                        DbModel.SaveChanges();
                        ModelState.Clear();
                        var role_list = DbModel.User_Role.ToList();
                        var roles_list = new SelectList(role_list, "RoleId", "Name");
                        ViewBag.Role = roles_list;
                    }

                    return RedirectToAction("Newitem", "Item");
                }
                else
                {
                    return RedirectToAction("Login", "MainControl");
                }
            }
            catch (Exception)
            {
                return View();

            }
            
        }
        public ActionResult ViewItems()
        {
            try
            {
                if (Session["UserName"] != null)
                {

                    return View(DbModel.Items.ToList());
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
        public ActionResult EditItem(int id)
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
            try
            {
                if (Session["UserName"] != null)
                {

                    var Item_brand_List = DbModel.Brands.ToList();
                    var Item_brands_list = new SelectList(Item_brand_List, "BrandID", "Name");
                    ViewBag.ItemBrandList = Item_brands_list;
                    var Item_category_list = DbModel.Categories.ToList();
                    var Item_categories_list = new SelectList(Item_category_list, "categoryID", "Name");
                    ViewBag.ItemCategoryList = Item_categories_list;
                    return View(DbModel.Items.Where(x=>x.ID==id).FirstOrDefault());
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
        public ActionResult EditItem(Item item, HttpPostedFileBase Imageee)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    if (ModelState.IsValid)
                    {
                        var DateeTime = DateTime.Now.ToString("yyyyMMdd_hhssms");
                        var fname = Imageee.FileName;
                        var fullnamee = DateeTime + "_" + fname;
                        var ext = Path.GetExtension(fname);
                        var extension = ext.ToLower();
                        if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                        {
                            var path = Server.MapPath("~/Photo");
                            var fullpath = Path.Combine(path, fullnamee);
                            Imageee.SaveAs(fullpath);
                            item.image = fullnamee;
                            //comp.User_Add_FK = Convert.ToInt32(Session["User_Add_id"].ToString());
                            //item.Barcode = Crypto.Hash(item.Barcode);
                            DbModel.Entry(item).State = EntityState.Modified;
                            DbModel.SaveChanges();
                            ModelState.Clear();
                            var role_list = DbModel.User_Role.ToList();
                            var roles_list = new SelectList(role_list, "RoleId", "Name");
                            ViewBag.Role = roles_list;
                        }
                    }
                    return RedirectToAction("Newitem", "Item");
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
        public ActionResult DetailsOfItems(int id)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    if (ModelState.IsValid)
                    {
                        var Item_brand_List = DbModel.Brands.ToList();
                        var Item_brands_list = new SelectList(Item_brand_List, "BrandID", "Name");
                        ViewBag.ItemBrandList = Item_brands_list;
                        var Item_category_list = DbModel.Categories.ToList();
                        var Item_categories_list = new SelectList(Item_category_list, "categoryID", "Name");
                        ViewBag.ItemCategoryList = Item_categories_list;
                        return View(DbModel.Items.Where(x => x.ID == id).FirstOrDefault());
                    }
                    else
                    {
                        return RedirectToAction("Login", "MainControl");
                    }
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
        public ActionResult NewCategory()
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    var brand_list = DbModel.Brands.ToList();
                    var brands_list = new SelectList(brand_list, "BrandID", "Name");
                    ViewBag.BrandList = brands_list;
                    return View();
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
        public ActionResult NewCategory(Category category)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    DbModel.Categories.Add(category);
                    DbModel.SaveChanges();

                    var brand_list = DbModel.Brands.ToList();
                    var brands_list = new SelectList(brand_list, "BrandID", "Name");
                    ViewBag.BrandList = brands_list;
                    return RedirectToAction("NewCategory", "Item");
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
        public ActionResult ItemCategoryList()
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(DbModel.Categories.ToList());
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
        public ActionResult EditItemCategory(int id)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    var brand_list = DbModel.Brands.ToList();
                    var brands_list = new SelectList(brand_list, "BrandID", "Name");
                    ViewBag.BrandList = brands_list;
                    return View(DbModel.Categories.Where(x => x.categoryID == id).FirstOrDefault());
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
        public ActionResult EditItemCategory(Category category)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    DbModel.Entry(category).State = EntityState.Modified;
                    DbModel.SaveChanges();
                    return RedirectToAction("ItemCategoryList", "Item");
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
        public ActionResult NewBrand()
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View();
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
        public ActionResult NewBrand(Brand brand)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    DbModel.Brands.Add(brand);
                    DbModel.SaveChanges();
                    return RedirectToAction("NewBrand", "Item");
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
        public ActionResult BrandList()
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(DbModel.Brands.ToList());

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
        public ActionResult EditBrand(int id)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    return View(DbModel.Brands.Where(x => x.BrandID == id).FirstOrDefault());

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
        public ActionResult EditBrand(Brand brand)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    DbModel.Entry(brand).State = EntityState.Modified;
                    DbModel.SaveChanges();
                    return RedirectToAction("BrandList", "Item");
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
    }
}