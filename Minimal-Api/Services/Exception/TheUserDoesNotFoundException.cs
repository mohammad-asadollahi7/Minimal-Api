namespace Minimal_Api.Services.Exception;

public class TheUserDoesNotFoundException : ServiceException
{
    public override string Message => "The user does not found.";
}
