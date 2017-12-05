using eCommerce.Contracts.Repositories;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.WebUI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        IRepositoryBase<Customer> Customers;
        IRepositoryBase<Product> Products;

        public AdminController(IRepositoryBase<Customer> Customers, IRepositoryBase<Product> Products)
        {
            this.Customers = Customers;
            this.Products = Products;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductList()
        {
            var model = Products.GetAll();

            return View(model);
        }

        public ActionResult CreateProduct()
        {
            var model = new Product();

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            Products.Insert(product);
            Products.Commit();

            return RedirectToAction("ProductList");
        }

        public ActionResult EditProduct(int id)
        {
            Product product = Products.GetById(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            Products.Update(product);
            Products.Commit();

            return RedirectToAction("ProductList");
        }
    }
}