using De_mau_so1_C3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace De_mau_so1_C3.Controllers
{
    public class LopHocsController : Controller
    {
        private readonly AppDbcontextSv _dbcontext;

        public LopHocsController(AppDbcontextSv dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]   
        public async Task <IActionResult> Index()
        {
            var lophoc = await _dbcontext.LopHocs.ToListAsync();
            return View(lophoc);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.LopHocs.Add(lopHoc);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lopHoc);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var lop = _dbcontext.LopHocs.Find(id);

            if (lop == null)
            {
                return NotFound();
            }
            return View(lop);
        }

        [HttpGet]

        public IActionResult Edit(string id)
        {
            var lop = _dbcontext.LopHocs.Find(id);

            if(lop == null)
            {
                return NotFound();
            }
            return View(lop);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(string id, LopHoc lophoc)
        {
            if (id != lophoc.MaLop)
            {
                return NotFound();
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    var updatelophoc = await _dbcontext.LopHocs.FindAsync(id);

                    if (updatelophoc != null)
                    {
                        updatelophoc.MaLop = lophoc.MaLop;
                        updatelophoc.TenLop = lophoc.TenLop;
                        updatelophoc.Khoa = lophoc.Khoa;
                        

                        await _dbcontext.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Khong the luu lop hoc. ");
            }
            return View(lophoc);
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var cus = _dbcontext.LopHocs.Find(id);
            if (cus == null)
            {
                return NotFound(0);
            }
            return View(cus);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cus = await _dbcontext.LopHocs.FindAsync(id);

            if (cus != null)
            {
                _dbcontext.Remove(cus);
                await _dbcontext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
