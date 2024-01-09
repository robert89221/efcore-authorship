
using ef_core_authorship_test;
using Microsoft.EntityFrameworkCore;


var db = new AuthorshipDbContext();

//DeleteAll();
//AddEntries();

ListAll();




void ListAll()
{
  Console.WriteLine("Authors:");
  foreach (var auth in db.Authors.Include("Books"))    Console.WriteLine($"  {auth}, {auth.Books.Count} titles");
  Console.WriteLine();

  Console.WriteLine("Books:");
  foreach (var book in db.Books.Include("Authors"))
  {
    var auths = String.Join(", ", book.Authors);
    Console.WriteLine($"  {book}, ({auths})");
  }
}

void DeleteAll()
{
  db.Books.ExecuteDelete();
  db.Authors.ExecuteDelete();
}


void AddEntries()
{
  db.Books.Add(new Book("A Horse's Tale", "Novel", 1907, 153, new Author("Mark Twain")));
  db.Books.Add(new Book("The Hidden Child", "Novel", 2011, 400, new Author("Camilla Läckberg")));
  db.Books.Add(new Book("Parting Breath", "Novel", 1977, 200, new Author("Catherine Aird")));
  db.Books.Add(new Book("The Day Will Come", "Novel", 2007, 250, new Author("Judy Clemens")));

  var steve = new Author("Steve McConnell");
  db.Authors.Add(steve);
  db.Books.Add(new Book("Professional Software Development", "Software", 2003, 272, steve));
  db.Books.Add(new Book("Code Complete", "Software", 2004, 952, steve));
  db.Books.Add(new Book("Rapid Development", "Software", 1996, 672, steve));

  var john = new Author("John Ousterhout");
  var ken = new Author("Ken Jones");
  db.Authors.Add(john);
  db.Authors.Add(ken);
  db.Books.Add(new Book("Philosophy of Software Design", "Software", 2021, 196, john));
  db.Books.Add(new Book("TCL and the TK Toolkit", "Software", 2009, 816, john, ken));

  var titus = new Author("Titus Winters");
  var tom = new Author("Tom Manshreck");
  var hyrum = new Author("Hyrum Wright");
  db.Authors.Add(titus);
  db.Authors.Add(tom);
  db.Authors.Add(hyrum);
  db.Books.Add(new Book("Software Engineering at Google", "Software", 2020, 599, titus, tom, hyrum));

  db.SaveChanges();
}
