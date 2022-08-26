using KNUStudySystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;

namespace KNUStudySystem.Models
{
    public abstract class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string? Department { get; set; } = null;
        public string? Faculty { get; set; } = null;
        public string? Specialty{ get; set; } = null;
        public abstract void AddInfoToDb(Database database);
        public abstract void DeleteInfoFromDb(Database database);
        public abstract void GetInfoFromDb(Database database);
    }
    public class Student : User
    {
        public int? Course { get; set; } = null;
        public int? Group { get; set; } = null;
        public int? SubGroup { get; set; } = null;
        public string? FreeGrouping { get; set; } = null;

        public override void AddInfoToDb(Database _database)
        {
            using (var connection = _database.getConnectionToDb())
            {
                connection.Open();
                _database.setCommand("INSERT INTO StudentInfo " +
                    "(UserId, UserName, Department, Faculty, Specialty, Course, Group, SubGroup, FreeGrouping) " +
                    "VALUES (@UserId, @UserName, @Department, @Faculty, @Specialty, @Course, @Group, @SubGroup, @FreeGrouping)");
                MySqlCommand command = _database.getExecutableCommand();
                MySqlParameter[] parameters = {
                    new MySqlParameter("@UserId", UserId),
                    new MySqlParameter("@UserName", UserName),
                    new MySqlParameter("@Department", Department),
                    new MySqlParameter("@Faculty", Faculty),
                    new MySqlParameter("@Specialty", Specialty),
                    new MySqlParameter("@Course", Course),
                    new MySqlParameter("@Group", Group),
                    new MySqlParameter("@SubGroup", SubGroup),
                    new MySqlParameter("@FreeGrouping", FreeGrouping)
                    
                };
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public override void DeleteInfoFromDb(Database _database)
        {
            using (var connection = _database.getConnectionToDb())
            {
                connection.Open();
                _database.setCommand("DELETE FROM StudentInfo WHERE UserId = @UserId");
                MySqlCommand command = _database.getExecutableCommand();
                command.Parameters.Add(new MySqlParameter("@UserId", UserId));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public override void GetInfoFromDb(Database _database)
        {
            using (var connection = _database.getConnectionToDb())
            {
                connection.Open();
                _database.setCommand("SELECT * FROM StudentInfo WHERE UserId = @UserId");
                MySqlCommand command = _database.getExecutableCommand();
                command.Parameters.Add(new MySqlParameter("@UserId", UserId));
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserId = Convert.ToString(reader["UserId"]);
                    UserName= Convert.ToString(reader["UserName"]);
                    Department = Convert.ToString(reader["Department"]);
                    Faculty = Convert.ToString(reader["Faculty"]);
                    Specialty = Convert.ToString(reader["Specialty"]);
                    Course = Convert.ToInt32(reader["Course"]);
                    Group = Convert.ToInt32(reader["Group"]);
                    SubGroup = Convert.ToInt32(reader["SubGroup"]);
                    FreeGrouping = Convert.ToString(reader["FreeGrouping"]);
                }
                reader.Close();
                connection.Close();
            }
        }

        internal bool isFilledHisInfo()
        {
            if (Department is null)
            {
                return false;
            }
            return true;
        }
    }
    public class Teacher : User
    {
        public override void AddInfoToDb(Database _database)
        {
            using (var connection = _database.getConnectionToDb())
            {
                connection.Open();
                _database.setCommand("INSERT INTO TeacherInfo " +
                    "(UserId, UserName, Department, Faculty, Specialty) " +
                    "VALUES (@UserId, @UserName, @Department, @Faculty, @Specialty)");
                MySqlCommand command = _database.getExecutableCommand();
                MySqlParameter[] parameters = {
                    new MySqlParameter("@UserId", UserId),
                    new MySqlParameter("@UserName", UserName),
                    new MySqlParameter("@Department", Department),
                    new MySqlParameter("@Faculty", Faculty),
                    new MySqlParameter("@Specialty", Specialty),
                };
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public override void DeleteInfoFromDb(Database _database)
        {
            using (var connection = _database.getConnectionToDb())
            {
                connection.Open();
                _database.setCommand("DELETE FROM TeacherInfo WHERE UserId = @UserId");
                MySqlCommand command = _database.getExecutableCommand();
                command.Parameters.Add(new MySqlParameter("@UserId", UserId));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public override void GetInfoFromDb(Database _database)
        {
            using (var connection = _database.getConnectionToDb())
            {
                connection.Open();
                _database.setCommand("SELECT * FROM TeacherInfo WHERE UserId = @UserId");
                MySqlCommand command = _database.getExecutableCommand();
                command.Parameters.Add(new MySqlParameter("@UserId", UserId));
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserId = Convert.ToString(reader["UserId"]);
                    UserName = Convert.ToString(reader["UserName"]);
                    Department = Convert.ToString(reader["Department"]);
                    Faculty = Convert.ToString(reader["Faculty"]);
                    Specialty = Convert.ToString(reader["Specialty"]);
                }
                reader.Close();
                connection.Close();
            }
        }

        internal bool isFilledHisInfo()
        {
            if (Department is null)
            {
                return false;
            }
            return true;
        }
    }
}
