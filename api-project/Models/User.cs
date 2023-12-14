using NuGet.Common;

namespace Api.Models;

public class UserDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public DateTime Registered { get; set; }
}