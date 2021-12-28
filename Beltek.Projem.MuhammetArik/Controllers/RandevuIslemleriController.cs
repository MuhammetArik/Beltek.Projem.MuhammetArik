using Beltek.Projem.MuhammetArik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Beltek.Projem.MuhammetArik.Controllers
{
    public class RandevuIslemleriController : Controller
    {
        private readonly HastaneContext _context;

        public RandevuIslemleriController(HastaneContext context)
        {
            _context = context;
        }

        // GET: RandevuIslemleri
        public async Task<IActionResult> Index()
        {
            var hastaneContext = _context.Randevular.Include(r => r.Doktor).Include(r => r.Hasta).Include(r => r.Klinik);
            return View(await hastaneContext.ToListAsync());
        }

        // GET: RandevuIslemleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevuAl = await _context.Randevular
                .Include(r => r.Doktor)
                .Include(r => r.Hasta)
                .Include(r => r.Klinik)
                .FirstOrDefaultAsync(m => m.RandevuId == id);
            if (randevuAl == null)
            {
                return NotFound();
            }

            return View(randevuAl);
        }

        // GET: RandevuIslemleri/Create
        public IActionResult Create()
        {
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "DoktorId", "Ad");
            ViewData["HastaId"] = new SelectList(_context.Hastalar, "HastaId", "Ad");
            ViewData["KlinikId"] = new SelectList(_context.Klinikler, "KlinikId", "Adi");
            return View();
        }

        // POST: RandevuIslemleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RandevuId,HastaId,KlinikId,DoktorId,RandevuZamani")] RandevuAl randevuAl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevuAl);
                await _context.SaveChangesAsync();
                TempData["basarilimesaj"] = $"Randevu Ekleme İşlemi Başarılı.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "DoktorId", "Ad", randevuAl.DoktorId);
            ViewData["HastaId"] = new SelectList(_context.Hastalar, "HastaId", "Ad", randevuAl.HastaId);
            ViewData["KlinikId"] = new SelectList(_context.Klinikler, "KlinikId", "Adi", randevuAl.KlinikId);
            return View(randevuAl);
        }

        // GET: RandevuIslemleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevuAl = await _context.Randevular
                .Include(r => r.Doktor)
                .Include(r => r.Hasta)
                .Include(r => r.Klinik)
                .FirstOrDefaultAsync(m => m.RandevuId == id);
            if (randevuAl == null)
            {
                return NotFound();
            }
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "DoktorId", "Ad", randevuAl.DoktorId);
            ViewData["HastaId"] = new SelectList(_context.Hastalar, "HastaId", "Ad", randevuAl.HastaId);
            ViewData["KlinikId"] = new SelectList(_context.Klinikler, "KlinikId", "Adi", randevuAl.KlinikId);
            return View(randevuAl);
        }

        // POST: RandevuIslemleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RandevuId,HastaId,KlinikId,DoktorId,RandevuZamani")] RandevuAl randevuAl)
        {
            if (id != randevuAl.RandevuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevuAl);
                    TempData["basarilimesaj"] = "Güncelleme İşlemi Başarılı.";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["basarisizmesaj"] = "Güncelleme İşlemi Başarısız Oldu.";
                    if (!RandevuAlExists(randevuAl.RandevuId))
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
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "DoktorId", "DoktorId", randevuAl.DoktorId);
            ViewData["HastaId"] = new SelectList(_context.Hastalar, "HastaId", "HastaId", randevuAl.HastaId);
            ViewData["KlinikId"] = new SelectList(_context.Klinikler, "KlinikId", "KlinikId", randevuAl.KlinikId);
            return View(randevuAl);
        }

        // GET: RandevuIslemleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevuAl = await _context.Randevular
                .Include(r => r.Doktor)
                .Include(r => r.Hasta)
                .Include(r => r.Klinik)
                .FirstOrDefaultAsync(m => m.RandevuId == id);
            if (randevuAl == null)
            {
                return NotFound();
            }

            return View(randevuAl);
        }

        // POST: RandevuIslemleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var randevuAl = await _context.Randevular.Include(r => r.Doktor)
                .Include(r => r.Hasta)
                .Include(r => r.Klinik)
                .FirstOrDefaultAsync(m => m.RandevuId == id);
            _context.Randevular.Remove(randevuAl);
            try
            {
                TempData["basarilimesaj"] = "Silme İşlemi Başarılı.";
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                TempData["basarisizmesaj"] = "Silme İşlemi Başarısız Oldu.";
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuAlExists(int id)
        {
            return _context.Randevular.Any(e => e.RandevuId == id);
        }
    }
}