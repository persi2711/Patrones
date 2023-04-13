using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;


namespace Data.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        public int Add(Domain.Model.Task entity)
        {
            if (entity == null) return 0;;
            using (var ctx = new TodoDBContext())
            {
                ctx.Tasks.Add(entity);
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
                Task us = ctx.Tasks.SingleOrDefault(u => u.Id == id);
                if (us == null) return false;

                ctx.Tasks.Remove(us);

                ctx.SaveChanges();
                return true;
            }
        }

        public Domain.Model.Task Get(int id)
        {
            using (var ctx = new TodoDBContext())
            {
                Task us = ctx.Tasks.SingleOrDefault(u => u.Id == id);
                if (us == null) return null;
                return us;
            }
        }

        public bool Update(Domain.Model.Task entity)
        {
            using (var ctx = new TodoDBContext())
            {
                Task u = ctx.Tasks.SingleOrDefault(x => x.Id == entity.Id);
                if (u == null) return false;
                u.Nombre= entity.Nombre;
                u.Descripcion= entity.Descripcion;
                u.Status= entity.Status;
                

                ctx.SaveChanges();
                return true;
            }
        }
    }
}
