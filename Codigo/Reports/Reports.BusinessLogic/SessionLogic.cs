using System;
using System.Collections.Generic;
using System.Linq;
using Reports.BusinessLogic.Interface;
using Reports.DataAccess.Interface;
using Reports.Logger.Interface;
using Reports.Domain;
using Reports.Logger.Domain;

namespace Reports.BusinessLogic
{
    public class SessionLogic : ISessionLogic
    {
        private IRepository<User> repository;
        private ILoggerLogic logRepository;

        private static IDictionary<string, Guid?> TokenRepository = null;

        public SessionLogic(IRepository<User> repository, ILoggerLogic logRepository)
        {
            this.repository = repository;
            this.logRepository = logRepository;
            if (TokenRepository == null)
            {
                TokenRepository = new Dictionary<string, Guid?>();
            }
        }

        public bool IsValidToken(string token)
        {
            return TokenRepository.ContainsKey(token);
        }

        public Guid? CreateToken(string userName, string password)
        {
            var users = repository.GetAll();
            var user = users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            if (user == null)
            {
                return null;
            }
            var token = Guid.NewGuid();
            TokenRepository.Add(token.ToString(), user.Id);
            return token;
        }

        public bool HasLevel(string token, string role)
        {
            var user = GetUser(token);
            if (user == null)
            {
                return false;
            }
            if (role == "Admin")
            {
                return user.Admin;
            }
            return true;
        }

        public User GetUser(string token)
        {
            Guid? userId = null;
            if (TokenRepository.TryGetValue(token, out userId))
            {
                return repository.Get(userId.GetValueOrDefault());
            }
            return null;
        }

    }
}
