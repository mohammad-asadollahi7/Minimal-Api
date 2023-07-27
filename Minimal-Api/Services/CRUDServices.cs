using Minimal_Api.Data;
using Minimal_Api.Model;
using Minimal_Api.Services.Exception;
using System.Collections.Generic;

namespace Minimal_Api.Services;

public class CRUDServices
{
    private readonly UserData _userData;

    public CRUDServices(UserData userData)
    {
        _userData = userData;
    }
    public List<User>? GetAll()
    {
        var users =  _userData.users;
        if (users == null)
            throw new TheUserListIsEmptyException();

        return users;
    }

    public User GetById(int id)
    {
        var user = _userData.users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            throw new TheUserDoesNotExistException();

        return user;
    }
    public void Create(User user)
    {
       var isExist = _userData.users.Any(u => u.Id == user.Id || u.Email == user.Email);
        if (isExist)
            throw new TheUserAlreadyExistsException();
       
        _userData.users.Add(user);
        _userData.Savechanges();
    }

    public void Update(User updatedUser)
    {
        var oldUser = _userData.users.FirstOrDefault(u => u.Id == updatedUser.Id);
        var userIndex = _userData.users.IndexOf(oldUser);
        _userData.users[userIndex] = updatedUser;
        _userData.Savechanges();
    }


    public void Delete(int id)
    {
        var user = _userData.users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            throw new TheUserDoesNotFoundException();

        _userData.users.Remove(user);
        _userData.Savechanges();
    }
}
