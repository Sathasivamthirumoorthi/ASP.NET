namespace aspnet.Models.Domain{

    public class Employee{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
        public string Department { get; set; }
        public DateTime DataOfBirth {get; set;}
    }

}