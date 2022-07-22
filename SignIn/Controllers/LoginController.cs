using SignIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignIn.Controllers
{
    public class LoginController : Controller
    {
        SignInLoginEntities db = new SignInLoginEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User userobj)
        {
            var user = db.Users.Where(model => model.UserName == userobj.UserName &&  model.Password == userobj.Password).FirstOrDefault();
            if(user != null)
            {
                Session["UserId"] = userobj.Id.ToString();
                Session["UserName"] = userobj.UserName.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('SAved Successfully'')</script>";
                return RedirectToAction("Index","User");
            }

            else
            {
                ViewBag.ErrorMessage = "<script>alert('Username or Password incorrect')</script>";
            }

            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]

        //User - Model,Users -- Table//
        public ActionResult Signup(User userobject)
        {
            if (ModelState.IsValid == true)
            {
                db.Users.Add(userobject);
                int a =   db.SaveChanges();

                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registerd Successfully'')</script>";
                    ModelState.Clear();
                }

                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registerd Failed'')</script>";
                }
            }

            return View();
     }
   
    }
}