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
    public class UserRoleServices : IUserRoleService
    {
        private readonly IUserRoleService _userRolRepo;
        public UserRoleServices (IUserRoleService userRepo)
        {
            _userRolRepo = userRepo;
        }
        public int Add(UserRole user_rol)
        {
            if (user_rol.Id <= 0) return 0;
            if (user_rol.theRole==null) return 0;
            if (user_rol.theUser==null) return 0;
            return _userRolRepo.Add(user_rol);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (_userRolRepo.Delete(id));
        }

        public UserRole Get(int id)
        {
            UserRole u = _userRolRepo.Get(id);
            return u;
        }

        public bool Update(UserRole user_rol)
        {
            if (user_rol.Id <= 0) return false;
            if (user_rol.theRole == null) return false;
            if (user_rol.theUser == null) return false;
            return _userRolRepo.Update(user_rol);
        }
    }

}

