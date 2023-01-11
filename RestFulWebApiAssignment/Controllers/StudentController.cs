using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestFulWebApiAssignment.Models;



namespace RestFulWebApiAssignment.Controllers
{
    public class StudentController : Controller
    {
        //********** RETRIEVE ALL EMPLOYEES DETAILS *************
        //GET : Employee
        public ActionResult Index()
        {
            StudentDBHandle dbhandle = new StudentDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetStudent());
        }

        //********** ADD NEW EMPLOYEE *************
        //GET : Employee/Create

        public ActionResult Create()
        {
            return View();
        }

        //POST : Employee/Create
        [HttpPost]

        public ActionResult Create(StudentModel emodel)
        {
            try
            {
                StudentDBHandle edb = new StudentDBHandle();
                edb.AddStudent(emodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
