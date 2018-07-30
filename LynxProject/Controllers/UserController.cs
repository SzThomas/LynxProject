using LynxProject.Core;
using LynxProject.Models;
using LynxProject.UI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LynxProject.Controllers
{
    public class UserController : Controller
    {
        private Repository repository = new Repository();

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Search(string text)
        {
            try
            {
                List<User> users = new List<User>();
                users = repository.GetAllUsers(text);

                users.Add(new User()
                {
                    Username = "Username",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Email = "Email",
                    Password = "Password",
                    PhoneNumber = "PhoneNumber"
                });

                return Json(users, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return null;
            }
        }
        
        public ActionResult Index()
        {
            List<User> users = repository.GetAll();
            ViewBag.Title = "Index";
            return View(users);
        }
        
        public ActionResult Details(int id)
        {
            return View();
        }
        
        public ActionResult Create()
        {
            var model = new UserModel();
            ViewBag.Title = "Create";
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Create(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var uModel = new User {
                        Id = userModel.Id,
                        Username = userModel.Username,
                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        Email = userModel.Email,
                        Password = userModel.Password,
                        PhoneNumber = userModel.PhoneNumber
                    };
                    if (userModel.Id != 0)
                {
                    var updateUser = new User
                    {
                        Id = userModel.Id,
                        Username = userModel.Username,
                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        Email = userModel.Email,
                        Password = userModel.Password,
                        PhoneNumber = userModel.PhoneNumber
                    };
                    repository.Update(updateUser);
                        
                    } 
                    else { 
                    repository.Insert(uModel);
                        return RedirectToAction("Index");
                    }
                return RedirectToAction("Index");
                    
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
}
        
        public ActionResult Edit(int id)
        {
            User u = repository.GetById(id);
            UserModel um = new UserModel();
            um.Id = u.Id;
            um.Username = u.Username;
            um.FirstName = u.FirstName;
            um.LastName = u.LastName;
            um.Email = u.Email;
            um.Password = u.Password;
            um.PhoneNumber = u.PhoneNumber;
            ViewBag.Title = "Edit";
            return View("Create", um);
        }        
        
        public ActionResult Delete(int id)
        {
            int rowsAffected = repository.Delete(id);
            if(rowsAffected > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
