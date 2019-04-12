using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetCore.Logica.Models.BindingModel
{
    public class TaskCreateBindingModel
    {
      
        [Required(ErrorMessage = "The field Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field Details is required")]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required(ErrorMessage = "The field ExpirationDate is required")]
        [Display(Name = "ExpirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [Required(ErrorMessage = "The field IsCompleted is required")]
        [Display(Name = "IsCompleted")]
        public bool? IsCompleted { get; set; }

        [Required(ErrorMessage = "The field Effort is required")]
        [Display(Name = "Effort")]
        public int? Effort { get; set; }

        [Required(ErrorMessage = "The field RemainingWork is required")]
        [Display(Name = "RemainingWork")]
        public int? RemainingWork { get; set; }

        [Required(ErrorMessage = "The field StateId is required")]
        [Display(Name = "StateId")]
        public int? StateId { get; set; }

        [Required(ErrorMessage = "The field ActivityId is required")]
        [Display(Name = "ActivityId")]
        public int? ActivityId { get; set; }

        [Required(ErrorMessage = "The field PriorityId is required")]
        [Display(Name = "PriorityId")]
        public int? PriorityId { get; set; }

        [Required(ErrorMessage = "The field ProjectId is required")]
        [Display(Name = "ProjectId")]
        public int? ProjectId { get; set; }
    }
}
