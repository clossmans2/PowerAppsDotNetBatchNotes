#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FriendMusic.Data;
using FriendMusic.Models;

namespace FriendMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly FMContext _context;

        private readonly ILogger<PlaylistsController> _logger;

        public PlaylistsController(ILogger<PlaylistsController> logger, FMContext context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists() => await _context.Playlists.ToListAsync();
        

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id) => await _context.Playlists.FindAsync(id);


        // GET: api/Playlists/B.O.B.
        [HttpGet("{title}")]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylistByTitle(string title)
        {
            var playlists = await _context.Playlists
                .Where(p => p.Title.Contains(title))
                .ToListAsync();

            return playlists;
        }


        // PUT: api/Playlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(playlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistExists(id))
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

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaylist", new { id = playlist.Id }, playlist);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Playlists/5/Songs/5
        [HttpPost("{playlistId}/Songs/{songId}")]
        public async Task<ActionResult<Playlist>> AddSongToPlaylist(int playlistId, int songId)
        {
            _logger.LogDebug("Beginning AddSongToPlaylist");
            var playlist = await _context.Playlists.Include(p => p.Owner).FirstAsync(p => p.Id == playlistId);
            if(playlist == null)
            {
                _logger.LogDebug("Playlist not found, returning bad request.");
                BadRequest();
            }
            _logger.LogDebug("Finding Song");
            var song = await _context.Songs.FindAsync(songId);
            if (song == null)
            {
                _logger.LogDebug("Song not found, returning bad request.");
                BadRequest();
            }
            _logger.LogDebug("Song found.  Creating new PlaylistSong record.");
            playlist.Songs.Add(song);

            _logger.LogDebug("Calling context.SaveChanges");

            await _context.SaveChangesAsync();

            _logger.LogDebug($"Returning evenrything {playlist}");

            return Ok(playlist);           
        }

        // POST: api/Playlists/5/Owner/10
        [HttpPost("{playlistId}/Owner/{ownerId}")]
        public async Task<ActionResult<Playlist>> AddOwnerToPlaylist(int playlistId, int ownerId)
        {
            var playlist = await _context.Playlists.Include(p => p.Songs).FirstAsync(p => p.Id == playlistId);
            var person = await _context.People.FindAsync(ownerId);

            playlist.Owner = person;

            await _context.SaveChangesAsync();

            return Ok(playlist);
        }

        private bool PlaylistExists(int id)
        {
            return _context.Playlists.Any(e => e.Id == id);
        }
    }
}
