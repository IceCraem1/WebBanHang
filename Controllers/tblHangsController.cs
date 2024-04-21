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
    public class tblHangsController : Controller
    {
        private readonly DBFile _context;

        public tblHangsController(DBFile context)
        {
            _context = context;
        }

        // GET: tblHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblHang.ToListAsync());
        }

        // GET: tblHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHang = await _context.tblHang
                .FirstOrDefaultAsync(m => m.iIDHang == id);
            if (tblHang == null)
            {
                return NotFound();
            }

            return View(tblHang);
        }

        // GET: tblHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("iIDHang,iIDLoai,iIDNguoiDung")] tblHang tblHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblHang);
        }

        // GET: tblHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHang = await _context.tblHang.FindAsync(id);
            if (tblHang == null)
            {
                return NotFound();
            }
            return View(tblHang);
        }

        // POST: tblHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iIDHang,iIDLoai,iIDNguoiDung")] tblHang tblHang)
        {
            if (id != tblHang.iIDHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblHangExists(tblHang.iIDHang))
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
            return View(tblHang);
        }

        // GET: tblHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHang = await _context.tblHang
                .FirstOrDefaultAsync(m => m.iIDHang == id);
            if (tblHang == null)
            {
                return NotFound();
            }

            return View(tblHang);
        }

        // POST: tblHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblHang = await _context.tblHang.FindAsync(id);
            if (tblHang != null)
            {
                _context.tblHang.Remove(tblHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblHangExists(int id)
        {
            return _context.tblHang.Any(e => e.iIDHang == id);
        }
    }
}
