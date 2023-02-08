using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Jobs.Models
{
    public class Job
    {
        public int ID { get; set; }
        public String? Title { get; set; } //'?' after string indicates that the table column can take in nullable values
        public String? Description { get; set; }
        public String? Category { get; set; }
        //Adding the company ID from companies table as a Foreign Key
        public int CompanyID { get; set; }
       
        public Company? Company { get; set; }

    }
}
