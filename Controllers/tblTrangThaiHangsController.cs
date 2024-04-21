using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Data;
using WebBanHang.Models.Model;

namespace WebBanHang.Controllers
{
    public class tblTrangThaiHangsController : Controller
    {
        private readonly DBFile _context;

        public tblTrangThaiHangsController(DBFile context)
        {
            _context = context;
        }

        // GET: tblTrangThaiHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblTrangThaiHang.ToListAsync());
        }

        // GET: tblTrangThaiHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTrangThaiHang = await _context.tblTrangThaiHang
                .FirstOrDefaultAsync(m => m.iIDNguoiDung == id);
            if (tblTrangThaiHang == null)
            {
                return NotFound();
            }

            return View(tblTrangThaiHang);
        }

        // GET: tblTrangThaiHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblTrangThaiHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("iIDNguoiDung,iIDHang,sThanhToan,idMaGiam")] tblTrangThaiHang tblTrangThaiHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTrangThaiHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTrangThaiHang);
        }

        // GET: tblTrangThaiHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTrangThaiHang = await _context.tblTrangThaiHang.FindAsync(id);
            if (tblTrangThaiHang == null)
            {
                return NotFound();
            }
            return View(tblTrangThaiHang);
        }

        // POST: tblTrangThaiHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iIDNguoiDung,iIDHang,sThanhToan,idMaGiam")] tblTrangThaiHang tblTrangThaiHang)
        {
            if (id != tblTrangThaiHang.iIDNguoiDung)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTrangThaiHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblTrangThaiHangExists(tblTrangThaiHang.iIDNguoiDung))
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
            return View(tblTrangThaiHang);
        }

        // GET: tblTrangThaiHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTrangThaiHang = await _context.tblTrangThaiHang
                .FirstOrDefaultAsync(m => m.iIDNguoiDung == id);
            if (tblTrangThaiHang == null)
            {
                return NotFound();
            }

            return View(tblTrangThaiHang);
        }

        // POST: tblTrangThaiHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTrangThaiHang = await _context.tblTrangThaiHang.FindAsync(id);
            if (tblTrangThaiHang != null)
            {
                _context.tblTrangThaiHang.Remove(tblTrangThaiHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblTrangThaiHangExists(int id)
        {
            return _context.tblTrangThaiHang.Any(e => e.iIDNguoiDung == id);
        }
    }
}
