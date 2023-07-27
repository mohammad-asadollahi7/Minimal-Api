using Minimal_Api.Model;
using System.Text.Json;

namespace Minimal_Api.Data;

public class UserData
{
    private string FilePath;
    public List<User>? users;
    public UserData()
    {
        FilePath = GetFilePath();
        var jsonString = File.ReadAllText(FilePath);
        users = JsonSerializer.Deserialize<List<User>>(jsonString);
    }

    public void Savechanges()
    {
        var jsonString = JsonSerializer.Serialize(users);
        File.WriteAllText(FilePath, jsonString);
    }

    private string GetFilePath()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string? projectDirectory = Directory.GetParent(workingDirectory)?
                                    .FullName;
        return Path.Combine(projectDirectory, "Minimal-api", "Data", "User.json");
    }


}
