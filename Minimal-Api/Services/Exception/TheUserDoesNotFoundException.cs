namespace Minimal_Api.Services.Exception;

public class TheUserDoesNotFoundException : ApplicationException
{
    public override string Message => "The user does not found.";
}
