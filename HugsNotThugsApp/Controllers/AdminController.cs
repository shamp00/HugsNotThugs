using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HugsNotThugsApp.Models;
using WebMatrix.WebData;
using HugsNotThugsApp.Filters;
namespace HugsNotThugsApp.Controllers
{
    public class AdminController : Controller
    {
        private ISocialContext db;
           private IWebSecurity WebSecurity { get; set; }

          public AdminController()
            : this(ContextHelper.GetContext(), new WebSecurityWrapper())
        { }
        public AdminController(ISocialContext sc, IWebSecurity webSecurity)
        {
            WebSecurity = webSecurity;
            db = sc;
        }


        //
        // GET: /Admin/
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index",db.Users.ToList());
        }

        //
        // GET: /Admin/
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult _Index(String uName)
        {
            System.Web.Security.Roles.RemoveUserFromRole(uName, "User");
            System.Web.Security.Roles.AddUserToRole(uName, "Admin");

            return RedirectToAction("Index");
            
        }
    }
}