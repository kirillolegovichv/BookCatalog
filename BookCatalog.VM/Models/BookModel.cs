using System.Drawing;

namespace BookCatalog.VM.Models;

public class BookModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int AuthorId { get; set; }

    public int YearOfPublishing { get; set; }

    public int ISBN { get; set; }

    public string Description { get; set; }

    public Bitmap Image { get; set; }

    public BookModel()
    {

    }
}
