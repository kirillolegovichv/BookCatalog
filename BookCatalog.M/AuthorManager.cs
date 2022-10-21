using System.Data.SqlClient;
using Dapper;

namespace BookCatalog.M;

public class AuthorManager
{
    public string connectionString = ServerOption.ConnectionOption;

    public void AddAuthor(AuthorDto author)
    {
        using(var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.QuerySingle
                (StoredProcedure.Author_Add,
                param: new
                {
                    Surname = author.Surname,
                    Name = author.Name,
                    Patronimic = author.Patronimic
                },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }
}
