using CollegeGrievanceCell.Models;
using CollegeGrievanceCell.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CollegeGrievanceCell.Controllers
{
    public class AdminController : Controller
    {
        public readonly ComplaintFormDbContext dbContext;
        public readonly HomeDbContextClass homeDbContext;
        public AdminController(ComplaintFormDbContext dbContext, HomeDbContextClass homeDbContext)
        {
            this.dbContext=dbContext;
            this.homeDbContext=homeDbContext;
        }

        public IActionResult index()
        {
            return View();
        }

        public IActionResult AllComplaints()
        {
          var result=dbContext.GetAllComplaints();

          return View(result);
        }

        public IActionResult PendingComplaintsSolve()
        {
           return RedirectToAction("PendingComplaintsSolve","Hod");
        }

        public IActionResult SolvedComplaints()
        {
            var result=dbContext.GetSolveComplaints();
            return View (result);
        }

        [HttpGet]
        public IActionResult AddStudDetails() {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudDetails(StudentLogin obj)
        {
            homeDbContext.InsertData(obj);
            return View("Index");
        }

        [HttpGet]
        public IActionResult DeleteStudDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteStudDetails(int id)
        {
            homeDbContext.DeleteStudent(id);
            return View("Index");
        }



    }
}
