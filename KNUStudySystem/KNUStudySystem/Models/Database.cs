using System;
using MySql.Data.MySqlClient;

namespace KNUStudySystem.Models
{
    public class Database
    {
        public string Connection { private get; set; }
        public string Command { get; set; }
        public Database(string ConnectionString)
        {
            Connection = ConnectionString;
        }
        public void setCommand(string command_to_execute)
        {
            Command = command_to_execute;
        }
        public MySqlConnection getConnectionToDb()
        {
            return new MySqlConnection(Connection);
        }
        public MySqlCommand getExecutableCommand(MySqlConnection connection)
        {
            return new MySqlCommand(Command, connection);
        }
    }
}
