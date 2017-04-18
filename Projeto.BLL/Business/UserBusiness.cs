namespace Projeto.BLL.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;
    using DAL.Contracts;
    using BLL.Contracts;

    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateAccount(User u)
        {
            try
            {
                if(userRepository.HasUserName(u.UserName))
                {
                    throw new Exception("Erro. Este login ja encontra-se cadastrado.");
                }
                else
                {
                    userRepository.Insert(u);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public User Authenticate(string userName, string password)
        {
            try
            {
                User u = userRepository.Find(userName, password);

                if(u != null)
                {
                    return u;
                }
                else
                {
                    throw new Exception("Acesso Negado");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }        
    }
}
