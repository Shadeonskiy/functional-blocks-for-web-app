using System;
using MySql.Data.MySqlClient;

namespace KNUStudySystem.Models
{
    public class Database
    {
        public string Connection { get; set; }
        public string Command { get; set; }
        public Database(string ConnectionString)
        {
            Connection = ConnectionString;
        }
        public Database(string connection_address, string command_to_execute)
        {
            Connection = connection_address;
            Command = command_to_execute;
        }
        public void setCommand(string command_to_execute)
        {
            Command = command_to_execute;
        }
    }
}
