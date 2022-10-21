using Dapper;
using System.Data.SqlClient;

namespace BookCatalog.M;

public class BookManager
{
    public string connectionString = ServerOption.ConnectionOption;

    public void AddBook(BookDto book)
    {
        using(var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.QuerySingle<string>
                (StoredProcedure.Book_Add,
                param: new
                {
                    Title = book.Title,
                    AutherId = book.AuthorId,
                    YearOfPublishing = book.YearOfPublishing,
                    ISBN = book.ISBN,
                    Description = book.Description,
                    Image = book.Image
                },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }

    public List<BookDto> GetAllBooks()
    {
        using(var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            return connection.Query<BookDto>
                (StoredProcedure.Book_GetAll,
                commandType: System.Data.CommandType.StoredProcedure
                ).ToList();
        }
    }

    public BookDto GetBookById(int id)
    {
        using(var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            return connection.QuerySingle<BookDto>
                (StoredProcedure.Book_GetById,
                param: new {id = id},
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }

    public void DeleteBook(int id)
    {
        using(var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.QuerySingleOrDefault<BookDto>
                (StoredProcedure.Book_SoftDelete,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }

    public void UpdateBook(BookDto book)
    {
        using(var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.QuerySingleOrDefault<BookDto>
                (StoredProcedure.Book_Update,
                param: new
                {
                    Title = book.Title,
                    AutherId = book.AuthorId,
                    YearOfPublishing = book.YearOfPublishing,
                    ISBN = book.ISBN,
                    Description = book.Description,
                    Image = book.Image
                },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }
}
