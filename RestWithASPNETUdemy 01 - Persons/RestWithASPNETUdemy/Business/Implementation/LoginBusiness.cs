using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Security.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace RestWithASPNETUdemy.Business.Implementation
{
    public class LoginBusiness : ILoginBusiness
    {
        
        private IUserRepository _repository;
        private SigningConfigurations _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;
        
        

        public LoginBusiness(IUserRepository repository, SigningConfigurations signingConfiguration, TokenConfiguration tokenConfiguration)
        {
            _repository = repository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
            
        }

        public object FindByLogin(UserVO user)
        {
            bool credentialIsValid = false;
            if (user != null && !string.IsNullOrEmpty(user.Login))
            {
                var baseUser = _repository.FindbyLogin(user.Login);
                credentialIsValid = (baseUser != null && baseUser.Login == user.Login && baseUser.AccessKey == user.AccessKey);
            }
            if (credentialIsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Login, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName,user.Login)
                    }
                    );
                DateTime createdDate = DateTime.Now;
                DateTime expirationDate = createdDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);
                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createdDate, expirationDate, handler);

                return SuccessObject(createdDate,expirationDate,token);
            }
            else
                return ExceptionObject();
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createdDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor()
            {
               Issuer = _tokenConfiguration.Issuer,
               Audience = _tokenConfiguration.Audience,
               SigningCredentials = _signingConfiguration.SigningCredentials,
               Subject = identity,
               NotBefore = createdDate,
               Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;

        }

        private object ExceptionObject()
        {
            return new
            {
                autenticathed = false,                
                message = "Failed to authenticate"
            };
        }

        private object SuccessObject(DateTime createdDate, DateTime expirationDate,string token)
        {
            return new
            {
                autenticathed = true,
                created = createdDate.ToString("yyy-MM-dd HH:mm:ss"),
                expirationDate = expirationDate.ToString("yyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}
