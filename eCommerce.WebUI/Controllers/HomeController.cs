using System;
using eCommerce.DAL.Repositories;
using eCommerce.DAL.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Contracts.Repositories;
using eCommerce.Models;

namespace eCommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;

        public HomeController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products)
        {
            this.customers = customers;
            this.products = products;
        }
        public ActionResult Index()
        {
            //CustomerRepository customers = new CustomerRepository(new DataContext());
            //ProductRepository products = new ProductRepository(new DataContext());

            var productList = products.GetAll();
            
            return View(productList );
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}