namespace MySQLTest.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Specialty { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
    }
}
