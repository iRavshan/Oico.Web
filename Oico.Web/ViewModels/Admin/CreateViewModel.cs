using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oico.Web.ViewModels.Admin
{
    public class CreateViewModel
    {
        [Display(Name = "Muzqaymoqning nomi")]
        public string Name { get; set; }

        [Display(Name = "Sotuvdagi narxi")]
        public int Price { get; set; }

        [Display(Name = "Kelish tannarxi")]
        public int WholesalePrice { get; set; }

        [Display(Name = "Donasi")]
        public int NumberOfBox { get; set; }

        [Display(Name = "Qutilar soni")]
        public int NumberOfBoxes { get; set; }

        [Display(Name = "Rasmi")]
        public IFormFile Image { get; set; }

        [Display(Name = "Massasi")]
        public int Massa { get; set; }
    }
}
