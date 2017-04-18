namespace Projeto.Web.Views
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

    public partial class CreateUser : System.Web.UI.Page
    {
        [Import] public IUserBusiness UserBusiness { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAcesso_Click(object sender, EventArgs e)
        {
            try
            {
                User u = new User
                {
                    UserName = txtLogin.Text,
                    Password = txtSenha.Text
                };

                UserBusiness.CreateAccount(u);

                lblMensagem.Text = $"Usuario {u.UserName}, cadastrado com sucesso.";
            }
            catch(Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}