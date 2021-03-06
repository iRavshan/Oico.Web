using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Oico.Domain;
using Oico.Service.Services;
using Oico.Web.ViewModels.Admin;
using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Oico.Web.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly IWebHostEnvironment webHost;

        public AdminController(IProductService productService,
                               IOrderService orderService,
                               IWebHostEnvironment webHost)
        {
            this.productService = productService;
            this.orderService = orderService;
            this.webHost = webHost;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var exProduct = await productService.GetByName(model.Name);

                if (exProduct is not null)
                {
                    return View();
                }

                Product product = new Product
                {
                    Id = Guid.NewGuid(),
                    Price = model.Price,
                    WholesalePrice = model.WholesalePrice,
                    Name = model.Name,
                    NumberOfBox = model.NumberOfBox,
                    CountOfProduct = model.NumberOfBox * model.NumberOfBoxes,
                    ImageUrl = UploadPhoto(model.Image),
                    Massa = model.Massa
                };

                await productService.Create(product);

                return RedirectToAction("products");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            ProductsViewModel model = new ProductsViewModel
            {
                AllProducts = await productService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Products(ProductsViewModel model)
        {
            ProductsViewModel newModel = new ProductsViewModel();

            if (model.TextOfSearch is not null)
            {
                newModel.AllProducts = await productService.GetByShortName(model.TextOfSearch);
            }

            else
                newModel.AllProducts = await productService.GetAll();

            return View(newModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            Product product = await productService.GetById(Id);

            string webRootPath = webHost.WebRootPath;
            
            var fullPath = webRootPath + "/img/product/" + product.ImageUrl;

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            await productService.Delete(Id);

            return RedirectToAction("products");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {
            Product product = await productService.GetById(Id);

            DetailsViewModel model = new DetailsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                WholesalePrice = product.WholesalePrice,
                NumberOfBox = product.NumberOfBox,
                CountOfProduct = product.CountOfProduct,
                Massa = product.Massa,
                ExistingImageUrl = product.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DetailsViewModel model)
        {
            Product product = await productService.GetById(model.Id);

            product.Name = model.Name;
            product.WholesalePrice = model.WholesalePrice;
            product.Price = model.Price;
            product.NumberOfBox = model.NumberOfBox;
            product.CountOfProduct += (model.CountOfNewBoxes * model.NumberOfBox);
            product.Massa = model.Massa;
            if(model.Image != null) 
            {
                if(model.ExistingImageUrl != null)
                {
                    string filePath = Path.Combine(webHost.WebRootPath, "img/product", model.ExistingImageUrl);
                    System.IO.File.Delete(filePath);
                }

                product.ImageUrl = UploadPhoto(model.Image);
            }
            productService.Update(product);
            return RedirectToAction("products");
        }

        public async Task<IActionResult> Orders()
        {
            OrdersViewModel model = new OrdersViewModel
            {
                NewOrders = await orderService.GetNewOrders(),
                OrdersOnYear = await orderService.OrdersOnLastYear(),
                OrdersOnMonth = await orderService.OrdersOnLastMonth(),
                OrdersOnToday = await orderService.OrdersOnToday(),
                OrdersOnWeek = await orderService.OrdersOnLastWeek()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Order(Guid Id)
        {
            OrderDetailsViewModel model = new OrderDetailsViewModel
            {
                Order = await orderService.GetById(Id)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetComplete(Guid Id)
        {
            Order order = await orderService.GetById(Id);
            order.IsComplete = true;
            order.ConfirmedTime = DateTime.Now;

            foreach (var item in order.Things)
            {
                Product product = await productService.GetByName(item.NameOfProduct);

                product.CountOfProduct -= item.CountOfProduct;

                productService.Update(product);
            }

            orderService.CompleteOrder(order);
            return RedirectToAction("orders");
        }

        public async Task<IActionResult> PrintOrder(Guid Id)
        {
            return View();
        }

        private string UploadPhoto(IFormFile file)
        {
            string uniqueFileName = string.Empty;

            if (file != null)
            {
                string uploadFolder = Path.Combine(webHost.WebRootPath, "img/product");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                file.CopyTo(new FileStream(imageFilePath, FileMode.Create));
            }

            return uniqueFileName;
        }
    }
}
