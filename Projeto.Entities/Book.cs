namespace Projeto.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Gender { get; set; }
        public string Author { get; set; }
        public string Publishing { get; set; }
        public string Synopsis { get; set; }
        public string Photo { get; set; }
        
        public Book()
        {

        }

        public Book(int bookId, string title, string isbn, string gender, string author, string publishing, string synopsis, string photo)
        {
            BookId = bookId;
            Title = title;
            Isbn = isbn;
            Gender = gender;
            Author = author;
            Publishing = publishing;
            Synopsis = synopsis;
            Photo = photo;
        }


    }

}
