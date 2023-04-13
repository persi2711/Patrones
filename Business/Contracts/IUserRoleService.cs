using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IUserRoleService
    {
        //Create
        int Add(UserRole user_rol);
        //Read
        UserRole Get(int id);
        //Update
        bool Update(UserRole user_rol);
        //Delete
        bool Delete(int id);
    }
}
