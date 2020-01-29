using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pin_projekt_onlineKnjizara.Data;
using Pin_projekt_onlineKnjizara.Models;

namespace Pin_projekt_onlineKnjizara.Controllers
{
    public class KnjigeController : Controller
    {
        private readonly Pin_projekt_onlineKnjizaraContext _context;

        public KnjigeController(Pin_projekt_onlineKnjizaraContext context)
        {
            _context = context;
        }

        // GET: Knjige
        public async Task<IActionResult> Index(string autor, string search)
        {
            var pin_projekt_onlineKnjizaraContext = _context.Knjige.Include(k => k.Autor);
            
            if (!String.IsNullOrEmpty(autor))
            {
                var naslovi = _context.Knjige.Where(k => k.Autor.Prezime == autor);
                return View(await naslovi.OrderBy(k => k.Kolicina).ToListAsync());
            }
            if (!String.IsNullOrEmpty(search))
            {
                var naslovi = _context.Knjige.Where(k => k.Naslov.Contains(search) ||
                                                    k.Autor.Ime.Contains(search) ||
                                                    k.Autor.Prezime.Contains(search));
                return View(await naslovi.OrderBy(k => k.Kolicina).ToListAsync());
            }
            
            return View(await pin_projekt_onlineKnjizaraContext.OrderBy(k => k.Kolicina).ToListAsync());
        }

        // GET: Knjige/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjige
                .Include(k => k.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (knjiga == null)
            {
                return NotFound();
            }

            return View(knjiga);
        }

        // GET: Knjige/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autori, "Id", "Id");
            return View();
        }

        // POST: Knjige/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naslov,AutorId,Cijena")] Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(knjiga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autori, "Id", "Id", knjiga.AutorId);
            return View(knjiga);
        }

        // GET: Knjige/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjige.FindAsync(id);
            if (knjiga == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autori, "Id", "Id", knjiga.AutorId);
            return View(knjiga);
        }

        // POST: Knjige/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naslov,AutorId,Cijena,Kolicina")] Knjiga knjiga)
        {
            if (id != knjiga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knjiga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnjigaExists(knjiga.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autori, "Id", "Id", knjiga.AutorId);
            return View(knjiga);
        }

        // GET: Knjige/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjige
                .Include(k => k.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (knjiga == null)
            {
                return NotFound();
            }

            return View(knjiga);
        }

        // POST: Knjige/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var knjiga = await _context.Knjige.FindAsync(id);
            _context.Knjige.Remove(knjiga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnjigaExists(int id)
        {
            return _context.Knjige.Any(e => e.Id == id);
        }
    }
}
