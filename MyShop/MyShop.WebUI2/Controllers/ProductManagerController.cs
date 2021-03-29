﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI2.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository context;
        // GET: ProductManager

        public ProductManagerController() {
            context = new ProductRepository();
        }
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create() {
            Product product = new Product();
            return View(product);
        }

        public ActionResult Create(Product product) {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else {
                context.Insert(product);
                context.Commit();

                return RedirectToAction("Index");
            }

        }
    }
}