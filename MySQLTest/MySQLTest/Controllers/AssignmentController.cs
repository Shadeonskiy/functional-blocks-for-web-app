using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using MySQLTest.Models;
using System.Diagnostics;
using Assignment = MySQLTest.Models.Assignment;

namespace MySQLTest.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ILogger<AssignmentController> _logger;

        public AssignmentController(ILogger<AssignmentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Assignment()
        {
            List<Assignment> assignments = new List<Assignment>();
            using (var connection = new MySqlConnection("server=s2.thehost.com.ua;user=MySQLBot;password=MySQLBot1;database=WeatherTEST"))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tasks", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Assignment assignment = new Assignment();
                    assignment.Id = Convert.ToInt32(reader["id"]);
                    assignment.Assignment_Name = Convert.ToString(reader["task_name"]);
                    assignment.Assignment_Description = Convert.ToString(reader["task_description"]);
                    assignment.File_Id = Convert.ToString(reader["file_id"]);
                    assignment.Subject = Convert.ToString(reader["subject"]);
                    assignment.Department = Convert.ToString(reader["department"]);
                    assignment.Speciality = Convert.ToString(reader["speciality"]);
                    assignment.Course = Convert.ToInt32(reader["course"]);
                    assignment.Group = Convert.ToInt32(reader["group"]);
                    assignment.Deadline = Convert.ToDateTime(reader["deadline"]);

                    assignments.Add(assignment);
                }
                reader.Close();
                connection.Close();
            }
            return View(assignments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}