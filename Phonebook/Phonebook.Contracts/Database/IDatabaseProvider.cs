using System.Data.SqlClient;

namespace Phonebook.Contracts.Database
{
    public interface IDatabaseProvider
    {
        SqlConnection Connection { get; set; }

        SqlCommand Command { get; set; }

        SqlDataReader ReadCommand(string commandString, string commandParameter = null);
    }
}