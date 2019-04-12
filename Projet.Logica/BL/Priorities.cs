﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjetCore.Logica.BL
{
    public class Priorities
    {
        /// <summary>
        /// GET PRIORITIES
        /// </summary>
        /// <returns></returns>
        public List<Models.DB.Priorities> GetPriorieties()
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();
            var listPriorities = (from _priorities in _context.Priorities
                                  where _priorities.Active == true
                                  select new Models.DB.Priorities
                                  {
                                      Id = _priorities.Id,
                                      Name = _priorities.Name,
                                      Active = _priorities.Active

                                  }).ToList();
            return listPriorities;
        }
    }
}
