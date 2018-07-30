using LynxProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynxProject.BLL
{
    public interface IUserService
    {
        User GetUserById(int id);

        List<User> GetAll();
       
        void Save(User user);

        bool Delete(int Id);
    }
}
