namespace Projeto.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }

        public User()
        {

        }

        public User(int idUser, string userName, string password, DateTime registrationDate)
        {
            IdUser = idUser;
            UserName = userName;
            Password = password;
            RegistrationDate = registrationDate;
        }

        public override string ToString()
        {
            return "User: " + IdUser + ", " + UserName + ", " + RegistrationDate;
        }
    }
}
