namespace Projeto.BLL.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;

    public interface IBookBusiness
    {
        List<Book> ListByName(string title);
        Book FindById(int id);
        void Update(Book b);
        void Delete(int id);
        void Insert(Book b);
    }
}
