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

            connection.QuerySingle<AuthorDto>
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

    public List<AuthorDto> GetAllAuthors()
    {
        using(var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            return connection.Query<AuthorDto>
                (StoredProcedure.Author_GetAll,
                commandType: System.Data.CommandType.StoredProcedure
                ).ToList();
        }
    }

    public AuthorDto GetAuthorById(int id)
    {
        using(var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            return connection.QuerySingle<AuthorDto>
                (StoredProcedure.Author_GetById,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure                
                );
        }
    }

    public void DeleteAuthor(int id)
    {
        using(var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.QuerySingleOrDefault<AuthorDto>
                (StoredProcedure.Author_SoftDelete,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }


}
