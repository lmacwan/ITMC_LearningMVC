using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningMVC.Controllers
{
    public class MyController : Controller
    {
        //
        // GET: /My/

        public ActionResult Index()
        {
            var dbContext = new MyDBDataContext();
            var userList = from user in dbContext.Users select user;
            var users = new List<LearningMVC.Models.UserList>();
            if (userList.Any())
            {
                foreach (var user in userList)
                {
                    users.Add(new LearningMVC.Models.UserList() { UserId = user.UserId, Address = user.Address, Company = user.Company, Designation = user.Designation, Email = user.EMail, FirstName = user.FirstName, LastName = user.LastName, PhoneNo = user.PhoneNo });
                }
            }
            ViewBag.FirstName = 100d;
            return View(users);
        }

        //
        // GET: /My/Details/5

        public ActionResult Details(int id)
        {
            var dbContext = new MyDBDataContext();
            var userDetails = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
            var user = new LearningMVC.Models.UserList();
            if (userDetails != null)
            {
                user.UserId = userDetails.UserId;
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.Address = userDetails.Address;
                user.PhoneNo = userDetails.PhoneNo;
                user.Email = userDetails.EMail;
                user.Company = userDetails.Company;
                user.Designation = userDetails.Designation;
            }
            return View(user);

        }

        //
        // GET: /My/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /My/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here
                var dbContext = new MyDBDataContext();
                dbContext.Users.InsertOnSubmit(user);
                dbContext.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /My/Edit/5
 
        public ActionResult Edit(int? id)
        {

            var dbContext = new MyDBDataContext();
            var userDetails = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
            var user = new LearningMVC.Models.UserList();
            if (userDetails != null)
            {
                user.UserId = userDetails.UserId;
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.Address = userDetails.Address;
                user.PhoneNo = userDetails.PhoneNo;
                user.Email = userDetails.EMail;
                user.Company = userDetails.Company;
                user.Designation = userDetails.Designation;
            }
            return View(user);

        }

        //
        // POST: /My/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, User userDetails)
        {
            TempData["TempData Name"] = "Leon";

            try
            {
                var dbContext = new MyDBDataContext();
                var user = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
                if (user != null)
                {
                    user.FirstName = userDetails.FirstName;
                    user.LastName = userDetails.LastName;
                    user.Address = userDetails.Address;
                    user.PhoneNo = userDetails.PhoneNo;
                    user.EMail = userDetails.EMail;
                    user.Company = userDetails.Company;
                    user.Designation = userDetails.Designation;
                    dbContext.SubmitChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        //
        // GET: /My/Delete/5
 
        public ActionResult Delete(int id)
        {
            var dbContext = new MyDBDataContext();
            var user = new LearningMVC.Models.UserList();
            var userDetails = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
            if (userDetails != null)
            {
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.Address = userDetails.Address;
                user.PhoneNo = userDetails.PhoneNo;
                user.Email = userDetails.EMail;
                user.Company = userDetails.Company;
                user.Designation = userDetails.Designation;
            }
            return View(user);

        }

        //
        // POST: /My/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var dbContext = new MyDBDataContext();
                var user = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
                if (user != null)
                {
                    dbContext.Users.DeleteOnSubmit(user);
                    dbContext.SubmitChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}
