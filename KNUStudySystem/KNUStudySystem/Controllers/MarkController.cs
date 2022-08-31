using System;
using Microsoft.AspNetCore.Mvc;
using KNUStudySystem.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using KNUStudySystem.ViewModels;

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

        private List<Mark> ParseDB(string filters)
        {
            List<Mark> marks = new List<Mark>();
            using (var connection = _database.getConnectionToDb())
            {
                connection.Open();
                _database.setCommand("SELECT Tasks.task_id, Tasks.task_name, Tasks.subject, " +
                    "Tasks.task_type, Marks.id, Marks.comment, Marks.grade,  " +
                    "Marks.teacher, Marks.evaluation_date, Marks.status " +
                    "FROM Tasks JOIN Marks ON Tasks.task_id = Marks.task_id " +
                    "WHERE task_name LIKE \'" + filters + "%\'");
                using var command = _database.getExecutableCommand(connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Mark mark = new Mark();
                    mark.Id = Convert.ToInt32(reader["id"]);
                    mark.TaskId = Convert.ToInt32(reader["task_id"]);
                    mark.TaskName = Convert.ToString(reader["task_name"]);
                    mark.TaskType = Convert.ToString(reader["task_type"]);
                    mark.Comment = Convert.ToString(reader["comment"]);
                    mark.Subject = Convert.ToString(reader["subject"]);
                    mark.Grade = Convert.ToInt32(reader["grade"]);
                    mark.Teacher = Convert.ToString(reader["teacher"]);
                    mark.EvaluationDate = Convert.ToDateTime(reader["evaluation_date"]);
                    switch (reader["status"])
                    {
                        case "COMPLETED":
                            mark.Status = status.completed;
                            break;
                        case "FAILED":
                            mark.Status = status.failed;
                            break;
                    }
                    marks.Add(mark);
                }
                reader.Close();
                connection.Close();
            }
            return marks;
        }

        public IActionResult Mark(bool ascending, string sortBy, /*List<Filter> filters*/string filters)
        {
            MarkFilteredViewModel MarksView = new MarkFilteredViewModel();

            MarksView.Ascending = ascending;
            if (sortBy == null)
                sortBy = "Evaluation Date";
            MarksView.SortBy = sortBy;
            //MarksView.Filters = filters;
            MarksView.Marks = ParseDB(filters);
            if (sortBy == "Evaluation Date")
                MarksView.Marks = MarksView.Marks.OrderBy(o => o.EvaluationDate).ToList();
            else if (sortBy == "Name")
                MarksView.Marks = MarksView.Marks.OrderBy(o => o.TaskName).ToList();
            else if (sortBy == "Grade")
                MarksView.Marks = MarksView.Marks.OrderBy(o => o.Grade).ToList();
            if (!ascending)
                MarksView.Marks.Reverse();
            return View(MarksView);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}