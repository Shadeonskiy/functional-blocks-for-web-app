﻿using System;
using Microsoft.AspNetCore.Mvc;
using KNUStudySystem.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace KNUStudySystem.Controllers
{
    public class MarkController : Controller
    {
        private readonly ILogger<MarkController> _logger;
        private readonly Database _database;

        public MarkController(ILogger<MarkController> logger, Database database)
        {
            _logger = logger;
            _database = database;
        }

        public IActionResult Mark()
        {
            List<Mark> marks = new List<Mark>();
            using (var connection = new MySqlConnection(_database.Connection))
            {
                Console.WriteLine(_database.Connection);
                connection.Open();
<<<<<<< Updated upstream
                _database.setCommand("SELECT * FROM marks_test");
=======
                _database.setCommand("SELECT Tasks.task_id, Tasks.task_name, Tasks.subject, " +
                    "Tasks.task_type, Marks.id, Marks.comment, Marks.grade,  " +
                    "Marks.teacher, Marks.evaluation_date, Marks.status " +
                    "FROM Tasks JOIN Marks ON Tasks.task_id = Marks.task_id " +
                    "WHERE task_name LIKE \'"+filters+"%\'");
>>>>>>> Stashed changes
                using var command = new MySqlCommand(_database.Command, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Mark mark = new Mark();
                    mark.Id = Convert.ToInt32(reader["id"]);
                    mark.Type = Convert.ToString(reader["type"]);
                    mark.TaskDate = Convert.ToDateTime(reader["task_date"]);
                    mark.Name = Convert.ToString(reader["name"]);
                    mark.Grade = Convert.ToInt32(reader["grade"]);
                    mark.Teacher = Convert.ToString(reader["teacher"]);
                    mark.EvaluationDate = Convert.ToDateTime(reader["evaluation_date"]);
                    switch (reader["status"])
                    {
                        case "graded":
                            mark.Status = status.graded;
                            break;
                        case "not graded":
                            mark.Status = status.not_graded;
                            break;
                        case "amogus":
                            mark.Status = status.amogus;
                            break;
                    }
                    marks.Add(mark);
                }
                reader.Close();
                connection.Close();
            }
            return View(marks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}