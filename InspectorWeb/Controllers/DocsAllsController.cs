using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InspectorWeb.ModelsDB;

namespace InspectorWeb.Controllers
{
    public class DocsAllsController : Controller
    {
        private readonly InspectorWebDBContext _context;

        public DocsAllsController(InspectorWebDBContext context)
        {
            _context = context;
        }

        // GET: DocsAlls
        public async Task<IActionResult> Index()
        {
            var inspectorWebDBContext = _context.DocsAll.Include(d => d.DocClientGu).Include(d => d.DocParentGu).Include(d => d.DocUserGu);
            return View(await inspectorWebDBContext.ToListAsync());
        }

        // GET: DocsAlls/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docsAll = await _context.DocsAll
                .Include(d => d.DocClientGu)
                .Include(d => d.DocParentGu)
                .Include(d => d.DocUserGu)
                .SingleOrDefaultAsync(m => m.Guid == id);
            if (docsAll == null)
            {
                return NotFound();
            }

            return View(docsAll);
        }

        // GET: DocsAlls/Create
        public IActionResult Create()
        {
            ViewData["DocClientGuid"] = new SelectList(_context.DocsClients, "Guid", "Inn");
            ViewData["DocParentGuid"] = new SelectList(_context.DocsAll, "Guid", "Discriminator");
            ViewData["DocUserGuid"] = new SelectList(_context.DirUsers, "Guid", "Name");
            return View();
        }

        // POST: DocsAlls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Guid,DocParentGuid,Number,Date,DocUserGuid,DocClientGuid")] DocsAll docsAll)
        {
            if (ModelState.IsValid)
            {
                docsAll.Guid = Guid.NewGuid();
                _context.Add(docsAll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocClientGuid"] = new SelectList(_context.DocsClients, "Guid", "Inn", docsAll.DocClientGuid);
            ViewData["DocParentGuid"] = new SelectList(_context.DocsAll, "Guid", "Discriminator", docsAll.DocParentGuid);
            ViewData["DocUserGuid"] = new SelectList(_context.DirUsers, "Guid", "Name", docsAll.DocUserGuid);
            return View(docsAll);
        }

        // GET: DocsAlls/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docsAll = await _context.DocsAll.SingleOrDefaultAsync(m => m.Guid == id);
            if (docsAll == null)
            {
                return NotFound();
            }
            ViewData["DocClientGuid"] = new SelectList(_context.DocsClients, "Guid", "Inn", docsAll.DocClientGuid);
            ViewData["DocParentGuid"] = new SelectList(_context.DocsAll, "Guid", "Discriminator", docsAll.DocParentGuid);
            ViewData["DocUserGuid"] = new SelectList(_context.DirUsers, "Guid", "Name", docsAll.DocUserGuid);
            return View(docsAll);
        }

        // POST: DocsAlls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Guid,DocParentGuid,Number,Date,DocUserGuid,DocClientGuid")] DocsAll docsAll)
        {
            if (id != docsAll.Guid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docsAll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocsAllExists(docsAll.Guid))
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
            ViewData["DocClientGuid"] = new SelectList(_context.DocsClients, "Guid", "Inn", docsAll.DocClientGuid);
            ViewData["DocParentGuid"] = new SelectList(_context.DocsAll, "Guid", "Discriminator", docsAll.DocParentGuid);
            ViewData["DocUserGuid"] = new SelectList(_context.DirUsers, "Guid", "Name", docsAll.DocUserGuid);
            return View(docsAll);
        }

        // GET: DocsAlls/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docsAll = await _context.DocsAll
                .Include(d => d.DocClientGu)
                .Include(d => d.DocParentGu)
                .Include(d => d.DocUserGu)
                .SingleOrDefaultAsync(m => m.Guid == id);
            if (docsAll == null)
            {
                return NotFound();
            }

            return View(docsAll);
        }

        // POST: DocsAlls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var docsAll = await _context.DocsAll.SingleOrDefaultAsync(m => m.Guid == id);
            _context.DocsAll.Remove(docsAll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocsAllExists(Guid id)
        {
            return _context.DocsAll.Any(e => e.Guid == id);
        }
    }
}
