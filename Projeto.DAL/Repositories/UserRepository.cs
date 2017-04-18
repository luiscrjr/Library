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

    public class UserRepository : Connection, IUserRepository
    {
        public void Insert(User u)
        {
            try
            {
                OpenConnection();

                string query = "INSERT INTO [USER](USERNAME, [PASSWORD], REGISTRATIONDATE) "
                             + "VALUES(@USERNAME, @PASSWORD, GETDATE())";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@USERNAME", u.UserName);
                cmd.Parameters.AddWithValue("@PASSWORD", u.Password);
                cmd.ExecuteNonQuery();
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool HasUserName(string userName)
        {
            try
            {
                OpenConnection();

                string query = "SELECT COUNT(USERNAME) FROM [USER] "
                             + "WHERE USERNAME = @USERNAME";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@USERNAME", userName);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public User Find(string userName, string password)
        {
            try
            {
                OpenConnection();

                string query = "SELECT * FROM [USER] "
                             + "WHERE USERNAME = @USERNAME "
                             + "AND PASSWORD = @PASSWORD";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@USERNAME", userName);
                cmd.Parameters.AddWithValue("@PASSWORD", password);
                dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    User u = new User();
                    u.IdUser = (int) dr["IDUSER"];
                    u.UserName = (string) dr["USERNAME"];
                    u.Password = (string) dr["PASSWORD"];
                    u.RegistrationDate = (DateTime) dr["REGISTRATIONDATE"];

                    return u;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }  
    }
}
