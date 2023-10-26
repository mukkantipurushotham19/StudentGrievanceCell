using Microsoft.AspNetCore.Mvc.Filters;

namespace CollegeGrievanceCell.Filters.ActionFilters
{
    public class StudentActionFilter : IActionFilter
    {

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\Purushotham.M\\.Net_Files\\Dot Net 7.0\\Visual Studio Files\\4_ASP.NET CORE_MVC\\Projects\\CollegeGrievanceCell\\FilterFile.txt", true);
            sw.WriteLine("Before Index method Executing " + DateTime.Now.ToString());
            sw.WriteLine("-----------------");
            sw.Close();
        }
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\Purushotham.M\\.Net_Files\\Dot Net 7.0\\Visual Studio Files\\4_ASP.NET CORE_MVC\\Projects\\CollegeGrievanceCell\\FilterFile.txt", true);
            sw.WriteLine("After Index method Executed " + DateTime.Now.ToString());
            sw.WriteLine("-----------------");
            sw.Close();
        }




        
    }
}
