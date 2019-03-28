using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCore.Logica.Models.DB
{
    public class Tenants : DAL.Models.Tenants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Plan { get; set; }
    }
}
