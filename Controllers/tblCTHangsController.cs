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
    public class tblCTHangsController : Controller
    {
        private readonly DBFile _context;

        public tblCTHangsController(DBFile context)
        {
            _context = context;
        }

        // GET: tblCTHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblCTHang.ToListAsync());
        }

        // GET: tblCTHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCTHang = await _context.tblCTHang
                .FirstOrDefaultAsync(m => m.iIDHang == id);
            if (tblCTHang == null)
            {
                return NotFound();
            }

            return View(tblCTHang);
        }

        // GET: tblCTHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblCTHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("iIDHang,sTenHang,fGiaTien,iSoLuongCon")] tblCTHang tblCTHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCTHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCTHang);
        }

        // GET: tblCTHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCTHang = await _context.tblCTHang.FindAsync(id);
            if (tblCTHang == null)
            {
                return NotFound();
            }
            return View(tblCTHang);
        }

        // POST: tblCTHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iIDHang,sTenHang,fGiaTien,iSoLuongCon")] tblCTHang tblCTHang)
        {
            if (id != tblCTHang.iIDHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCTHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCTHangExists(tblCTHang.iIDHang))
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
            return View(tblCTHang);
        }

        // GET: tblCTHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCTHang = await _context.tblCTHang
                .FirstOrDefaultAsync(m => m.iIDHang == id);
            if (tblCTHang == null)
            {
                return NotFound();
            }

            return View(tblCTHang);
        }

        // POST: tblCTHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCTHang = await _context.tblCTHang.FindAsync(id);
            if (tblCTHang != null)
            {
                _context.tblCTHang.Remove(tblCTHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCTHangExists(int id)
        {
            return _context.tblCTHang.Any(e => e.iIDHang == id);
        }
    }
}
