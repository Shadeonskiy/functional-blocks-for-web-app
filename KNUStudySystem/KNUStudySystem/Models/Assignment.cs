using System;

namespace KNUStudySystem.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Assignment_Name { get; set; }
        public string Assignment_Description { get; set; }
        public string? File_Id { get; set; }
        public string? Subject { get; set; }
        public string Department { get; set; }
        public string Speciality { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
        public DateTime Assignment_Date { get; set; }
        public DateTime Deadline { get; set; }
    }
}
