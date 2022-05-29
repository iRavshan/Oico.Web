using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public HomeController(ILogger<HomeController> logger,
                              IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
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

        public IActionResult Products()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cart()
        {
            return View();
        }
    }
}
