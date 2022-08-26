using System;
using MySql.Data.MySqlClient;

namespace KNUStudySystem.Models
{
    public class Database
    {
        public MySqlConnection Connection { private get; set; }
        public string Command { get; set; }
        public Database(string ConnectionString)
        {
            Connection = new MySqlConnection(ConnectionString);
        }
        public void setCommand(string command_to_execute)
        {
            Command = command_to_execute;
        }
        public MySqlConnection getConnectionToDb()
        {
            return Connection;
        }
        public MySqlCommand getExecutableCommand()
        {
            return new MySqlCommand(Command, Connection);
        }
    }
}
