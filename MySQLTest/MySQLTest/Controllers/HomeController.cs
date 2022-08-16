using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using MySQLTest.Models;
using System.Diagnostics;

namespace MySQLTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<User> users = new List<User>();
            using (var connection = new MySqlConnection("server=s2.thehost.com.ua;user=MySQLBot;password=MySQLBot1;database=WeatherTEST"))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM student_data", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    string[] fullname = Convert.ToString(reader["PIB"]).Split(' ');  
                    user.Id = Convert.ToInt32(reader["id"]);
                    user.UserId = Convert.ToInt32(reader["user_id"]);
                    user.LastName = fullname[0];
                    if(fullname.Length > 1)
                    {
                        user.FirstName = fullname[1];
                        if(fullname.Length > 2)
                        {
                            user.MiddleName = fullname[2];
                        }
                    }
                    user.Specialty = Convert.ToString(reader["sp"]);
                    user.Course = Convert.ToInt32(reader["course"]);
                    user.Group = Convert.ToInt32(reader["main_group"]);
                    users.Add(user);
                }
                reader.Close();
                connection.Close();
            }
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}