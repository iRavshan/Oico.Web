using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oico.Domain;
using Oico.Service.Services;
using Oico.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Oico.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public HomeController(ILogger<HomeController> logger,
                              IProductService productService,
                              IOrderService orderService)
        {
            _logger = logger;
            this.productService = productService;
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new IndexViewModel
            {
                AllProducts = await productService.GetAll(),
                LastProducts = await productService.LastProducts(8)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            AllProductsViewModel model = new AllProductsViewModel
            {
                CountOfProduct = new List<int>(),
                Products = await productService.GetAll()
            };
            
            foreach(Product product in model.Products)
            {
                model.CountOfProduct.Add(0);
            }
            
            return View(model);
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            Product product = await productService.GetById(Id);

            ProductViewModel model = new ProductViewModel
            {
                Product = product
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Cart(AllProductsViewModel model)
        {
            CartViewModel newModel = new CartViewModel();

            List<Product> GetProducts = new List<Product>();

            List<Guid> Ids = new List<Guid>();

            List<int> exCountOfProducts = new List<int>();

            IEnumerable<Product> Products = await productService.GetAll();

            for (int i = 0; i < model.CountOfProduct.Count(); i++)
            {
                if(model.CountOfProduct[i] != 0)
                {
                    Product product = Products.ToList()[i];
                    GetProducts.Add(product);
                    Ids.Add(product.Id);
                    exCountOfProducts.Add(model.CountOfProduct[i]);
                }
            }

            newModel.CountOfProduct = exCountOfProducts;
            newModel.Products = GetProducts;
            newModel.GuidsOfProducts = Ids;

            return View(newModel);
        }

        [HttpPost]
        public async Task<IActionResult> Order(CartViewModel model)
        {
            Order order = new Order 
            { 
                Id = Guid.NewGuid(),
                AcceptedTime = DateTime.Now,
                Client = model.Username,
                PhoneNumber = model.Phone,
                IsComplete = false,
                Things = new List<Thing>()
            };

            List<Thing> things = new List<Thing>();

            int summa = 0;

            for (int i = 0; i < model.CountOfProduct.Count(); i++)
            {
                Product product = await productService.GetById(model.GuidsOfProducts[i]);

                summa += model.CountOfProduct[i] * product.Price;

                things.Add(new Thing { Id = Guid.NewGuid(), CountOfProduct = model.CountOfProduct[i], NameOfProduct = product.Name});
            }

            order.Sum = summa;
            order.Things = things;

            await orderService.Create(order);

            return RedirectToAction("index");
        }
    }
}
