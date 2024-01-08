
using ef_core_authorship_test;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;


var db = new AuthorshipDbContext();

DeleteAll();
AddEntries();






void ListAll()
{

}


void DeleteAll()
{
  db.Books.ExecuteDelete();
  db.Authors.ExecuteDelete();
}


void AddEntries()
{
  db.Books.Add(new Book("boken", "skönlit", 2001, 55, "auth 1", "auth2", "auth3"));
  db.SaveChanges();

}
