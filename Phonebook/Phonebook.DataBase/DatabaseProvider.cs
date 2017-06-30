using System.Data;
using System.Data.SqlClient;

namespace Phonebook.Data
{
    public class DatabaseProvider
    {
        private const string ConnectionString = "Data Source=.;Initial Catalog=Phonebook;Integrated Security=True";

        private SqlConnection connection;
        private SqlCommand command;

        public DatabaseProvider()
        {
            this.Connection = new SqlConnection();
            this.Command = new SqlCommand();
        }

        public SqlConnection Connection
        {
            get
            {
                return this.connection;
            }
            private set
            {
                this.connection = value;
            }
        }

        public SqlCommand Command
        {
            get
            {
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }

        public SqlDataReader ReadCommand(string commandString)
        {           
            this.Connection.ConnectionString = ConnectionString;

            this.Command.CommandText = commandString;
            this.Command.CommandType = CommandType.StoredProcedure;
            this.Command.Connection = this.Connection;

            this.Connection.Open();          

            SqlDataReader reader = this.Command.ExecuteReader();
          
            return reader;
        }
    }
}