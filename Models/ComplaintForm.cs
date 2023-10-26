using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeGrievanceCell.Models
{
    public class ComplaintForm
    {       
        public int ComplaintId { get; set; }
        public string? ComplaintType { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfComplaint { get; set;}
        public string? Status { get; set; }
        public string? UpdateStatus { get; set; }
       

       
    }
}
