using Microsoft.AspNetCore.Mvc;
using KNUStudySystem.Models;
using System.Diagnostics;
using Assignment = KNUStudySystem.Models.Assignment;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace KNUStudySystem.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ILogger<AssignmentController> _logger;
        private readonly Database _database;

        public AssignmentController(ILogger<AssignmentController> logger, Database database)
        {
            _logger = logger;
            _database = database;
        }

        public IActionResult Assignment()
        {
            List<Assignment> assignments = new List<Assignment>();
            using (var connection = new MySqlConnection(_database.Connection))
            {
                connection.Open();
                _database.setCommand("SELECT * FROM tasks");
                MySqlCommand command = new MySqlCommand(_database.Command, connection);
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