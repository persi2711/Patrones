using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    internal class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepo;
        public ProjectService(IProjectRepository userRepo)
        {
            projectRepo = userRepo;
        }
        public int Add(Project project)
        {
            if (project.Id <= 0) return 0;
            if (string.IsNullOrEmpty(project.Name)) return 0;
            if (string.IsNullOrEmpty(project.Description)) return 0;
            return projectRepo.Add(project );
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (projectRepo.Delete(id));
        }

        public Project Get(int id)
        {
            Project u = projectRepo.Get(id);
            return u;
        }

        public bool Update(Project project)
        {
            if (project.Id <= 0) return false;
            if (string.IsNullOrEmpty(project.Name)) return false;
            if (string.IsNullOrEmpty(project.Description)) return false;
            return projectRepo.Update(project);
        }
    }
}
