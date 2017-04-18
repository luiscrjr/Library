namespace Projeto.DAL.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;

    public interface IUserRepository
    {
        void Insert(User u);

        bool HasUserName(string userName);

        User Find(string userName, string password);
    }
}
