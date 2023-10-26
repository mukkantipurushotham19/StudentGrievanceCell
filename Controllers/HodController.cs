using CollegeGrievanceCell.Models;
using CollegeGrievanceCell.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CollegeGrievanceCell.Controllers
{
    public class HodController : Controller
    {
        public readonly ComplaintFormDbContext dbContext;
       
        public HodController(ComplaintFormDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllComplaints()
        {
            var result = dbContext.GetAllComplaints();
            return View(result);
        }
        public IActionResult PendingComplaintsSolve()
        {
            var result = dbContext.GetPendingComplaints();
            return View(result);
        }

        public IActionResult Edit(int id)
        {
            var result = dbContext.GetComplaint(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(ComplaintForm form)
        {
            dbContext.UpdateStatus(form);
            return View("index");
        }










    }
}
