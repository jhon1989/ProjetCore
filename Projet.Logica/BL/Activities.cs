﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjetCore.Logica.BL
{
    public class Activities
    {

        public List<Models.DB.Activities> GetActivities()
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();

            var listActivities = (from _activities in _context.Activities
                                  where _activities.Active == true
                                  select new Models.DB.Activities
                                  {
                                      Id = _activities.Id,
                                      Name = _activities.Name,
                                      Active = _activities.Active
                                  });


            return listActivities.ToList();


        }
    }
}
