using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProjetCore.Controllers
{
    public class ProjectsController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        public ProjectsController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IdentityUser user = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Logica.BL.Tenants tenants = new Logica.BL.Tenants();

            var tenent = tenants.GetTenants(user.Id).FirstOrDefault();

            Logica.BL.Projects projects = new Logica.BL.Projects();
            var result = await _userManager.IsInRoleAsync(user, "Admin") ?
                projects.GetProjects(null, tenent.Id) :
                projects.GetProjects(null, tenent.Id, user.Id);

            var listProject = result.Select(x => new Logica.Models.ViewModel.ProjectsIndexViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Details = x.Details,
                CreatedAt = x.CreatedAt,
                ExpectedCompletionDate = x.ExpectedCompletionDate,
                UpdatedAt = x.UpdatedAt
            });

            listProject = tenent.Plan.Equals("premium") ?
                listProject :
                listProject.Take(1).ToList();

            return View(listProject); //Retorna a la vista que se llame igual que la accion
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Logica.Models.BindingModel.ProjectCreateBindingModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                Logica.BL.Tenants tenants = new Logica.BL.Tenants();
                var tenent = tenants.GetTenants(user.Id).FirstOrDefault();

                Logica.BL.Projects projects = new Logica.BL.Projects();

                projects.CreateProject(model.Title, model.Details, model.ExpectedCompletionDate, tenent.Id);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Logica.BL.Projects projects = new Logica.BL.Projects();
            var result = projects.GetProjects(id, null).FirstOrDefault();

            var projectEditModel = new Logica.Models.BindingModel.ProjectEditBindingModel
            {
                Id = result.Id,
                Details = result.Details,
                Title = result.Title,
                ExpectedCompletionDate = result.ExpectedCompletionDate.Value
            };

            return View(projectEditModel);
        }

        [HttpPost]
        public IActionResult Edit(Logica.Models.BindingModel.ProjectEditBindingModel model)
        {
            if (ModelState.IsValid)
            {
                Logica.BL.Projects projects = new Logica.BL.Projects();
                projects.UpdateProject(model.Id, model.Title, model.Details, model.ExpectedCompletionDate);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Logica.BL.Projects projects = new Logica.BL.Projects();
            projects.DeleteProject(id);
            return RedirectToAction("Index");
        }

        public IActionResult Show(int id)
        {
            Logica.BL.Projects projects = new Logica.BL.Projects();
            var result = projects.GetProjects(id, null).FirstOrDefault();

            var projectEditModel = new Logica.Models.BindingModel.ProjectEditBindingModel
            {
                Id = result.Id,
                Details = result.Details,
                Title = result.Title,
                ExpectedCompletionDate = result.ExpectedCompletionDate.Value
            };

            return View(projectEditModel);
        }
    }
}