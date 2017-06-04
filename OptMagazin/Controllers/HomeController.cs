using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OptMagazin.Models;

namespace OptMagazin.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {


        
            
            //var context = new UserContext(); 
            //var user = new User()
            //{
            //    Id = 1,
            //   Email = "admin",
            //    Password = "admin",
            //    CreationDate = DateTime.Now
            //};
            //var users = context.Users.ToList();
            //context.Users.Add(user);
            //context.SaveChanges();

            return View();
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[Authorize(Roles = "Admin, AllUsers")]
        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}