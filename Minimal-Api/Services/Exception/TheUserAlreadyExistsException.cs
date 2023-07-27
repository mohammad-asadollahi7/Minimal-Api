namespace Minimal_Api.Services.Exception;

public class TheUserAlreadyExistsException : ApplicationException   
{
    public override string Message => "The user already exists.";
}
