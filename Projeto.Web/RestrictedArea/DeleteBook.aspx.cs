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

    public partial class DeleteBook : System.Web.UI.Page
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
                    
                    lblBookId.Text = b.BookId.ToString();
                    lblTitle.Text = b.Title;
                    lblIsbn.Text = b.Isbn.ToString();
                    lblGender.Text = b.Gender.ToString();
                    lblAuthor.Text = b.Author.ToString();
                    lblPublishing.Text = b.Publishing.ToString();


                }
                catch (Exception ex)
                {
                    lblMensagem.Text = ex.Message;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int idBook = int.Parse(lblBookId.Text);

                BookBusiness.Delete(idBook);

                btnDelete.Enabled = false;

                lblMensagem.Text = "Livro excluído com sucesso.";
            }
            catch(Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}