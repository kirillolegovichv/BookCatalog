namespace BookCatalog.M;

public class AuthorDto
{
    public int Id { get; set; }

    public string Surname { get; set; }

    public string Name { get; set; }

    public string Patronimic { get; set; }

    public bool IsDeleted { get; set; }

    public AuthorDto()
    {

    }
}
