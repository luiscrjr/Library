namespace Projeto.Web.RestrictedArea
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.ComponentModel.Composition;
    using BLL.Contracts;
    using Entities;
    using System.Data;
    using System.Web.Services;

    public partial class ModifyBook : System.Web.UI.Page
    {
        [Import] public IBookBusiness BookBusiness { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //resgatando o id enviado pela URL
                    int idBook = int.Parse(Request.QueryString["id"]);

                    Book b = BookBusiness.FindById(idBook);

                    txtBookId.Text = b.BookId.ToString();
                    txtTitle.Text = b.Title;
                    txtIsbn.Text = b.Isbn.ToString();
                    txtGender.Text = b.Gender.ToString();
                    txtAuthor.Text = b.Author.ToString();
                    txtPublisher.Text = b.Publishing.ToString();
                    txtSynopsis.Text = b.Synopsis.ToString();
                    Image1.ImageUrl = b.Photo.ToString() ;

                }
                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message;
                }
            }
        }
                
        protected void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                string NomeArq = string.Format("{0:ddMMyyyyHHmmssFFFFFFF}.jpg", DateTime.Now);                string PathBD = @"~/Imgs/" + NomeArq;                string Path = @"C:\Users\LUIS\Documents\Visual Studio 2015\Projects\aula10\Aula10b\Projeto.Web\Imgs\" + NomeArq;
                FileInput.PostedFile.SaveAs(Path);

                Book b = new Book
                {
                    BookId = int.Parse(txtBookId.Text),
                    Title = txtTitle.Text,
                    Isbn = txtIsbn.Text,
                    Gender = txtGender.Text,
                    Author = txtAuthor.Text,
                    Publishing = txtPublisher.Text,
                    Synopsis = txtSynopsis.Text,
                    Photo = PathBD
                };

                BookBusiness.Update(b);

                lblMsg.Text = "Livro atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
    }
}