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
    public class tblNguoiDungsController : Controller
    {
        private readonly DBFile _context;

        public tblNguoiDungsController(DBFile context)
        {
            _context = context;
        }

        // GET: tblNguoiDungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblNguoiDung.ToListAsync());
        }

        // GET: tblNguoiDungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblNguoiDung = await _context.tblNguoiDung
                .FirstOrDefaultAsync(m => m.iIDNguoiDung == id);
            if (tblNguoiDung == null)
            {
                return NotFound();
            }

            return View(tblNguoiDung);
        }

        // GET: tblNguoiDungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblNguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("iIDNguoiDung,sTenNguoiDung,sTenDangNhap,sMatKhau,sSoDienThoai,sDiaChi")] tblNguoiDung tblNguoiDung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblNguoiDung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblNguoiDung);
        }

        // GET: tblNguoiDungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblNguoiDung = await _context.tblNguoiDung.FindAsync(id);
            if (tblNguoiDung == null)
            {
                return NotFound();
            }
            return View(tblNguoiDung);
        }

        // POST: tblNguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iIDNguoiDung,sTenNguoiDung,sTenDangNhap,sMatKhau,sSoDienThoai,sDiaChi")] tblNguoiDung tblNguoiDung)
        {
            if (id != tblNguoiDung.iIDNguoiDung)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblNguoiDung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblNguoiDungExists(tblNguoiDung.iIDNguoiDung))
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
            return View(tblNguoiDung);
        }

        // GET: tblNguoiDungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblNguoiDung = await _context.tblNguoiDung
                .FirstOrDefaultAsync(m => m.iIDNguoiDung == id);
            if (tblNguoiDung == null)
            {
                return NotFound();
            }

            return View(tblNguoiDung);
        }

        // POST: tblNguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblNguoiDung = await _context.tblNguoiDung.FindAsync(id);
            if (tblNguoiDung != null)
            {
                _context.tblNguoiDung.Remove(tblNguoiDung);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblNguoiDungExists(int id)
        {
            return _context.tblNguoiDung.Any(e => e.iIDNguoiDung == id);
        }

		
	}
}
