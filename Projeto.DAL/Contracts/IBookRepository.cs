namespace Projeto.DAL.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;

    public interface IBookRepository
    {
        void Insert(Book b);

        void Update(Book b);

        List<Book> ListByName(string title);

        Book FindById(int id);

        void Delete(int id);
    }
}
