using RestWithASPNETUdemy.Context;
using RestWithASPNETUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        
        private MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }



        public User FindbyLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }
         
  
    }
}
