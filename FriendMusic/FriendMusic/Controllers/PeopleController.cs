#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FriendMusic.Data;
using FriendMusic.Models;

namespace FriendMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly FMContext _context;

        public PeopleController(FMContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.People
                .Include(p => p.FavoriteSong)
                .FirstAsync(p => p.Id == id);


            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}/{SongId}/")]
        public async Task<IActionResult> PutFavoriteSong(int id, int SongId)
        {
            var person = await _context.People.FindAsync(id);
            var song = await _context.Songs.FindAsync(SongId);
            if (song == null)
            {
                return NotFound();
            }
            if (person == null)
            {
                return NotFound();
            }
            person.FavoriteSong = song;
            await _context.SaveChangesAsync();

            return Ok(person);
        }

        [HttpPost("console/")]
        public IActionResult GetPersonToConsole([FromBody] Person person)
        {

            Console.WriteLine($"{person.FirstName} {person.LastName} was born on {person.Birthday}");
            var personJson = JsonSerializer.Serialize(person);
            Console.WriteLine(personJson);
            var personEntity = JsonSerializer.Deserialize<Person>(personJson);

            var song = new Song()
            {
                Id = 3,
                Artist = "Nirvana",
                Title = "Lithium",
                AlbumTitle = "Nirvana",
                Length = TimeSpan.FromSeconds(257)
            };

            var opts = new JsonSerializerOptions
            {
                WriteIndented = true,
                AllowTrailingCommas = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                
            };

            return Ok(song);
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
