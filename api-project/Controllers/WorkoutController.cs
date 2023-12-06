using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutsController : ControllerBase
{
    private readonly WorkoutContext _context;

    public WorkoutsController(WorkoutContext context)
    {
        _context = context;
    }

    // GET: api/TodoItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkoutDTO>>> GetTodoItems()
    {
        return await _context.Workouts
            .Select(x => ItemToDTO(x))
            .ToListAsync();
    }

    // GET: api/TodoItems/5
    // <snippet_GetByID>
    [HttpGet("{id}")]
    public async Task<ActionResult<WorkoutDTO>> GetTodoItem(long id)
    {
        var todoItem = await _context.Workouts.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return ItemToDTO(todoItem);
    }
    // </snippet_GetByID>

    // PUT: api/TodoItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Update>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(long id, WorkoutDTO workoutDTO)
    {
        if (id != workoutDTO.Id)
        {
            return BadRequest();
        }

        var todoItem = await _context.Workouts.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        todoItem.Name = workoutDTO.Name;
        todoItem.Description = workoutDTO.Description;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!WorkoutExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }
    // </snippet_Update>

    // POST: api/TodoItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Create>
    [HttpPost]
    public async Task<ActionResult<WorkoutDTO>> PostTodoItem(WorkoutDTO workoutDTO)
    {
        var workout = new Workout
        {
            Description = workoutDTO.Description,
            Name = workoutDTO.Name
        };

        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetTodoItem),
            new { id = workout.Id },
            ItemToDTO(workout));
    }
    // </snippet_Create>

    // DELETE: api/TodoItems/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {
        var todoItem = await _context.Workouts.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        _context.Workouts.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool WorkoutExists(long id)
    {
        return _context.Workouts.Any(e => e.Id == id);
    }

    private static WorkoutDTO ItemToDTO(Workout workout) =>
       new WorkoutDTO
       {
           Id = workout.Id,
           Name = workout.Name,
           Description = workout.Description
       };
}