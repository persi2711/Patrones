using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    internal interface IProjectService
    {
        int Add(Project project);
        //Read
        Project Get(int id);
        //Update
        bool Update(Project project);
        //Delete
        bool Delete(int id);
    }
}
