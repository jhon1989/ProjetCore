using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjetCore.Logica.BL
{
    public class Projects
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenantId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ///
        
        public List<Models.DB.Projects> GetProjects(int? id, int? tenantId, string userId = null)
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();

            var listProject = (from _project in _context.Projects select _project).ToList();

            if (id != null) 
            {
                listProject = listProject.Where(project => project.Id == id).ToList();
            }

            if (tenantId != null)
            {
                listProject = listProject.Where(project => project.TenantId == tenantId).ToList();
            }

            if (!string.IsNullOrEmpty(userId))
            {
                listProject = (from _project in listProject
                               join _userProjects in _context.UserProjects on _project.Id equals _userProjects.ProjectId
                               where _userProjects.UserId.Equals(userId)
                               select _project).ToList();
            }

            var listProj = (from _projects in listProject
                               select new Models.DB.Projects
                               {
                                   Id = _projects.Id,
                                   Title =_projects.Title,
                                   Details = _projects.Details,
                                   ExpectedCompletionDate = _projects.ExpectedCompletionDate,
                                   TenantId = _projects.TenantId,
                                   CreatedAt = _projects.CreatedAt,
                                   UpdatedAt = _projects.UpdatedAt
                               }).ToList();

            return listProj;
        }

        /// <summary>
        /// Create new project
        /// </summary>
        /// <param name="title"></param>
        /// <param name="details"></param>
        /// <param name="expectedCompletionDate"></param>
        /// <param name="tenantId"></param>
        public void CreateProject(string title, string details, DateTime expectedCompletionDate, int? tenantId)
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();

            _context.Projects.Add(new DAL.Models.Projects
            {
                Title = title,
                Details = details,
                ExpectedCompletionDate = expectedCompletionDate,
                TenantId = tenantId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            _context.SaveChanges();
        }

        public void UpdateProject(int id, string title, string details, DateTime expectedCompletionDate)
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();
            var proje = _context.Projects.Where(x => x.Id == id).FirstOrDefault();

            proje.Title = title;
            proje.Details = details;
            proje.ExpectedCompletionDate = expectedCompletionDate;
            proje.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();
            var proje = _context.Projects.Where(x => x.Id == id).FirstOrDefault();
        
            _context.Projects.Remove(proje);

            _context.SaveChanges();
        }
    }
}
