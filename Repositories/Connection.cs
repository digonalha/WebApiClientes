using WebApiClientes.Utilities;

namespace WebApiClientes.Repositories
{
    public class Connection
    {
        const string FILE_NAME = "connection.txt";
        public static string connectionString;

        public static string getConnectionString()
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                connectionString = FileHelper.readFile(FILE_NAME)[0];

            return connectionString;
        }
    }
}
