using FriendMusic.Data;
using FriendMusic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FriendMusicMVC.Controllers {
    public class SongsController : Controller {

        private readonly FMContext _context;

        public SongsController(FMContext context) {
            _context = context;
        }

        // GET: SongsController
        public async Task<IActionResult> Index() {
            return View(await _context.Songs.ToListAsync());
        }

        // GET: SongsController/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null) {
                return NotFound();
            }

            return View(song);
        }

        // GET: SongsController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: SongsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Artist,Length,AlbumTitle")] Song song) {
            if (ModelState.IsValid) {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: SongsController/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var song = await _context.Songs.FindAsync(id);
            if (song == null) {
                return NotFound();
            }
            return View(song);
        }

        // POST: SongsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Artist,Length,AlbumTitle")] Song song) {
            if (id != song.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!SongExists(song.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: SongsController/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null) {
                return NotFound();
            }

            return View(song);
        }

        // POST: SongsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var song = await _context.Songs.FindAsync(id);
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id) {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
