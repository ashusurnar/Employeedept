using MarotiDemo.DAL;
using MarotiDemo.Models;
using MarotiDemo.Models.AddViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MarotiDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext context)
        {
            this.context=context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = (from p in context.Employees
                        join c in context.Departments
                        on p.empid equals c.deptid
                        select new EmpDataSummary
                        {
                            empid = p.empid,
                            empname = p.empname,
                            city = p.city,
                            salary = p.salary,
                            deptid = c.deptid,
                            deptname=c.deptname,
                            deptcode = c.deptcode

                        }).ToList();

            return View(data);
        }

        public IActionResult Create ()
        {
            ViewBag.department = context.Departments.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmpDataSummary model)
        {
            ModelState.Remove("deptname");
            ModelState.Remove("deptcode");

            ViewBag.department = context.Departments.ToList();
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    
                    empname=model.empname,
                    city=model.city,
                    salary=model.salary,
                    deptid=model.deptid,
                    
                };
                context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return  View();
        }
    }
}
