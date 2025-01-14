using MarotiDemo.DAL;
using MarotiDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarotiDemo.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext context;

        public DepartmentController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
            {
                var result = context.Departments.ToList();
                return View(result);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(Department model)
            {
                if (ModelState.IsValid)
                {
                    var cat = new Department()
                    {
                        deptid = model.deptid,
                        deptname = model.deptname,
                        deptcode= model.deptcode,
                    };
                    context.Departments.Add(cat);
                    context.SaveChanges();
                    return RedirectToAction("Index");


                }
                return View();
            }

            [HttpGet]
            public IActionResult Edit(int id)
            {
                var ct = context.Departments.SingleOrDefault(c => c.deptid == id);
                var result = new Department()
                {
                    deptid = ct.deptid,
                    deptname = ct.deptname,
                    deptcode = ct.deptcode,
                };
                return View(ct);
            }

            [HttpPost]
            public IActionResult Edit(Department category)
            {
                var ct = new Department()
                {
                    deptid = category.deptid,
                    deptname = category.deptname,
                    deptcode = category.deptcode
                };
                context.Departments.Update(ct);
                context.SaveChanges();
                return RedirectToAction("Index");


            }

            public IActionResult Delete(int id)
            {
                var cat = context.Departments.SingleOrDefault(ct => ct.deptid == id);
                context.Departments.Remove(cat);
                context.SaveChanges();

                return RedirectToAction("Index");


            }


    }
}





