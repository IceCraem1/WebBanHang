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
    public class tblLoaiHangsController : Controller
    {
        private readonly DBFile _context;

        public tblLoaiHangsController(DBFile context)
        {
            _context = context;
        }

        // GET: tblLoaiHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblLoaiHang.ToListAsync());
        }

        // GET: tblLoaiHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLoaiHang = await _context.tblLoaiHang
                .FirstOrDefaultAsync(m => m.iIDLoai == id);
            if (tblLoaiHang == null)
            {
                return NotFound();
            }

            return View(tblLoaiHang);
        }

        // GET: tblLoaiHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblLoaiHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("iIDLoai,sHang,sDang")] tblLoaiHang tblLoaiHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblLoaiHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblLoaiHang);
        }

        // GET: tblLoaiHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLoaiHang = await _context.tblLoaiHang.FindAsync(id);
            if (tblLoaiHang == null)
            {
                return NotFound();
            }
            return View(tblLoaiHang);
        }

        // POST: tblLoaiHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iIDLoai,sHang,sDang")] tblLoaiHang tblLoaiHang)
        {
            if (id != tblLoaiHang.iIDLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblLoaiHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblLoaiHangExists(tblLoaiHang.iIDLoai))
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
            return View(tblLoaiHang);
        }

        // GET: tblLoaiHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLoaiHang = await _context.tblLoaiHang
                .FirstOrDefaultAsync(m => m.iIDLoai == id);
            if (tblLoaiHang == null)
            {
                return NotFound();
            }

            return View(tblLoaiHang);
        }

        // POST: tblLoaiHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblLoaiHang = await _context.tblLoaiHang.FindAsync(id);
            if (tblLoaiHang != null)
            {
                _context.tblLoaiHang.Remove(tblLoaiHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblLoaiHangExists(int id)
        {
            return _context.tblLoaiHang.Any(e => e.iIDLoai == id);
        }
    }
}
