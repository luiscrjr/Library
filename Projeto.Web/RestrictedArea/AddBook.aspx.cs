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

    public partial class AddBook : System.Web.UI.Page
    {
        [Import] public IBookBusiness BookBusiness { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {                                
                string NomeArq = string.Format("{0:ddMMyyyyHHmmssFFFFFFF}.jpg", DateTime.Now);                string PathBD = @"~/Imgs/" + NomeArq;                string Path = @"C:\Users\LUIS\Documents\Visual Studio 2015\Projects\aula10\Aula10b\Projeto.Web\Imgs\" + NomeArq;
                FileInput.PostedFile.SaveAs(Path);

                Book b = new Book
                {
                    BookId = 0,
                    Title = txtTitle.Text,
                    Isbn = txtIsbn.Text,
                    Gender = txtGender.Text,
                    Author = txtAuthor.Text,
                    Publishing = txtPublisher.Text,
                    Synopsis = txtSynopsis.Text,
                    Photo = PathBD
                };

                BookBusiness.Insert(b);


                txtTitle.Text = "";
                txtIsbn.Text = "";
                txtGender.Text = "";
                txtAuthor.Text="";
                txtPublisher.Text = "";
                txtSynopsis.Text = "";

                lblMensagem.Text = $"Livro {b.Title} cadastrado com sucesso.";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}