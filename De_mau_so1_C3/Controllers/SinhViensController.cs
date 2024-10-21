using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using De_mau_so1_C3.Models;

namespace De_mau_so1_C3.Controllers
{
    public class SinhViensController : Controller
    {
        private readonly AppDbcontextSv _dbcontext;

        public SinhViensController(AppDbcontextSv context)
        {
            _dbcontext = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sinhViens = await _dbcontext.SinhViens.Include(s => s.LopHoc).ToListAsync();
            return View(sinhViens);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _dbcontext.SinhViens.FindAsync(id); 
                
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["maLop"] = new SelectList(_dbcontext.LopHocs, "MaLop", "TenLop");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Add(sinhVien);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["maLop"] = new SelectList(_dbcontext.LopHocs, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _dbcontext.SinhViens.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewData["maLop"] = new SelectList(_dbcontext.LopHocs, "MaLop", "TenLop", sinhVien.MaLop); 
            //ViewBag.malop = _dbcontext.LopHocs.ToList();
            return View(sinhVien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SinhVien sinhVien)
        {
            if (id != sinhVien.MaLop)
            {
                return NotFound();
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    var updatesinhvien = await _dbcontext.SinhViens.FindAsync(id);

                    if (updatesinhvien != null)
                    {
                        updatesinhvien.Ten = sinhVien.Ten;
                        updatesinhvien.NgaySinh = sinhVien.NgaySinh;
                        updatesinhvien.Nganh = sinhVien.Nganh;
                        updatesinhvien.MaLop = sinhVien.MaLop;


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
            ViewData["maLop"] = new SelectList(_dbcontext.LopHocs, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _dbcontext.SinhViens
                .Include(s => s.LopHoc)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhVien = await _dbcontext.SinhViens.FindAsync(id);
            if (sinhVien != null)
            {
                _dbcontext.SinhViens.Remove(sinhVien);
            }

            await _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
