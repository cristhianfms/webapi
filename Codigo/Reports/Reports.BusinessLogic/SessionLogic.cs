using System.Collections.Generic;
using Reports.BusinessLogic.Interface;
using Reports.Domain;
using Reports.DataAccess.Interface;
using System;
using System.Linq;

public class SessionLogic : ISessionLogic
{
    private IRepository<Session> repository;

    // TENDRÍA QUE SER UN SESSION REPOSITORY
    // SESSION = {
    //      token: Guid,  
    //      user: User
    // }
    // CUIDADO CON LAS VARIABLES ESTÁTICAS EN LA BUISSNESSLOGIC
    private static IDictionary<string, Guid?> TokenRepository = null;
    public SessionLogic(IRepository<Session> repository) {
        this.repository = repository;
        if (TokenRepository == null) {
            TokenRepository = new Dictionary<string, Guid?>();
        }
    }
    public bool IsValidToken(string token)
    {
        // SI EL TOKEN EXISTE EN BD RETORNA TRUE
        return TokenRepository.ContainsKey(token);
    }
    public Guid? CreateToken(string userName, string password)
    {
        // SI EL USUARIO EXISTE Y LA PASS Y EL USERNAME SON EL MISMO
        // RETORNAR GUID
        var users = repository.GetAll();
        var user = users.FirstOrDefault(x => x.User.UserName == userName && x.User.Password == password);
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
        if (user == null) {
            return false;
        }
        if (role == "Admin") {
            return user.User.Admin;
        }
        return true;
    }
    public Session GetUser(string token) 
    {
        Guid? userId = null;
        if (TokenRepository.TryGetValue(token, out userId)) 
        {
            return repository.Get(userId.GetValueOrDefault());
        }
        return null;
    }
}