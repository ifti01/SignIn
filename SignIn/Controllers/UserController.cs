using SignIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignIn.Controllers
{
    public class UserController : Controller
    {
        SignInLoginEntities db = new SignInLoginEntities();

        // GET: User
        public ActionResult Index()
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            else {
                //var model = new UserTask();
                //model.userTasks= db.UserTasks.ToList();
                //return View(model);
                List<UserTask> userTasks= db.UserTasks.ToList();
                return View(userTasks);
            }
            
        }


        public ActionResult Task() {

            return View();
        }

        [HttpPost]
        public ActionResult Task(UserTask userTaskobj) {

            
            {
                if (ModelState.IsValid == true)
                {
                    db.UserTasks.Add(userTaskobj);
                    int a = db.SaveChanges();

                    if (a > 0)
                    {
                        ViewBag.InsertMessage = "<script>alert('Registerd Successfully'')</script>";
                        ModelState.Clear();
                        return View();
                    }

                    else
                    {
                        ViewBag.InsertMessage = "<script>alert('Registerd Failed'')</script>";
                    }
                }

            }




            return View();
        }

        public ActionResult Logout() {
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

    }
}