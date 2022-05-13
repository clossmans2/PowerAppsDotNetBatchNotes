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
using FriendMusic.DTO;

namespace FriendMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly FMContext _context;
        private static ILogger<PeopleController> _logger;

        public PeopleController(FMContext context, ILogger<PeopleController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/People
        [HttpGet]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople() => await _context.People.ToListAsync();

        // GET: api/People/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {

            var person = await _context.People
                .Include(p => p.FavoriteSong)
                .FirstAsync(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
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
        
        // PUT: api/People/5/10
        [HttpPut("{id}/{SongId}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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

        private static PersonDTO PersonToDTO(FMContext ctx, Person person)
        {

            var favSong = ctx.Songs.FirstOrDefault(s => s.Id == person.FavoriteSong.Id);
            var lpDtoList = new List<PlaylistDTO>();
            person.LikedPlaylists.ForEach(lp =>
            {
                var playlist = ctx.Playlists.Find(lp.Id);
                if (playlist != null)
                {
                    var lpDto = new PlaylistDTO()
                    {
                        Id = playlist.Id,
                        Description = playlist.Description,
                        Title = playlist.Title,
                    };
                    lpDtoList.Add(lpDto);
                }
            });

            var opDtoList = new List<PlaylistDTO>();
            person.OwnedPlaylists.ForEach(op =>
            {
                var plist = ctx.Playlists.Find(op.Id);
                if (plist != null)
                {
                    var opDto = new PlaylistDTO()
                    {
                        Id = plist.Id,
                        Description = plist.Description,
                        Title = plist.Title,
                    };
                    opDtoList.Add(opDto);
                }
            });

            var favSongDTO = new SongDTO()
            {
                Id = favSong.Id,
                Artist = favSong.Artist,
                Title = favSong.Title,
                AlbumTitle = favSong.AlbumTitle,
                Length = favSong.Length,
            };
            PersonDTO pdto = new PersonDTO()
            {
                Id = person.Id,
                Birthday = person.Birthday,
                FirstName = person.FirstName,
                LastName = person.LastName,
                FavoriteSong = favSongDTO,
                LikedPlaylists = lpDtoList,
                OwnedPlaylists = opDtoList,
            };

            return pdto;
        }
    }
}
