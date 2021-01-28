using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanSeans.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Authorization;

namespace BeanSeans.Areas.Administration
{
    [Area("Staff")]

    [Authorize(Roles = "Manager")]
    public class SittingController : AdministrationAreaController
    {
        public SittingController(SignInManager<IdentityUser> sim, UserManager<IdentityUser> um, ApplicationDbContext _db) : base(sim, um, _db)
        {

        }





        // GET: Administration/Sitting
        public async Task<IActionResult> Index()
        {


            var sittings = await _db.Sittings
                             .Include(s => s.Restuarant)
                             .Include(s => s.SittingType)
                             .Where(s => s.Start >= DateTime.Now)
                             .OrderBy(s => s.Id)
                             .ToListAsync();



            // var sittings = _db.Sittings.Include(s => s.Restuarant).Include(s => s.SittingType);

            return View(sittings);
        }

        // GET: Administration/Sitting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitting = await _db.Sittings
                .Include(s => s.Restuarant)
                .Include(s => s.SittingType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sitting == null)
            {
                return NotFound();
            }

            return View(sitting);
        }

        [HttpGet]
        // GET: Administration/Sitting/Create
        public async Task<IActionResult> Create()
        {
            
            var sittingTypes = await _db.SittingTypes.ToListAsync(); //pull the data first!
            ViewBag.SittingTypeId = new SelectList(sittingTypes, "Id", "Name");//collection , name of the prop== value/ name of display

            /*
              <label asp-for="SittingType.Name" class="control-label"></label>
                <select asp-for="SittingTypeId" class="form-control" asp-items="ViewBag.SittingTypeId"></select>
            
             //SittingTypeId: from Sitting Class
             */

            return View();
        }

        // POST: Administration/Sitting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SittingTypeId,Start,End,Capacity")] Sitting sitting)
        {
    
            if (ModelState.IsValid)
            { sitting.RestuarantId = 1;
                _db.Add(sitting);
                await _db.SaveChangesAsync();
                return 
                    RedirectToAction(nameof(Index));
            }
            //ViewData["RestuarantId"] = new SelectList(_db.Restuarants, "Id", "Id", sitting.RestuarantId);
            //       ViewBag.SittingTypeName = new SelectList(_db.SittingTypes, "Id", "Name");

            var sittingTypes = await _db.SittingTypes.ToListAsync(); //pull the data first!
            ViewBag.SittingTypeId = new SelectList(sittingTypes, "Id", "Name");//collection , name of the prop== value/ name of display

            return View(sitting);
        }

        // GET: Administration/Sitting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var sitting = await _db.Sittings.FindAsync(id);

            if (sitting == null)
            {
                return NotFound();
            }
            // ViewData["RestuarantId"] = new SelectList(_db.Restuarants, "Id", "Id", sitting.RestuarantId);
            
            var sittingTypes = await _db.SittingTypes.ToListAsync(); //pull the data first!
            ViewBag.SittingTypeId = new SelectList(sittingTypes, "Id", "Name");//collection , name of the prop== value/ name of display
            return View(sitting);
        }

        // POST: Administration/Sitting/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SittingTypeId,Id,Start,End,Capacity")] Sitting sitting)
        {
            if (id != sitting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sitting.RestuarantId = 1;
                    _db.Update(sitting);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SittingExists(sitting.Id))
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
            var sittingTypes = await _db.SittingTypes.ToListAsync(); //pull the data first!
            ViewBag.SittingTypeId = new SelectList(sittingTypes, "Id", "Name");//collection , name of the prop== value/ name of display
            return View(sitting);
        }

        // GET: Administration/Sitting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitting = await _db.Sittings
                .Include(s => s.Restuarant)
                .Include(s => s.SittingType)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (sitting == null)
            {
                return NotFound();
            }

            return View(sitting);
        }

        // POST: Administration/Sitting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sitting = await _db.Sittings
                                   .Include(s=>s.Reservations)
                                   .FirstOrDefaultAsync(s=>s.Id == id);

            _db.Sittings.Remove(sitting);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SittingExists(int id)
        {
            return _db.Sittings.Any(e => e.Id == id);
        }
    }
}
