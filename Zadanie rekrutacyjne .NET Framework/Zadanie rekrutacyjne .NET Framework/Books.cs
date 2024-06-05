using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_rekrutacyjne.NET_Framework
{
    //Class book for easier working with the list
    public class Book
    {
        public int id;
        public string title;
        public string author;
        public DateTime releaseDate;
        public string isbn;

        public Book(int id, string title, string author, DateTime releaseDate, string isbn)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.releaseDate = releaseDate;
            this.isbn = isbn;
        }

        //In case of printing list of books
        public override string ToString()
        {
            return $"ID:{id}, Title:{title}, Author:{author}, Release date:{releaseDate.ToString("dd.MM.yyyy")} ,ISBN:{isbn}";
        }
    }
}
