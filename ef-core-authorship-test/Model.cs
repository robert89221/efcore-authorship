
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


  internal class Book(string Title, string Category, int Year, int Pages)
  {
    public int Id { get; set; }

    public string Title { get; set; } = Title;
    public string Category { get; set; } = Category;
    public int Year { get; set; } = Year;
    public int Pages { get; set; } = Pages;

    public List<Author> Authors { get; set; } = [];

    public override string ToString()  =>  $"{Title} ({Year}), {Category}, {Pages} pages";
  }


  internal class Author(string Name)
  {
    public int Id { get; set; }

    public string Name { get; set; } = Name;

    public List<Book> Books { get; set; } = [];
  }

}
