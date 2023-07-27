namespace Minimal_Api.Services.Exception;

public class TheUserListIsEmptyException : ApplicationException
{
    public override string Message => "The user list is empty. Please add some data to the json file.";
}
