using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RecordsController : Controller
    {
        private readonly DataContext _context;

        public RecordsController(DataContext context)
        {
            _context = context;
        }

        // GET: Records
        public async Task<IActionResult> Index()
        {
            return View(await _context.Records.Where(x => x.Time.Date == DateTime.Now.Date).ToListAsync());
        }

        [Route("")]
        public async Task<IActionResult> Index([FromQuery] DateTime date, [FromQuery] string group)
        {
            if (date != null)
            {
                var result = date != DateTime.MinValue
                    ? _context.Records.Where(x => x.Time.Date == date.Date && x.Group == group)
                    : _context.Records.Where(x => x.Time.Date == DateTime.Now.Date && x.Group == _context.Groups.FirstOrDefault().GroupName);
                if (!result.Any())
                {
                    List<Record> prevday;
                    if (date != DateTime.MinValue)
                    {
                        prevday = await _context.Records
                        .Where(x => x.Time.Date == date.Date.AddDays(-7) && x.Group == group)
                        .ToListAsync();
                    }
                    else
                    {
                        prevday = await _context.Records
                        .Where(x => x.Time.Date == DateTime.Now.Date.AddDays(-7) && x.Group == group)
                        .ToListAsync();
                    }
                    if (prevday.Any())
                    {
                        _context.AddRange(prevday
                        .Select(x => { x.RecordID = 0; x.Time = x.Time.Date.AddDays(7); return x; })
                        );
                        await _context.SaveChangesAsync();
                    }
                }
                return View(await result.ToListAsync());
            }
            return Redirect("/");
        }

        // GET: Records/Create
        [Authorize(Roles = "Admin, Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Records/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordID,Time,Subject,Teacher,Auditorium,Group")] Record record)
        {
            if (ModelState.IsValid)
            {
                _context.Add(record);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(record);
        }

        // GET: Records/Edit/5
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Records.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordID,Time,Subject,Teacher,Auditorium,Group")] Record record)
        {
            if (id != record.RecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(record);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordExists(record.RecordID))
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
            return View(record);
        }

        [Authorize(Roles = "Admin, Teacher")]
        // GET: Records/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Records
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // POST: Records/Delete/5
        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var record = await _context.Records.FindAsync(id);
            _context.Records.Remove(record);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id)
        {
            return _context.Records.Any(e => e.RecordID == id);
        }
    }
}
