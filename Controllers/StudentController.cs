using CollegeGrievanceCell.Models;
using CollegeGrievanceCell.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CollegeGrievanceCell.Controllers
{
    public class StudentController : Controller
    {
        public readonly ComplaintFormDbContext dbContext;

        public StudentController(ComplaintFormDbContext dbContextClass)
        {
            dbContext = dbContextClass;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ComplaintForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ComplaintForm(ComplaintForm obj)
        {
            bool IsInserted=dbContext.InsertRecord(obj);
            if(IsInserted)
            {
                ViewBag.msg = "Complaint Registered Succefully";
            }
            else
            {
                ViewBag.msg = "Complaint Not Registered ";
            }
            return View();
        }

        [HttpGet]
        public IActionResult CompDetailsById()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CompDetailsById(int Cid)
        {
            TempData["id"] = Cid;
            return RedirectToAction("CompDetailsById_2","Student");
        }

        [HttpGet]
        public IActionResult CompDetailsById_2()
        {
            int id = (int)TempData["id"];

            var result=  dbContext.GetComplaint(id);

            if (result.ComplaintType == null)
            {
                TempData["msgid"] = "Complaint You Are Searching Not Available";
                return RedirectToAction("CompDetailsById","Student");
            }
            else
            {
                return View(result);
            }
        }

        public IActionResult PendingComplaints()
        {
           var result= dbContext.GetPendingComplaints();
            return View(result);
        }

        public IActionResult SolveComplaints()
        {
            var result = dbContext.GetSolveComplaints();
            return View(result);
        }


    }
}
