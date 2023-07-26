using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VISHWASAMUDRA.Models;

namespace VISHWASAMUDRA.Controllers
{
    public class TestController : Controller
    {
		// GET: Test
		internal void Forward()
		{
			TestDb obj = new TestDb();
			DataTable mydt = obj.GetVehicleType();
			ViewBag.Edit = mydt;
		}
		public ActionResult Index()
		{
			Forward();
			return View();
		}
		[HttpPost]
		public ActionResult Insert()
		{
			if (Request["txtvhtname"] == "" || Request["txtLoadCapacity"] == "" || Request["Recordstatus"] == "")
			{
				Forward();
				return View("Index");
			}
			else
			{
				TestDb testDb = new TestDb()
				{
					VHT_Name = Request["txtvname"],
					LOADCAPACITYCBM = int.Parse(Request["load"]),
					RecordStatus = Request["language"]
				};
				ViewData["Insert"] = testDb.TestInsert();
				Forward();
				return View("Index");
			}
		}
		public ActionResult DeleteCntrl()
		{
			if (Request.QueryString["VHT_ID"] == "")
			{
				Forward();
				return View("Index");
			}
			else
			{
				TestDb obj = new TestDb()
				{
					VHTID = int.Parse(Request.QueryString["VHT_ID"])
				};
				ViewBag.delete = obj.Delete();
				Forward();
			}
			return View("Index");
		}
		public ActionResult Edit1()
		{
			TestDb db = new TestDb()
			{
				VHTID = int.Parse(Request.QueryString["VHT_ID"]),
			};
			ViewBag.Edit = db.Get();
			Forward();
			return View("EditIndex");
		}
		public ActionResult EditIndex()
		{
			if (Request["txtLoadCapacity"] == "")
			{
				return View();
			}
			else
			{
				TestDb db = new TestDb()
				{
					VHTID = int.Parse(Request["txtvhtid"]),
					LOADCAPACITYCBM = int.Parse(Request["txtLoadCapacity"])
				};
				ViewBag.update = db.Update();
				Forward();
				return View();
			}
		}
	}
}