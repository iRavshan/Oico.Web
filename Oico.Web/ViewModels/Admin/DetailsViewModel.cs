using Microsoft.AspNetCore.Http;
using Oico.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oico.Web.ViewModels.Admin
{
    public class DetailsViewModel : CreateViewModel
    {
        public string ExistingImageUrl { get; set; }

        [Display(Name = "Yangi qutilar soni")]
        public int CountOfNewBoxes { get; set; }

        [Display(Name = "Mahsulot soni")]
        public int CountOfProduct { get; set; }
    }
}
