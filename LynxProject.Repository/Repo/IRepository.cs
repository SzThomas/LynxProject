using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynxProject.Repository.Repo
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        List<User> GetAll();

        int Insert(T entity);

        void Update(T entity);

        bool Delete(int id);
    }
}
