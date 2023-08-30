using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace OdeToFoodMVC.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductData db;

        public ProductsController(IProductData db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index(string searchString)
        {
            List<Product> productosFiltrados = new List<Product>();

            if (!string.IsNullOrEmpty(searchString))
            {
                productosFiltrados = db.GetAll().Where(p =>
                    p.Id.ToString().Contains(searchString) ||
                    p.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();
            }
            else
            {
                var model = db.GetAll();
                return View(model);
            }

            return View(productosFiltrados);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Add(product);
                return RedirectToAction("Details", new { id = product.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Update(product);
                return RedirectToAction("Details", new { id = product.Id });
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult GetForId(int id)
        {
            var model = db.Get(id);
            return View(model);
        }
    }
}