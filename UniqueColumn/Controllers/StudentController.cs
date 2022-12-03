using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using UniqueColumn.Data;
using UniqueColumn.Models;

namespace UniqueColumn.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var student = new Student();
            return View(student);
        }

        [HttpPost]
        public IActionResult Save(Student model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Student.Add(model);

            try
            {
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                SqlException innerException = ex.InnerException as SqlException;
                if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                {
                    //your handling stuff
                    TempData["error"] = "No data inserted";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw;
                }
            }

            TempData["success"] = "Data inserted successfully";
            return RedirectToAction(nameof(Index));

        }
    }
}
