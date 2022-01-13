using Microsoft.AspNetCore.Mvc;
using XeynergyUser.API.Data;
using XeynergyUser.API.Models;

namespace XeynergyUser.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly DataContext _context;

        public WeatherForecastController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var test= Ok(await _context.User.ToListAsync());
            return test;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var person = await _context.User.FindAsync(id);
            if (person == null)
                return BadRequest("User not found.");
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddPerson(User person)
        {
            _context.User.Add(person);
            await _context.SaveChangesAsync();

            return Ok(await _context.User.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdatePerson(User request)
        {
            var person = await _context.User.FindAsync(request.UserId);
            if (person == null)
                return BadRequest("User not found.");

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.EmailAddress = request.EmailAddress;
            person.UserGroup=request.UserGroup;

            await _context.SaveChangesAsync();

            return Ok(await _context.User.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            var person = await _context.User.FindAsync(id);
            if (person == null)
                return BadRequest("User not found.");

            _context.User.Remove(person);
            await _context.SaveChangesAsync();

            return Ok(await _context.User.ToListAsync());
        }

    }
}