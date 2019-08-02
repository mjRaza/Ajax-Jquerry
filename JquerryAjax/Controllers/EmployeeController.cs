using JquerryAjax.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JquerryAjax.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewAll()
        {
            return View(GetEmployees());
        }



        IEnumerable<Employee> GetEmployees()
        {
            DBModel db = new DBModel();
            return db.Employees.ToList();

        }



        public ActionResult AddorEdit(int id=0)
        {
            Employee emp = new Employee();
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddorEdit(Employee emp)

        {
            if(emp.ImageUpload !=null)
            {
                string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                string extension = Path.GetExtension(emp.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                emp.ImagePath = "~/AppFiles/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName);
                emp.ImageUpload.SaveAs(fileName);

            }

            using (DBModel db = new DBModel())
            {
                db.Employees.Add(emp);
                db.SaveChanges();
            }




            return RedirectToAction("ViewAll");
        }




    }
}