using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetCore.Logica.Models.ViewModel
{
    public class TasksViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Details")]
        public string Details { get; set; }

        [Display(Name = "ExpirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "IsCompleted")]
        public bool? IsCompleted { get; set; }

        [Display(Name = "Effort")]
        public int? Effort { get; set; }

        [Display(Name = "RemainingWork")]
        public int? RemainingWork { get; set; }

        [Display(Name = "Id")]
        public string State { get; set; }

        [Display(Name = "Activity")]
        public string Activity { get; set; }

        [Display(Name = "PriorityI")]
        public string Priority { get; set; }

        [Display(Name = "Project")]
        public string Project { get; set; }
    }
}
