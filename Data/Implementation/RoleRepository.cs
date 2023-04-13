using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        public int Add(Role entity)
        {
            if (entity == null) return 0;
            using (var ctx = new TodoDBContext())
            {
                ctx.Roles.Add(entity);
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
                Role us = ctx.Roles.SingleOrDefault(u => u.Id == id);
                if (us == null) return false;

                ctx.Roles.Remove(us);

                ctx.SaveChanges();
                return true;
            }
        }

        public Role Get(int id)
        {
            using (var ctx = new TodoDBContext())
            {
                Role us = ctx.Roles.SingleOrDefault(u => u.Id == id);
                if (us == null) return null;
                return us;
            }
        }

        public bool Update(Role entity)
        {
            using (var ctx = new TodoDBContext())
            {
                Role u = ctx.Roles.SingleOrDefault(x => x.Id == entity.Id);
                if (u == null) return false;    
                u.Name = entity.Name;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
