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
    public class DoktorIslemleriController : Controller
    {
        private readonly HastaneContext _context;

        public DoktorIslemleriController(HastaneContext context)
        {
            _context = context;
        }

        // GET: DoktorIslemleri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doktorlar.ToListAsync());
        }

        // GET: DoktorIslemleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar
                .FirstOrDefaultAsync(m => m.DoktorId == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // GET: DoktorIslemleri/Create
        public IActionResult Create(int? id)
        {
            return View();
        }

        // POST: DoktorIslemleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoktorId,Ad,Soyad")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doktor);
                try
                {
                    await _context.SaveChangesAsync();
                    TempData["basarilimesaj"] = $"{doktor.Ad} {doktor.Soyad}'Adlı Doktor'un Kayıt İşlemi Başarılı.";
                }
                catch (SystemException)
                {
                    TempData["basarisizmesaj"] = $"{doktor.Ad} {doktor.Soyad}'Adlı Doktor'un Kayıt İşlemi Başarısız.";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(doktor);
        }

        // GET: DoktorIslemleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            return View(doktor);
        }

        // POST: DoktorIslemleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoktorId,Ad,Soyad")] Doktor doktor)
        {
            if (id != doktor.DoktorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    TempData["basarilimesaj"] = $"{doktor.Ad} {doktor.Soyad}'Adlı Doktor'un Bilgileri Güncellendi.";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["basarisizmesaj"] = $"{doktor.Ad} {doktor.Soyad}'Adlı Doktor'un Bilgileri Güncellenemedi.";
                    if (!DoktorExists(doktor.DoktorId))
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
            return View(doktor);
        }

        // GET: DoktorIslemleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar
                .FirstOrDefaultAsync(m => m.DoktorId == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: DoktorIslemleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doktor = await _context.Doktorlar.FindAsync(id);
            _context.Doktorlar.Remove(doktor);
            try
            {
                TempData["basarilimesaj"] = $"{doktor.Ad} {doktor.Soyad}'Adlı Doktoru Silme İşlemi Başarılı Oldu.";
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                TempData["basarisizmesaj"] = $"{doktor.Ad} {doktor.Soyad}'Adlı Doktoru Silme İşlemi Başarısız Oldu.";
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
            return _context.Doktorlar.Any(e => e.DoktorId == id);
        }
    }
}