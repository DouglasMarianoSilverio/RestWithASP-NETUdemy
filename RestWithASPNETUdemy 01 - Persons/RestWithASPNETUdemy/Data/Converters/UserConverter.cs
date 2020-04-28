using RestWithASPNETUdemy.Data.Converter;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Data.Converters
{
    public class UserConverter : IParser<User, UserVO>, IParser<UserVO, User>
    {
        public User Parse(UserVO origin)
        {
            return new User
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public UserVO Parse(User origin)
        {
            return new UserVO
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public IList<User> ParseList(IList<UserVO> origin)
        {
            throw new NotImplementedException();
        }

        public IList<UserVO> ParseList(IList<User> origin)
        {
            throw new NotImplementedException();
        }
    }
}
