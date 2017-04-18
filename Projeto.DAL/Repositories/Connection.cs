namespace Projeto.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Configuration;

    public class Connection
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;

        protected void OpenConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["aula"].ConnectionString);
            con.Open();
        }

        protected void CloseConnection()
        {
            if (con != null)
                con.Close();            
        }
    }
}
