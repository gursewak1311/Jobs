namespace Jobs.Models
{
    public class Users
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Email { get; set; }
        public String? Experience { get; set; }
        //Adding Job ID from Jobs as a FK
        public int JobID { get; set; }

        public Job? Jobs { get; set;}
    }
}
