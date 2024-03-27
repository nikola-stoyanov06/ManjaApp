using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManjaApp.Data.Data;
using ManjaApp.Data.Entities;
using Services.Abstractions;

namespace ManjaApp.Web.Controllers
{
    public class ManjasController : Controller
    {
        private readonly IManjaService _manjaService;

        public ManjasController(IManjaService manjaService)
        {
            _manjaService = manjaService;
        }

        // GET: Manjas
        public async Task<IActionResult> Index()
        {
            return View(await _manjaService.GetManjasAsync());
        }

        // GET: Manjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manja = await _manjaService.GetManjaByIdAsync(id.Value);
            if (manja == null)
            {
                return NotFound();
            }

            return View(manja);
        }

        // GET: Manjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Duration,Instructions,Rating,Id")] Manja manja)
        {
            if (ModelState.IsValid)
            {
                
                await _manjaService.AddManjaAsync(manja);
                return RedirectToAction(nameof(Index));
            }
            return View(manja);
        }

        // GET: Manjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manja = await _manjaService.GetManjaByIdAsync(id.Value);
            if (manja == null)
            {
                return NotFound();
            }
            return View(manja);
        }

        // POST: Manjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Duration,Instructions,Rating,Id")] Manja manja)
        {
            if (id != manja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _manjaService.UpdateManjaAsync(manja);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ManjaExists(manja.Id))
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
            return View(manja);
        }

        // GET: Manjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manja = await _manjaService.GetManjaByIdAsync(id.Value);
            if (manja == null)
            {
                return NotFound();
            }

            return View(manja);
        }

        // POST: Manjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var manja = await _manjaService.GetManjaByIdAsync(id);
            if (manja != null)
            {
                await _manjaService.DeleteManjaByIdAsync(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ManjaExists(int id)
        {
            var manja = await _manjaService.GetManjaByIdAsync(id);
            return manja != null;
        }
    }
}
