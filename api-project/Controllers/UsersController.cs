using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserContext _context;

    public UsersController(UserContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<UserDTO>> GetUser(long id){
        var user = await _context.Users.FindAsync(id);
        return ItemToDTO(user ?? new User());
    }


    private static UserDTO ItemToDTO(User user) =>
       new UserDTO
       {
           Id = user.Id,
           Name = user.Name,
           Email = user.Email
       };
}
