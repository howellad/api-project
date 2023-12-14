// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Api.Models;
// namespace Api.Controllers;

// [Route("api/[controller]")]
// [ApiController]
// public class UsersController : ControllerBase
// {
//     private readonly SwimLogContext _context;

//     public UsersController(SwimLogContext context)
//     {
//         _context = context;
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<UserDTO>> GetUser(long id)
//     {
//         var user = await _context.Users.FindAsync(id);
//         return ItemToDTO(user ?? new User());
//     }

//     [HttpPut("{id}")]
//     public async Task<IActionResult> Putuser(long id, UserDTO userDTO)
//     {
//         if (id != userDTO.Id)
//         {
//             return BadRequest();
//         }

//         var user = await _context.Users.FindAsync(id);
//         if (user == null)
//         {
//             return NotFound();
//         }

//         user.Name = userDTO.Name;
//         user.DateOfBirth = userDTO.DateOfBirth;
//         user.Email = userDTO.Email;

//         try
//         {
//             await _context.SaveChangesAsync();
//         }
//         catch (DbUpdateConcurrencyException) when (!UserExists(id))
//         {
//             return NotFound();
//         }

//         return NoContent();
//     }

//     private bool UserExists(long id)
//     {
//         return _context.Users.Any(e => e.Id == id);
//     }

//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteUser(long id)
//     {
//         var user = await _context.Users.FindAsync(id);
//         if (user == null)
//         {
//             return NotFound();
//         }

//         _context.Users.Remove(user);
//         await _context.SaveChangesAsync();

//         return NoContent();
//     }

//     private static UserDTO ItemToDTO(User user) =>
//        new UserDTO
//        {
//            Id = user.Id,
//            Name = user.Name,
//            Email = user.Email 
//        };
// }