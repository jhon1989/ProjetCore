using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetCore.Logica.Models.BindingModel
{
    public class BillingBindingModel
    {
        [Required(ErrorMessage = "The field Reference is required")]
        [Display(Name = "Reference")]
        public int Reference { get; set; }

        [Required(ErrorMessage = "The field Quantity is required")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
