namespace Projeto.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using Entities;
    using Contracts;

    public class BookRepository : Connection, IBookRepository
    {

        public void Insert(Book b)
        {
            try
            {
                OpenConnection();

                string query = "INSERT INTO BOOKS (TITLE, ISBN, GENDER, "
                    + "AUTHOR, PUBLISHER, SYNOPSIS, PHOTO) VALUES "
                    + "(@TITLE, @ISBN, @GENDER, @AUTHOR, @PUBLISHING, "
                    + "@SYNOPSIS, @PHOTO)";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TITLE", b.Title);
                cmd.Parameters.AddWithValue("@ISBN", b.Isbn);
                cmd.Parameters.AddWithValue("@GENDER", b.Gender);
                cmd.Parameters.AddWithValue("@AUTHOR", b.Author);
                cmd.Parameters.AddWithValue("@PUBLISHING", b.Publishing);
                cmd.Parameters.AddWithValue("@SYNOPSIS", b.Synopsis);
                cmd.Parameters.AddWithValue("@PHOTO", b.Photo);
                
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(Book b)
        {
            try
            {
                OpenConnection();

                string query = "UPDATE BOOKS SET TITLE = @TITLE, ISBN = @ISBN, "
                    + "GENDER = @GENDER, AUTHOR = @AUTHOR, PUBLISHER = @PUBLISHING, "
                    + "SYNOPSIS = @SYNOPSIS, PHOTO = @PHOTO WHERE BOOKID = @BOOKID";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BOOKID", b.BookId);
                cmd.Parameters.AddWithValue("@TITLE", b.Title);
                cmd.Parameters.AddWithValue("@ISBN", b.Isbn);
                cmd.Parameters.AddWithValue("@GENDER", b.Gender);
                cmd.Parameters.AddWithValue("@AUTHOR", b.Author);
                cmd.Parameters.AddWithValue("@PUBLISHING", b.Publishing);
                cmd.Parameters.AddWithValue("@SYNOPSIS", b.Synopsis);
                cmd.Parameters.AddWithValue("@PHOTO", b.Photo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Livro: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Delete(int id)
        {
            try
            {
                OpenConnection();

                string query = "DELETE FROM BOOKS WHERE BOOKID = @BOOKID";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BOOKID", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir livro" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Book> ListByName(string title)
        {
            try
            {
                OpenConnection();
                //comando SQL..

                string query = "SELECT * FROM BOOKS WHERE TITLE LIKE @Title";

                //executando a query..
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title",'%' + title + '%');
                dr = cmd.ExecuteReader();
                

                List<Book> lista = new List<Book>(); //vazia..

                if (dr.Read())
                {
                    while (dr.Read()) //lendo cada registro da query..
                    {
                        Book b = new Book(); //instanciando..
                        b.BookId = (int)dr["BOOKID"];
                        b.Title = (string)dr["TITLE"];
                        b.Isbn = (string)dr["ISBN"];
                        b.Gender = (string)dr["GENDER"];
                        b.Author = (string)dr["AUTHOR"];
                        b.Publishing = (string)dr["PUBLISHER"];
                        b.Synopsis = (string)dr["SYNOPSIS"];
                        b.Photo = (string)dr["PHOTO"];

                        lista.Add(b); //adicionar na lista...
                    }
                    return lista;
                }
                else
                {
                    throw new Exception("Nenhum livro encontrado.");
                }

            }
            catch (SqlException e)
            {
                //retornar o erro..
                throw new Exception("Erro ao listar Livros: " + e.Message);
            }
            finally //finalizador..
            {
                CloseConnection();
            }
        }

        public Book FindById(int id)
        {
            try
            {
                OpenConnection();
                string query = "SELECT * FROM BOOKS WHERE BOOKID = @BookId";
                 cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BookId", id);
                dr = cmd.ExecuteReader();
                Book b = null;

                if (dr.Read())
                {
                    b = new Book();
                    b.BookId = (int)dr["BOOKID"];
                    b.Title = (string)dr["TITLE"];
                    b.Isbn = (string)dr["ISBN"];
                    b.Gender = (string)dr["GENDER"];
                    b.Author = (string)dr["AUTHOR"];
                    b.Publishing = (string)dr["PUBLISHER"];
                    b.Synopsis = (string)dr["SYNOPSIS"];
                    b.Photo = (string)dr["PHOTO"];

                }
                return b;
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao obter livro: " + e.Message);
            }
            finally
            {
                CloseConnection();
            }

        }

    }
}

