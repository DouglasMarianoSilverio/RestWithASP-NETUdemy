using RestWithASPNETUdemy.Models;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IUserRepository
    {
 
        User FindbyLogin(string login);
       
    }
}
