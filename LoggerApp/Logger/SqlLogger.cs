using System.Configuration;
using System.Data.SqlClient;

namespace LoggerApp.Logger
{
    public class SqlLogger: ILog
    {
        public void Log(string message, LogLevel level)
        {
            var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            connection.Open();

            var command = new SqlCommand("Insert into Log Values('" + message + "', " + (int)level + ")");
            command.ExecuteNonQuery();
        }
    }
}
