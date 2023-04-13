using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class ProjectRepository : IProjectRepository
    {
        public int Add(Project entity)
        {
            if (entity == null) return 0; ;
            using (var ctx = new TodoDBContext())
            {
                ctx.Projects.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }
        }

        public bool Delete(int id)
        {
            if (id < 0)
                return false;
            using (var ctx = new TodoDBContext())
            {
                Project us = ctx.Projects.SingleOrDefault(u => u.Id == id);
                if (us == null) return false;

                ctx.Projects.Remove(us);

                ctx.SaveChanges();
                return true;
            }
        }

        public Project Get(int id)
        {
            using (var ctx = new TodoDBContext())
            {
                Project us = ctx.Projects.SingleOrDefault(u => u.Id == id);
                if (us == null) return null;
                return us;
            }
        }

        public bool RelateTask(Domain.Model.Task newTask,int idProject)
        {
            using (var ctx = new TodoDBContext())
            {
                Project us = ctx.Projects.SingleOrDefault(u => u.Id == idProject);
                if (us == null) return false;

                us.tasks.Add(newTask);
                ctx.SaveChanges();
                return true;
            }
        }

        public bool Update(Project entity)
        {
            using (var ctx = new TodoDBContext())
            {
                Project u = ctx.Projects.SingleOrDefault(x => x.Id == entity.Id);
                u.Name = entity.Name;
                u.tasks = entity.tasks;
                u.Description = entity.Description;

                ctx.SaveChanges();
                return true;
            }
        }
    }
}
