using Microsoft.AspNetCore.Mvc;
using Oico.Domain;
using Oico.Service.Services;
using Oico.Web.ViewModels.Admin;
using System;
using System.Collections.Generic;
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

        public AdminController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Price = model.Price,
                WholesalePrice = model.WholesalePrice,
                Name = model.Name,
                NumberOfBox = model.NumberOfBox,
                NumberOfBoxes = model.NumberOfBoxes,
                ImageUrl = "rasm",
                Massa = model.Massa
            };

            productService.Create(product);

            return View();
        }
    }
}
