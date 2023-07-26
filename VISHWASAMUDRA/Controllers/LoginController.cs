using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VISHWASAMUDRA.Models;

namespace VISHWASAMUDRA.Controllers
{
    public class LoginController : Controller
    {
		TEST_DBEntities db = new TEST_DBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();  
        }
		[HttpPost]
		public ActionResult Test(LoginUser user)
		{
			var user1=db.LoginUsers.Where(x => x.Username == user.Username && x.Userpwd == user.Userpwd).Count();
			if(user1>0)
			{
				return RedirectToAction("Home");
			}
			else
			{
				return View("Index");
			}
		}
		public ActionResult Home()
		{
			return View();
		}
	}
}