using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetCore.Logica.Models.BindingModel
{
    public class ProjectCreateBindingModel
    {
        [Required(ErrorMessage = "The field Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field Details is required")]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required(ErrorMessage = "The field ExpectedCompletionDate is required")]
        [Display(Name = "ExpectedCompletionDate")]
        public DateTime ExpectedCompletionDate { get; set; }
    }

    public class ProjectEditBindingModel
    {
        [Required(ErrorMessage = "The field Id is required")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field Details is required")]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required(ErrorMessage = "The field ExpectedCompletionDate is required")]
        [Display(Name = "ExpectedCompletionDate")]
        public DateTime ExpectedCompletionDate { get; set; }
    }
}
