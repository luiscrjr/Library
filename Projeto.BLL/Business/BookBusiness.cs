namespace Projeto.BLL.Business
{
    using System;
    using System.Collections.Generic;
    using Entities;
    using DAL.Contracts;
    using BLL.Contracts;

    public class BookBusiness : IBookBusiness
    {

        private readonly IBookRepository bookRepository;

        public BookBusiness(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void Insert(Book b)
        {
            try
            {
                bookRepository.Insert(b);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                bookRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Book> ListByName(string title)
        {
            try
            {
                return bookRepository.ListByName(title);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
                
        public void Update(Book b)
        {
            try
            {
                bookRepository.Update(b);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Book FindById(int id)
        {
            try
            {
                return bookRepository.FindById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
