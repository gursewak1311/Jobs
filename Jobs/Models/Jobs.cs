using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Jobs.Models
{
    public class Jobs
    {
        public int ID { get; set; }
        public String? Title { get; set; } //'?' after string indicates that the table column can take in nullable values
        public String? Description { get; set; }
        public String? Category { get; set; }
        public int CompanyID { get; set; }
       
        public Company? Company { get; set; }

    }
}
