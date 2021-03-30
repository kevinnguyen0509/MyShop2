using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI2.Controllers
{
    public class ProductCategoryController : Controller
    {
        ProductCategoryRepository context;

        public ProductCategoryController()
        {
            context = new ProductCategoryRepository();
        }
        // GET: ProductManagement
        public ActionResult Index()
        {
            List<ProductCategory> productsCategories = context.Collection().ToList();
            return View(productsCategories);
        }

        public ActionResult Create()
        {
            ProductCategory productsCategory = new ProductCategory();
            return View(productsCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productsCategory)
        {


            context.Insert(productsCategory);
            context.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(string Id)
        {
            ProductCategory productsCategory = context.Find(Id);
            if (productsCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productsCategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory product, string Id)
        {
            ProductCategory productCategoryToEdit = context.Find(Id);
            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {


                productCategoryToEdit.Category = product.Category;


                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}