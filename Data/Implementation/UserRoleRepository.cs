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
    public class UserRoleRepository : IUserRoleRepository
    {
        public bool IsUserInRole(string userId, string roleId)
        {
            if (userId == null || roleId == null)
            {
                return false;
            }
            using (var ctx = new TodoDBContext())
            {
                UserRole us = ctx.UserRoles.SingleOrDefault(x => x.theRole.Id == Int32.Parse(roleId));

                if (us == null)
                {
                    return false;
                }
                if (us.theUser.Id == Int32.Parse(userId))
                {
                    return true;
                }
                return false;
            }
        }
    
        public bool RelateUserWithRole(string userId, string roleId)
        {
            if (userId == null || roleId == null)
                return false;
            using (var ctx = new TodoDBContext())
            {

                User us=ctx.Users.SingleOrDefault(x => x.Id ==Int32.Parse(userId));
                Role ro = ctx.Roles.SingleOrDefault(x => x.Id == Int32.Parse(roleId));
                UserRole ur = ctx.UserRoles.Last();
                UserRole urx = new UserRole();
                urx.theRole = ro;
                urx.theUser = us;
                urx.Id = ur.Id + 1;
                ctx.UserRoles.Add(urx);
                ctx.SaveChanges();
                return true;
            }

        }

        public int Add(UserRole entity)
        {
            if (entity == null) return 0;
            using (var ctx = new TodoDBContext())
            {
                ctx.UserRoles.Add(entity);
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

                UserRole us = ctx.UserRoles.SingleOrDefault(x => x.Id == id);
                if (us == null) return false;

                ctx.UserRoles.Remove(us);

                ctx.SaveChanges();
                return true;
            }
        }
        public UserRole Get(int id)
        {
            using (var ctx = new TodoDBContext())
            {
                UserRole us = ctx.UserRoles.SingleOrDefault(u => u.Id == id);
                if (us == null) return null;
                return us;
            }
        }
        public bool Update(UserRole entity)
        {
            using (var ctx = new TodoDBContext())
            {
                UserRole u = ctx.UserRoles.SingleOrDefault(x => x.Id == entity.Id);
                u.theRole = entity.theRole;
                u.theUser = entity.theUser;

                ctx.SaveChanges();
                return true;
            }
        }
    }
}
