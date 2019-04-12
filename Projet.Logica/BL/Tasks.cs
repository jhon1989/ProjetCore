using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjetCore.Logica.BL
{
    public class Tasks
    {

        public List<Models.DB.Tasks> GetTasks(int? projectId, int? id)
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();

            var listTask = (from _task in _context.Tasks
                            join _states in _context.States on _task.StateId equals _states.Id
                            join _activities in _context.Activities on _task.ActivityId equals _activities.Id
                            join _priorities in _context.Priorities on _task.PriorityId equals _priorities.Id
                            select new Models.DB.Tasks
                            {
                                Id = _task.Id,
                                Title = _task.Title,
                                Details = _task.Details,
                                ExpirationDate = _task.ExpirationDate,
                                IsCompleted = _task.IsCompleted,
                                Effort = _task.Effort,
                                RemainingWork = _task.RemainingWork,
                                StateId = _task.StateId,
                                State = new Models.DB.States
                                {
                                    Name = _states.Name,
                                },
                                PriorityId = _task.PriorityId,
                                Priority = new Models.DB.Priorities
                                {
                                    Name = _priorities.Name
                                },
                                ActivityId = _task.ActivityId,
                                Activity = new Models.DB.Activities
                                {
                                    Name = _activities.Name
                                },
                                ProjectId = _task.ProjectId


                            }).ToList();

            if (projectId != null)
            {
                listTask = listTask.Where(x => x.ProjectId == projectId).ToList();
            }

            if (id != null)
            {
                listTask = listTask.Where(x => x.Id == id).ToList();
            }


            return listTask;
        }

        public void CreateTask(Logica.Models.BindingModel.TaskCreateBindingModel model)
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();

            _context.Tasks.Add(new DAL.Models.Tasks
            {
                Title = model.Title,
                Details = model.Details,
                ExpirationDate = model.ExpirationDate,
                IsCompleted = model.IsCompleted,
                Effort = model.Effort,
                RemainingWork = model.RemainingWork,
                StateId = model.StateId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                PriorityId = model.PriorityId
            });

            _context.SaveChanges();
        }
    }

} 
