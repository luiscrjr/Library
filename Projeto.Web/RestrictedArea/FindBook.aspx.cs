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

    public partial class FindBook : System.Web.UI.Page
    {
        [Import] public IBookBusiness BookBusiness { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {           

        }

        protected void btnFind_Click(object sender, EventArgs e)
        {   
                try
                {
                    string title = txtFindBooks.Text;

                    List<Book> lista = BookBusiness.ListByName(title);
                                    
                    lblMensagem.Text = $"Esta busca obteve {lista.Count} livro(s).";
                
                    gridBooks.DataSource = lista; 
                    gridBooks.DataBind(); 
                }
                catch (Exception ex)
                {
                    lblMensagem.Text = ex.Message;
                }
        }
    }
}