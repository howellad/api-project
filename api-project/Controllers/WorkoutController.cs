using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutsController : ControllerBase
{
    private readonly SwimLogContext _context;

    public WorkoutsController(SwimLogContext context)
    {
        _context = context;
    }

    // GET: api/workouts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkoutDTO>>> Getworkouts()
    {
        return await _context.Workouts
            .Select(x => ItemToDTO(x))
            .ToListAsync();
    }

    // GET: api/workouts/5
    // <snippet_GetByID>
    [HttpGet("{id}")]
    public async Task<ActionResult<WorkoutDTO>> GetWorkout(long id)
    {
        var workout = await _context.Workouts.FindAsync(id);

        if (workout == null)
        {
            return NotFound();
        }

        return ItemToDTO(workout);
    }
    // </snippet_GetByID>

    // PUT: api/workouts/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Update>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWorkout(long id, WorkoutDTO workoutDTO)
    {
        if (id != workoutDTO.Id)
        {
            return BadRequest();
        }

        var workout = await _context.Workouts.FindAsync(id);
        if (workout == null)
        {
            return NotFound();
        }

        workout.Name = workoutDTO.Name;
        workout.Description = workoutDTO.Description;

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

    // POST: api/workouts
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Create>
    [HttpPost]
    public async Task<ActionResult<WorkoutDTO>> PostWorkouts(WorkoutDTO workoutDTO)
    {
        var workout = new Workout
        {
            Description = workoutDTO.Description,
            Name = workoutDTO.Name
        };

        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(Workout),
            new { id = workout.Id },
            ItemToDTO(workout));
    }
    // </snippet_Create>

    // DELETE: api/Workout/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkout(long id)
    {
        var workout = await _context.Workouts.FindAsync(id);
        if (workout == null)
        {
            return NotFound();
        }

        _context.Workouts.Remove(workout);
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