using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3.Models
{
    public class Book
    {
        public Book(int id, string title, int publishYear, int catalog, int author, double rate)
        {
            Id = id;
            Title = title;
            PublishYear = publishYear;
            CatalogId = catalog;
            AuthorId = author;
            Rate = rate;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int PublishYear { get; set; }
        public int CatalogId { get; set; }
        public int AuthorId { get; set; }
        public double Rate { get; set; }
    }
}
