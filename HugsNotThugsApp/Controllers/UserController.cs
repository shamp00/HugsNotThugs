using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HugsNotThugsApp.Models;

namespace HugsNotThugsApp.Controllers
{
    public class UserController : Controller
    {
        private SocialContext db = new SocialContext();

        //
        // GET: /User/
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        //GET: /User/Details/
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Details(int id = 0)
        {
            //Our keys in the UserProfile and User table are off by one
            //This is the solution because deleting the contents of the DB didn't help

            UserRepository ur = new UserRepository();
            User user = ur.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

    }
}
