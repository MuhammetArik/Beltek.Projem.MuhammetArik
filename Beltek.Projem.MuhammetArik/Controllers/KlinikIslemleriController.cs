using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beltek.Projem.MuhammetArik.Models;

namespace Beltek.Projem.MuhammetArik.Controllers
{
    public class KlinikIslemleriController : Controller
    {
        private readonly HastaneContext _context;

        public KlinikIslemleriController(HastaneContext context)
        {
            _context = context;
        }

        // GET: KlinikIslemleri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klinikler.ToListAsync());
        }

        // GET: KlinikIslemleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klinik = await _context.Klinikler
                .FirstOrDefaultAsync(m => m.KlinikId == id);
            if (klinik == null)
            {
                return NotFound();
            }

            return View(klinik);
        }

        // GET: KlinikIslemleri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KlinikIslemleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlinikId,Adi")] Klinik klinik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klinik);
                try
                {
                    await _context.SaveChangesAsync();
                    TempData["basarilimesaj"] = $"{klinik.Adi}'Adlı Klinik Ekleme İşlemi Başarılı.";
                }
                catch (SystemException)
                {
                    TempData["basarisizmesaj"] = $"{klinik.Adi}'Adlı Klinik Ekleme İşlemi Başarısız Oldu.";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(klinik);
        }

        // GET: KlinikIslemleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klinik = await _context.Klinikler.FindAsync(id);
            if (klinik == null)
            {
                return NotFound();
            }
            return View(klinik);
        }

        // POST: KlinikIslemleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KlinikId,Adi")] Klinik klinik)
        {
            if (id != klinik.KlinikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klinik);
                    TempData["basarilimesaj"] = $"{klinik.Adi}'Adlı Klinik Güncelleme İşlemi Başarılı.";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["basarisizmesaj"] = $"{klinik.Adi}'Adlı Klinik Güncelleme İşlemi Başarısız Oldu.";
                    if (!KlinikExists(klinik.KlinikId))
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
            return View(klinik);
        }

        // GET: KlinikIslemleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klinik = await _context.Klinikler
                .FirstOrDefaultAsync(m => m.KlinikId == id);
            if (klinik == null)
            {
                return NotFound();
            }

            return View(klinik);
        }

        // POST: KlinikIslemleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klinik = await _context.Klinikler.FindAsync(id);
            _context.Klinikler.Remove(klinik);
            try
            {
                TempData["basarilimesaj"] = $"{klinik.Adi}'Adlı Klinik Silme İşlemi Başarılı.";
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                TempData["basarisizmesaj"] = $"{klinik.Adi}'Adlı Klinik Silme İşlemi Başarısız Oldu.";
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        private bool KlinikExists(int id)
        {
            return _context.Klinikler.Any(e => e.KlinikId == id);
        }
    }
}