using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynxProject.Repository.Repo
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private string connectionString;

        public Repository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseThomas"].ConnectionString;
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var entity = connection.Get<T>(id);
                connection.Delete<T>(entity);

                connection.Close();

                return true;
            }
        }

        public T GetById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var entity = connection.Get<T>(id);

                connection.Close();

                return entity;
            }
         
        }

        public List<User> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var collection = connection.GetAll<User>();

                connection.Close();

                return collection.ToList();
            }
        }

        public int Insert(T entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var id = connection.Insert<T>(entity);

                connection.Close();

                return Convert.ToInt32(id);
            }
        }

        public void Update(T entity)
        {
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseThomas"].ConnectionString))
            //{
            //    string sqlQuery = "UPDATE SET FirstName = @FirstName, " + "LastName = @LastName" + "WHERE Id = @Id";
            //    int rowsAffected = db.Execute(sqlQuery, entity);
            //    return rowsAffected;
            //}
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Update<T>(entity);

                connection.Close();
            }
        }
    }
}
