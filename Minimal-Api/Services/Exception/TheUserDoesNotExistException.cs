namespace Minimal_Api.Services.Exception;

public class TheUserDoesNotExistException : ServiceException
{
    public override string Message => "The user does not exist. Please enter the current id.";
}
