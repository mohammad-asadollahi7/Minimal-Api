namespace Minimal_Api.Services.Exception;

public class TheUserAlreadyExistsException : ServiceException   
{
    public override string Message => "The user already exists.";
}
