namespace Projeto.Web.RestrictedArea.Templates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Security;

    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsario.Text = HttpContext.Current.User.Identity.Name;

            DateTime tempo = DateTime.Now;

            if (tempo.Hour > 6 && tempo.Hour < 12)
                lblSalutation.Text = "bom dia!";
            else if (tempo.Hour >= 12 && tempo.Hour < 18)
                lblSalutation.Text = "boa tarde!";
            else
                lblSalutation.Text = "boa noite!";
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/Views/Login.aspx");
        }
    }
}