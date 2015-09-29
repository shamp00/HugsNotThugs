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

    [InitializeSimpleMembership]
    public class HomeController : Controller
    {

         private IUserRepository ur;

        /*
         *  Name: HomeController
         *  Description: Set up the controller for web deployment with a
         *               concrete user repository.
         */
         public HomeController()
             : this(new UserRepository())
         { }

        /*
         *  Name: HomeController
         *  Description: Constructer that allows the UserRepository to be injected.                   
         */
        public HomeController(IUserRepository userrepo)
        {
            ur = userrepo;
        }

        /*  
         *  Name: Index 
         *  Description: Returns the main map page.
         *  View: /Home/Index/
         */ 
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Here we goooooo!";

            return View("Index");
        }

    }
}