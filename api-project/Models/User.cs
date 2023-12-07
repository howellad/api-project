using NuGet.Common;

namespace Api.Models;

public class User {

    public long UserId {get;set;}
    public Guid Id {get;set;}
    public string Name {get;set;}
    public DateTime DateOfBirth {get;set;}
    public string Email {get;set;}
    public DateTime Registered {get;set;} 
}

public class UserDTO {
    public long UserId {get;set;}
    public Guid Id {get;set;}
    public string Name {get;set;}
    public DateTime DateOfBirth {get;set;}
    public string Email {get;set;}
    public DateTime Registered {get;set;} 
}