namespace Jobs.Models
{
    public class Users
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Email { get; set; }
        public String? Experience { get; set; }
        public int JobID { get; set; }

        public Jobs? Jobs { get; set;}
    }
}
