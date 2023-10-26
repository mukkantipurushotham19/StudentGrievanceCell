using CollegeGrievanceCell.Filters.ActionFilters;
using CollegeGrievanceCell.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CollegeGrievanceCell.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeDbContextClass dataContext;

        //public HomeController(IConfiguration configuration)
        //{
        //    string connectionString = configuration.GetConnectionString("ConStr");
        //    dataContext= new HomeDbContextClass(connectionString);
        //}

        public HomeController(HomeDbContextClass dbContextClass)
        {       
            dataContext=dbContextClass;
        }

        public IActionResult Index()
        {   
            return View();
        }

        [TypeFilter(typeof(StudentActionFilter))]
        [HttpPost]
        public IActionResult Index(string txtUserName,string txtPassword,string txtDesignation)
        {  
            var list=dataContext.GetCredentials();
    
                foreach (var item in list)
                {
                if (txtUserName == item.UserName && txtPassword == item.Password && txtDesignation == item.Designation)
                {
                    if (item.Designation == "Student")
                    {
                        return RedirectToAction("Index", "Student");
                    }
                    else if (item.Designation == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else 
                    {
                        return RedirectToAction("Index", "Hod");
                    }
                }
                }

            ViewBag.msg = "Login Failed";
            return View();
            }
            

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentLogin data)
        {
           bool IsInserted= dataContext.InsertData(data);

            if (IsInserted)
            {
                ViewBag.msg = "Record Inserted Successfully";
            }
            else
            {
                ViewBag.msg = "Record Not Inserted";
            }

            return View();
        }

       






    }
}
