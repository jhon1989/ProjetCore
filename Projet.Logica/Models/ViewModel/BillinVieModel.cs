using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCore.Logica.Models.ViewModel
{
    public class BillinVieModel
    {
        public double subtotal { get; set; }
        public double total { get; set; }
        public string description { get; set; }
        public double iva { get; set; }
        public double discount { get; set; }
    }
}
