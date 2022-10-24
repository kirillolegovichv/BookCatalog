using BookCatalog.VM.Models;
using BookCatalog.M;

namespace BookCatalog.VM;

public class DataStorage
{
    public List<BookModel> Books { get; set; }
    public List<AuthorModel> Authors { get; set; }

    private static DataStorage _instance;

    private BookManager bookManager = new BookManager();
    private AuthorManager authorManager = new AuthorManager();


}
