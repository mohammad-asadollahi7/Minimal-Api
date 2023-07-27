using Minimal_Api.Data;
using Minimal_Api.Model;
using Minimal_Api.Services.Exception;

namespace Minimal_Api.Services;

public interface ICRUDServices
{
    public List<User>? GetAll();
    public User GetById(int id);
    public void Create(User user);
    public void Update(User updatedUser);
    public void Delete(int id);
}
