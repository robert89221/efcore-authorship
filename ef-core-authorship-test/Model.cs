
using Microsoft.EntityFrameworkCore;


namespace ef_core_authorship_test
{

  internal class AuthorshipDbContext(string ConnStr = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Authorship; Integrated Security=True") : DbContext
  {
    string ConnStr { get; set; } = ConnStr;

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    override protected void OnConfiguring(DbContextOptionsBuilder opts)
    {
      opts.UseSqlServer(ConnStr);
    }

    //override protected void OnModelCreating(ModelBuilder mdl) {}
  }


  internal class Book
  {
    public int Id { get; set; }

    public string Title { get; set; }
    public string Category { get; set; }
    public int Year { get; set; }
    public int Pages { get; set; }

    //  för junction-tabellen
    public List<Author> Authors { get; set; }

    //  EF core kräver en vanlig eller primär ctor i detta formatet, med argument som har samma namn som kolumnerna i tabellen
    public Book(string Title="", string Category="", int Year=0, int Pages=0) => (this.Title, this.Category, this.Year, this.Pages, this.Authors) = (Title, Category, Year, Pages, []);

    //  övriga ctors kan läggas till för bekvämlighet
    public Book(string t, string c, int y, int p, params Author[] a) => (Title, Category, Year, Pages, Authors) = (t, c, y, p, a.ToList());

    public override string ToString()  =>  $"{Title} ({Year}), {Category}, {Pages} pages";
  }


  internal class Author
  {
    public int Id { get; set; }

    public string Name { get; set; }

    //  för junction-tabellen
    public List<Book> Books { get; set; }

    public Author(string Name = "") => (this.Name, this.Books) = (Name, []);

    public Author(string Name, params Book[] b) => (this.Name, this.Books) = (Name, b.ToList());

    public override string ToString() => Name;
  }

}
