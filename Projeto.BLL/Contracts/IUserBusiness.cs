namespace Projeto.BLL.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;

    public interface IUserBusiness
    {
        void CreateAccount(User u);

        User Authenticate(string userName, string password);
    }
}
