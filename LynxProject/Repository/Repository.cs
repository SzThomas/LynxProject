using Dapper;
using LynxProject.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LynxProject.Controllers;

namespace LynxProject.UI.Repository
{
    public class Repository
    {
        private string connectionString;

        public Repository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseThomas"].ConnectionString;
        }

        public int Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                User u = new User { Id = id };
                string sqlQuery = "DELETE FROM Users WHERE Id = @Id";
                var rowsAffected = db.Execute(sqlQuery, u);
                return rowsAffected;
            }
        }

        public User GetById(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                User u = new User { Id = id };
                string sqlQuery = "SELECT * FROM Users WHERE Id = @Id";
                User user = db.Query<User>(sqlQuery, u).FirstOrDefault();
                return user;
            }
        }

        public List<User> GetAll()
        {
            List<User> userList = new List<User>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Users";
                userList = db.Query<User>(sqlQuery).ToList();
            }

            return userList;
        }

        public void Insert(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = @"INSERT INTO Users (Username, FirstName, LastName, Email, Password, PhoneNumber) Values(@Username, @FirstName, @LastName, @Email, @Password, @PhoneNumber)";
                db.Execute(sqlQuery, user);
            }
        }

        public int Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE Users SET Username = @Username, FirstName = @FirstName, LastName = @LastName, Email = @Email, Password = @Password, PhoneNumber = @PhoneNumber  WHERE Id = @Id"; 
                int updateUser = db.Execute(sqlQuery, user);
                return updateUser;
            }
        }

        public List<User> GetAllUsers(string searchText)
        {
            var repository = new Repository();
            var users = repository.GetAll();
            List<User> listOfUsers = new List<User>();

            foreach (var user in users)
            {
                if (user.Username.ToLower().Contains(searchText.ToLower()) || user.FirstName.ToLower().Contains(searchText.ToLower()) || user.LastName.ToLower().Contains(searchText.ToLower()) || user.Email.ToLower().Contains(searchText.ToLower()))
                {
                    listOfUsers.Add(ConvertToUser(user));
                }
            }

            return listOfUsers;
        }

        private User ConvertToUser(User userModel)
        {
            var user = new User
            {
                Id = userModel.Id,
                Username = userModel.Username,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Password = userModel.Password,
                PhoneNumber = userModel.PhoneNumber
            };

            return userModel;
        }
    }
}
