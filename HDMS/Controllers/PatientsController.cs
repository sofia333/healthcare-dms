using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HDMS.Data;
using HDMS.Models;
using System.Net.NetworkInformation;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace HDMS.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patient.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .FirstOrDefaultAsync(m => m.Id == id);

            var patientData = _context.PatientData
                .Where(b => b.PatientId == id)
                .OrderBy(b => b.Date)
                .Select(b => new 
                { 
                    heartRate = b.HeartRate,
                    steps = b.Steps,
                    bpDyastolic = b.BPdyastolic,
                    bpSystolic = b.BPsystolic,
                    date = b.Date
                })
                .Take(7);

            PatientDashboard patientDashboard = new PatientDashboard();
            patientDashboard.HeartRateTrend = patientData.Select(a => a.heartRate).ToList();
            patientDashboard.StepsTrend = patientData.Select(a => a.steps).ToList();
            patientDashboard.BPdyastolicTrend = patientData.Select(a => a.bpDyastolic).ToList();
            patientDashboard.BPsystolicTrend = patientData.Select(a => a.bpSystolic).ToList();
            patientDashboard.HeartRateLatest = patientData.Select(a => a.heartRate).LastOrDefault();
            patientDashboard.StepsLatest = patientData.Select(a => a.steps).LastOrDefault();
            patientDashboard.BPdyastolicLatest = patientData.Select(a => a.bpDyastolic).LastOrDefault();
            patientDashboard.BPsystolicLatest = patientData.Select(a => a.bpSystolic).LastOrDefault();
            patientDashboard.Dates = patientData.Select(a => a.date).ToList();
            patientDashboard.Name = patient.Name;
            patientDashboard.Surname = patient.Surname;
            patientDashboard.BirthDate = patient.BirthDate;
            patientDashboard.Sex = patient.Sex;
            patientDashboard.Diagnosis = patient.Diagnosis;
            patientDashboard.LatestDate = patientData.Select(a => a.date).LastOrDefault();
            patientDashboard.PatientId = patient.Id;

            if (patient == null)
            {
                return NotFound();
            }

            return View(patientDashboard);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,BirthDate,BSN,Sex,Diagnosis")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,BirthDate,BSN,Sex,Diagnosis")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
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
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string GetNewData([FromBody] Dataex dataex)
        {
            var patientData = _context.PatientData
                .Where(b => b.PatientId == dataex.PatientId && b.Date <= dataex.Date && b.Date >= dataex.Date.AddDays(-6))
                .ToList();
                // Create json
                var NewData = new
            {
                HR = patientData.Last().HeartRate,
                steps = patientData.Last().Steps,
                BPd = patientData.Last().BPdyastolic,
                BPs = patientData.Last().BPsystolic,
                HRtrend = patientData.Select(b => b.HeartRate).ToList(),
                Strend = patientData.Select(b => b.Steps).ToList(),
                BPDtrend = patientData.Select(b => b.BPdyastolic).ToList(),
                BPStrend = patientData.Select(b => b.BPsystolic).ToList(),
                dates = patientData.Select(b => b.Date.ToString("MM/dd/yyyy")).ToList()
                };

            var json = JsonConvert.SerializeObject(NewData);
            Console.Write("success");

            return json;
        }
        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patient.FindAsync(id);
            if (patient != null)
            {
                _context.Patient.Remove(patient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.Patient.Any(e => e.Id == id);
        }
    }
}
