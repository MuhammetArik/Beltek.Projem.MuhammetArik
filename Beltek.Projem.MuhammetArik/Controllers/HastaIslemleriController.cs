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
    public class HastaIslemleriController : Controller
    {
        private readonly HastaneContext _context;

        public HastaIslemleriController(HastaneContext context)
        {
            _context = context;
        }

        // GET: HastaIslemleri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hastalar.ToListAsync());
        }

        // GET: HastaIslemleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastalar
                .FirstOrDefaultAsync(m => m.HastaId == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        // GET: HastaIslemleri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HastaIslemleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HastaId,Ad,Soyad,TCNo")] Hasta hasta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hasta);
                try
                {
                    await _context.SaveChangesAsync();
                    TempData["basarilimesaj"] = $"{hasta.Ad} {hasta.Soyad}'Adlı Hasta'nın Kayıt İşlemi Başarılı.";
                }
                catch (SystemException)
                {
                    TempData["basarisizmesaj"] = "Kayıt İşlemi Başarısız.";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hasta);
        }

        // GET: HastaIslemleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastalar.FindAsync(id);
            if (hasta == null)
            {
                return NotFound();
            }
            return View(hasta);
        }

        // POST: HastaIslemleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HastaId,Ad,Soyad,TCNo")] Hasta hasta)
        {
            if (id != hasta.HastaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hasta);
                    TempData["basarilimesaj"] = $"{hasta.Ad} {hasta.Soyad}'Adlı Hasta'nın Bilgileri Güncellendi.";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["basarisizmesaj"] = $"{hasta.Ad} {hasta.Soyad}'Adlı Hasta'nın Bilgileri Güncellenemedi.";
                    if (!HastaExists(hasta.HastaId))
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
            return View(hasta);
        }

        // GET: HastaIslemleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastalar
                .FirstOrDefaultAsync(m => m.HastaId == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        // POST: HastaIslemleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hasta = await _context.Hastalar.FindAsync(id);
            _context.Hastalar.Remove(hasta);
            try
            {
                TempData["basarilimesaj"] = $"{hasta.Ad} {hasta.Soyad}'Adlı Hasta'yı Silme İşlemi Başarılı.";
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                TempData["basarisizmesaj"] = $"{hasta.Ad} {hasta.Soyad}'Adlı Hasta'yı Silme İşlemi Başarısız.";
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        private bool HastaExists(int id)
        {
            return _context.Hastalar.Any(e => e.HastaId == id);
        }
    }
}