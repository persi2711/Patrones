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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _rolRepo;
        public RoleService(IRoleRepository userRepo)
        {
            _rolRepo = userRepo;
        }
        public int Add(Role _rol)
        {
            if (_rol.Id <= 0) return 0;
            if (string.IsNullOrEmpty(_rol.Name)) return 0;
            return _rolRepo.Add(_rol);
        }

        public bool Delete(int id)
        {
            if(id <= 0) return false;
            return (_rolRepo.Delete(id));
        }

        public Role Get(int id)
        {
            Role u = _rolRepo.Get(id);
            return u;
        }

        public bool Update(Role _rol)
        {
            if (_rol.Id <= 0) return false;
            if (string.IsNullOrEmpty(_rol.Name)) return false;
            return _rolRepo.Update(_rol);
        }
    }
}
