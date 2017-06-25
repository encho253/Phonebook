using System.Data.SqlClient;

namespace Phonebook.Data
{
    public class SqlConnect
    {
        private const string ConnectionString = "Data Source=.;Initial Catalog=Phonebook;Integrated Security=True";

        private SqlConnection connection;

        public SqlConnect()
        {
            this.Connection = new SqlConnection(ConnectionString);
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
    }
}