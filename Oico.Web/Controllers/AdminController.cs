using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Oico.Domain;
using Oico.Service.Services;
using Oico.Web.ViewModels.Admin;
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
        private readonly IWebHostEnvironment webHost;

        public AdminController(IProductService productService,
                               IWebHostEnvironment webHost)
        {
            this.productService = productService;
            this.webHost = webHost;
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = string.Empty;

                if(model.Image != null)
                {
                    string uploadFolder = Path.Combine(webHost.WebRootPath, "img/product");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                    model.Image.CopyTo(new FileStream(imageFilePath, FileMode.Create));
                }

                Product product = new Product
                {
                    Id = Guid.NewGuid(),
                    Price = model.Price,
                    WholesalePrice = model.WholesalePrice,
                    Name = model.Name,
                    NumberOfBox = model.NumberOfBox,
                    NumberOfBoxes = model.NumberOfBoxes,
                    ImageUrl = uniqueFileName,
                    Massa = model.Massa
                };

                productService.Create(product);

                return RedirectToAction("products");
            }

            return View();
        }

        public async Task<IActionResult> Products()
        {
            ProductsViewModel model = new ProductsViewModel
            {
                AllProducts = await productService.GetAll()
            };

            return View(model);
        }
    }
}
