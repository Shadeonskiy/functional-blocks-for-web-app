using System.ComponentModel.DataAnnotations;

namespace KNUStudySystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
    public enum UserStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
