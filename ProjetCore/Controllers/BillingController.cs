using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjetCore.Controllers
{
    public class BillingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Billing(Logica.Models.BindingModel.BillingBindingModel model)
        {
            Logica.BL.Billin billin = new Logica.BL.Billin();
            return View(billin.getBilling(model.Reference, model.Quantity));
        }
    }
    
}