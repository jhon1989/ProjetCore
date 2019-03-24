using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjetCore.Controllers
{
    public class ProjectsController : Controller
    {
        private List<Logica.Models.ViewModel.ProjectsIndexViewModel> listProjects;

        public ProjectsController()
        {
            listProjects = new List<Logica.Models.ViewModel.ProjectsIndexViewModel>();

            listProjects.Add(new Logica.Models.ViewModel.ProjectsIndexViewModel
            {
                Id = 1,
                Details = "Project management details",
                Title = "Project management",
                CreatedAt = DateTime.Now,
                ExpectedCompletionDate = DateTime.Now.AddDays(5)
            });

            listProjects.Add(new Logica.Models.ViewModel.ProjectsIndexViewModel
            {
                Id = 2,
                Details = "Sales details",
                Title = "Sales",
                CreatedAt = DateTime.Now,
                ExpectedCompletionDate = DateTime.Now.AddDays(10)
            });
        }
        
        public IActionResult Index()
        {
            //ViewBag.listProjects = listProjects;

            return View(listProjects); //Retorna a la vista que se llame igual que la accion
        }
    }
}