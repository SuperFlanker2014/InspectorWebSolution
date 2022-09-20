using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InspectorWeb.ModelsDB;
using InspectorWeb.ViewModels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InspectorWeb.Controllers
{
    public class SettingsController : Controller
    {
        private readonly InspectorWebDBContext _context;

        public SettingsController(InspectorWebDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            var settingsDb = await _context.Settings.SingleOrDefaultAsync(m => true);

            var view = new SettingsViewModel
            {
                LaboratoryDirector = settingsDb.LaboratoryDirector,
                LaboratoryDirectorTitle = settingsDb.LaboratoryDirectorTitle
            };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind("LaboratoryDirector,LaboratoryDirectorTitle")] SettingsViewModel settings)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var settingsDb = await _context.Settings.SingleOrDefaultAsync(m => true);

                    settingsDb.LaboratoryDirector = settings.LaboratoryDirector;
                    settingsDb.LaboratoryDirectorTitle = settings.LaboratoryDirectorTitle;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction("Index");
            }

            return View("Index", settings);
        }
    }
}
