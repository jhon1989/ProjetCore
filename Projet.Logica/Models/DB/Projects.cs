using System;

namespace ProjetCore.Logica.Models.DB
{
    public class Projects : DAL.Models.Projects
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public int? TenantId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Tenants Tenant { get; set; }
    }
}
