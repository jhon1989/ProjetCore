using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjetCore.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index(int? projectId)
        {

            Logica.BL.Tasks tasks = new Logica.BL.Tasks();

            var getTask = tasks.GetTasks(projectId, null);

            var listTask = getTask.Select(x => new Logica.Models.ViewModel.TasksViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Details = x.Details,
                ExpirationDate = x.ExpirationDate,
                IsCompleted = x.IsCompleted,
                Effort = x.Effort,
                RemainingWork = x.RemainingWork,
                State = x.State.Name,
                Activity = x.Activity.Name,
                Priority = x.Priority.Name
            });

            Logica.BL.Projects projects = new Logica.BL.Projects();
            var proje = projects.GetProjects(projectId, null).FirstOrDefault();

            ViewBag.Project = proje.Id;


            return View(listTask);
        }

        public IActionResult Create(int? projectId)
        {
            var taskBindingModel = new Logica.Models.BindingModel.TaskCreateBindingModel
            {
                ProjectId = projectId
            };

            Logica.BL.States states = new Logica.BL.States();
            ViewBag.States = states.GetStates();

            Logica.BL.Priorities priorities = new Logica.BL.Priorities();
            ViewBag.Priorities = priorities.GetPriorieties();

            Logica.BL.Activities activities = new Logica.BL.Activities();
            ViewBag.Activities = activities.GetActivities();

            return View(taskBindingModel);
        }

        [HttpPost]
        public IActionResult Create(Logica.Models.BindingModel.TaskCreateBindingModel model)
        {
            if (ModelState.IsValid)
            {
               
                Logica.BL.Tasks tasks = new Logica.BL.Tasks();

                tasks.CreateTask(model);

                return RedirectToAction("Index");
            }

            Logica.BL.States states = new Logica.BL.States();
            ViewBag.States = states.GetStates();

            Logica.BL.Priorities priorities = new Logica.BL.Priorities();
            ViewBag.Priorities = priorities.GetPriorieties();

            Logica.BL.Activities activities = new Logica.BL.Activities();
            ViewBag.Activities = activities.GetActivities();

            return View(model);
        }
    }
}