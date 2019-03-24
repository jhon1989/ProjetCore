﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetCore.Logica.Models.ViewModel
{
    public class ProjectsIndexViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Details")]
        public string Details { get; set; }

        [Display(Name = "ExpectedCompletionDate")]
        public DateTime? ExpectedCompletionDate { get; set; }
        
        [Display(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }
    }
}