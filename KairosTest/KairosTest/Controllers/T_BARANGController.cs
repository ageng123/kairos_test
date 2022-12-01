using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KairosTest.Data;
using KairosTest.Models;
using Microsoft.Data.SqlClient;

using System;
using System.Data;
using System.Data.SqlClient;
using Azure.Core;

namespace KairosTest.Controllers
{
    public class T_BARANGController : Controller
    {
        private readonly KairosTestContext _context;
        private readonly String _sqlProcedure = "EXEC dbo.crudBarang @id,@NamaBarang,@KodeBarang,@JumlahBarag,@Search,@ActionType";
        public T_BARANGController(KairosTestContext context)
        {
            _context = context;
        }

        // GET: T_BARANG
        [HttpGet,HttpPost]
        public IActionResult Index(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                search = " ";
            }
            else
            {
                search = "%" + search + "%";
            }
            Console.WriteLine(search);
            var sqlParams = new SqlParameter("@id", 1);
            var sqlParams2 = new SqlParameter("@NamaBarang", " ");
            var sqlParams3 = new SqlParameter("@KodeBarang", " ");
            var sqlParams4 = new SqlParameter("@JumlahBarag", 1);
            var sqlParams5 = new SqlParameter("@Search", search);
            var sqlParams6 = new SqlParameter("@ActionType", 4);
            ViewData["Search"] = search.Replace("%", "").Trim();
            var dt = _context.T_BARANG.FromSqlRaw("EXEC dbo.crudBarang @id,@NamaBarang,@KodeBarang,@JumlahBarag,@Search,@ActionType", sqlParams, sqlParams2, sqlParams3, sqlParams4, sqlParams4,sqlParams5,sqlParams6).ToList();
            return View(dt);
        }
       
        // GET: T_BARANG/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.T_BARANG == null)
            {
                return NotFound();
            }

            var t_BARANG = await _context.T_BARANG
                .FirstOrDefaultAsync(m => m.id == id);
            if (t_BARANG == null)
            {
                return NotFound();
            }

            return View(t_BARANG);
        }

        // GET: T_BARANG/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: T_BARANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,KodeBarang,NamaBarang,JumlahBarag")] T_BARANG t_BARANG)
        {
           

            if (ModelState.IsValid)
            {
                
                var Id = new SqlParameter("@id", 1);
                var ActionType = new SqlParameter("@ActionType", 1);
                var Search = new SqlParameter("@Search", " ");
                var NamaBarang = new SqlParameter("@NamaBarang", t_BARANG.KodeBarang);
                var KodeBarang = new SqlParameter("@KodeBarang", t_BARANG.KodeBarang);
                var JumlahBarag = new SqlParameter("@JumlahBarag", t_BARANG.JumlahBarag);
                var dt =  _context.Database.ExecuteSqlRaw(_sqlProcedure,Id,NamaBarang,KodeBarang,JumlahBarag,Search,ActionType);
                return RedirectToAction(nameof(Index));
            }
            return View(t_BARANG);
        }

        // GET: T_BARANG/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.T_BARANG == null)
            {
                return NotFound();
            }

            var t_BARANG = await _context.T_BARANG.FindAsync(id);
            if (t_BARANG == null)
            {
                return NotFound();
            }
            return View(t_BARANG);
        }

        // POST: T_BARANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,KodeBarang,NamaBarang,JumlahBarag")] T_BARANG t_BARANG)
        {
            if (id != t_BARANG.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Id = new SqlParameter("@id", id);
                    var ActionType = new SqlParameter("@ActionType", 2);
                    var Search = new SqlParameter("@Search", " ");
                    var NamaBarang = new SqlParameter("@NamaBarang", t_BARANG.NamaBarang?.ToString());
                    var KodeBarang = new SqlParameter("@KodeBarang", t_BARANG.KodeBarang?.ToString());
                    var JumlahBarag = new SqlParameter("@JumlahBarag", t_BARANG.JumlahBarag?.ToString());
                    var dt = _context.Database.ExecuteSqlRaw(_sqlProcedure, Id, NamaBarang, KodeBarang, JumlahBarag, Search, ActionType);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T_BARANGExists(t_BARANG.id))
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
            return View(t_BARANG);
        }

        // GET: T_BARANG/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.T_BARANG == null)
            {
                return NotFound();
            }

            var t_BARANG = await _context.T_BARANG
                .FirstOrDefaultAsync(m => m.id == id);
            if (t_BARANG == null)
            {
                return NotFound();
            }

            return View(t_BARANG);
        }

        // POST: T_BARANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.T_BARANG == null)
            {
                return Problem("Entity set 'KairosTestContext.T_BARANG'  is null.");
            }
            var t_BARANG = await _context.T_BARANG.FindAsync(id);
            if (t_BARANG != null)
            {
                _context.Remove(t_BARANG);
               
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T_BARANGExists(int id)
        {
          return _context.T_BARANG.Any(e => e.id == id);
        }
    }
}
