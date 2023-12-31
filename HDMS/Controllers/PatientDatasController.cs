using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HDMS.Data;
using HDMS.Models;

namespace HDMS.Controllers
{
    public class PatientDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientData.ToListAsync());
        }

        // GET: PatientDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientData = await _context.PatientData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientData == null)
            {
                return NotFound();
            }

            return View(patientData);
        }

        // GET: PatientDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,HeartRate,Steps,BPdyastolic,BPsystolic,Date")] PatientData patientData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientData);
        }

        // GET: PatientDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientData = await _context.PatientData.FindAsync(id);
            if (patientData == null)
            {
                return NotFound();
            }
            return View(patientData);
        }

        // POST: PatientDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,HeartRate,Steps,BPdyastolic,BPsystolic,Date")] PatientData patientData)
        {
            if (id != patientData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientDataExists(patientData.Id))
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
            return View(patientData);
        }

        // GET: PatientDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientData = await _context.PatientData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientData == null)
            {
                return NotFound();
            }

            return View(patientData);
        }

        // POST: PatientDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientData = await _context.PatientData.FindAsync(id);
            if (patientData != null)
            {
                _context.PatientData.Remove(patientData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientDataExists(int id)
        {
            return _context.PatientData.Any(e => e.Id == id);
        }
    }
}
