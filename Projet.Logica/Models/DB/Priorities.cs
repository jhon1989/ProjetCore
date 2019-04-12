using System;
using System.Collections.Generic;

namespace ProjetCore.Logica.Models.DB
{
    public partial class Priorities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
    }
}
