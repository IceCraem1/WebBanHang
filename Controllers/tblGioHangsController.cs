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
    public class tblGioHangsController : Controller
    {
        private readonly DBFile _context;

        public tblGioHangsController(DBFile context)
        {
            _context = context;
        }

        // GET: tblGioHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblGioHang.ToListAsync());
        }

        // GET: tblGioHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGioHang = await _context.tblGioHang
                .FirstOrDefaultAsync(m => m.iIDNguoiDung == id);
            if (tblGioHang == null)
            {
                return NotFound();
            }

            return View(tblGioHang);
        }

        // GET: tblGioHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblGioHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("iIDNguoiDung,iSoLuongHang")] tblGioHang tblGioHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblGioHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblGioHang);
        }

        // GET: tblGioHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGioHang = await _context.tblGioHang.FindAsync(id);
            if (tblGioHang == null)
            {
                return NotFound();
            }
            return View(tblGioHang);
        }

        // POST: tblGioHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iIDNguoiDung,iSoLuongHang")] tblGioHang tblGioHang)
        {
            if (id != tblGioHang.iIDNguoiDung)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblGioHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblGioHangExists(tblGioHang.iIDNguoiDung))
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
            return View(tblGioHang);
        }

        // GET: tblGioHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGioHang = await _context.tblGioHang
                .FirstOrDefaultAsync(m => m.iIDNguoiDung == id);
            if (tblGioHang == null)
            {
                return NotFound();
            }

            return View(tblGioHang);
        }

        // POST: tblGioHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblGioHang = await _context.tblGioHang.FindAsync(id);
            if (tblGioHang != null)
            {
                _context.tblGioHang.Remove(tblGioHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblGioHangExists(int id)
        {
            return _context.tblGioHang.Any(e => e.iIDNguoiDung == id);
        }
    }
}
