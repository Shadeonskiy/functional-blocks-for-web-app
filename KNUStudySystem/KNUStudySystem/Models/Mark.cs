using System;

namespace KNUStudySystem.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }
        public int Grade { get; set; }
        public string Teacher { get; set; }
        public DateTime EvaluationDate { get; set; }
        public status Status { get; set; }
    }
    public enum status
    {
        completed,
        not_graded,
        failed
    }
}
