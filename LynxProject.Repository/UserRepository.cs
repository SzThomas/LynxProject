using LynxProject.Repository.Entity;
using LynxProject.Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LynxProject.Repository
{
    public class UserRepository : Repository<UserEntity>
    {
        public UserEntity GetUserById(int id)
        {
            return GetById(id);
        }
    }
}
