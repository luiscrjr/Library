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
    using System.Web.Security;

    public partial class Login : System.Web.UI.Page
    {
        [Import] public IUserBusiness UserBusiness { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAcesso_Click(object sender, EventArgs e)
        {
            try
            {
                User u = UserBusiness.Authenticate(txtLogin.Text, txtSenha.Text);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(u.UserName, false, 5);

                HttpCookie c = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                Response.Cookies.Add(c);

                Response.Redirect("~/RestrictedArea/Default.aspx");
            }
            catch(Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}