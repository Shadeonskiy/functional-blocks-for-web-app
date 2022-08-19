using System;

namespace KNUStudySystem.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime TaskDate { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public string Teacher { get; set; }
        public DateTime EvaluationDate { get; set; }
        public status Status { get; set; }
    }
    public enum status
    {
        graded,
        not_graded,
        amogus
    }
}
