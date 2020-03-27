using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InspectorWeb.ModelsDB;
using InspectorWeb.ViewModels;
using InspectorWeb.Classes;
using InspectorWeb.Classes.Metadata;

namespace InspectorWeb.Controllers
{
    public class DocsClientsController : Controller
    {
        private readonly InspectorWebDBContext _context;

        public DocsClientsController(InspectorWebDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
		{
			var directoryClass = typeof(DocsClients);

			var properties = new List<DirectoryProperty>
			{
				new DirectoryProperty("name", directoryClass.DisplayName("Name"), "text"),
				new DirectoryProperty("inn", directoryClass.DisplayName("Inn"), "text")
			};

			return View(new PlainDirectoryModel()
			{
				DirectoryName = "DocsClients",
				Properties = properties,
				//Access = DirectoryAccessRights.Delete,// | DirectoryAccessRights.Edit// | DirectoryAccessRights.Insert
				//HeaderButtons = new List<CustomControlButton>
				//{
				//	new CustomControlButton("/DocsClients/Create/", "Добавить", "jsgrid-button jsgrid-mode-button jsgrid-insert-mode-button")
				//},
				//ItemButtons = new List<CustomControlButton>
				//{ 
				//	new CustomControlButton("/DocsClients/Edit/", "Изменить", "jsgrid-button jsgrid-edit-button")
				//}				 
			});			
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docsClient = await _context.DocsClients
                .Include(d => d.BankGu)
                .Include(d => d.RegionGu)
                .Include(d => d.RegionRayonGu)
                .Include(d => d.TypeGu)
                .SingleOrDefaultAsync(m => m.Guid == id);

            if (docsClient == null)
            {
                return NotFound();
            }

            return View(docsClient);
        }

        public IActionResult Create()
        {
			PutSelectsData(null);

			return View();
        }
		
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
			[Bind("Name,Inn,Kpp,Adress,AdressFact,AdressWarehouse,Phone,RegionGuid,Representative,TypeGuid,FaceAgreement,BankGuid,BankAccount,RegionRayonGuid")] DocsClients docsClient)
        {
			if (ModelState.IsValid)
            {
				docsClient.Guid = Guid.NewGuid();
				docsClient.RegionGuid = docsClient?.RegionGuid == Guid.Empty ? null : docsClient?.RegionGuid;
				docsClient.RegionRayonGuid = docsClient?.RegionRayonGuid == Guid.Empty ? null : docsClient?.RegionRayonGuid;
				docsClient.Name = docsClient.Name.Trim();
				_context.Add(docsClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

			PutSelectsData(docsClient);

			return View(docsClient);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docsClient = await _context.DocsClients.SingleOrDefaultAsync(m => m.Guid == id);

            if (docsClient == null)
            {
                return NotFound();
            }

			PutSelectsData(docsClient);

			ViewData["Title"] = $"Редактирование клиента: {docsClient.Name}";

			return View(docsClient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
			Guid id, 
			[Bind("Guid,Name,Inn,Kpp,Adress,AdressFact,AdressWarehouse,Phone,RegionGuid,Representative,TypeGuid,FaceAgreement,BankGuid,BankAccount,RegionRayonGuid")] DocsClients docsClient)
        {
            if (id != docsClient.Guid)
            {
                return NotFound();
            }

			//docsClient.Validate();

            if (ModelState.IsValid)
            {
                try
                {
					docsClient.RegionGuid = docsClient?.RegionGuid == Guid.Empty ? null : docsClient?.RegionGuid;
					docsClient.RegionRayonGuid = docsClient?.RegionRayonGuid == Guid.Empty ? null : docsClient?.RegionRayonGuid;
					docsClient.Name = docsClient.Name.Trim();
					_context.Update(docsClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocsClientsExists(docsClient.Guid))
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

			ViewData["Title"] = $"Редактирование клиента: {docsClient.Name}";

			PutSelectsData(docsClient);

			return View(docsClient);
        }
        
        private bool DocsClientsExists(Guid id)
        {
            return _context.DocsClients.Any(e => e.Guid == id);
        }

		private void PutSelectsData(DocsClients client)
		{
			ViewData["TypeGuid"] = new SelectList(_context.DirClientTypes.OrderBy(i => i.Title), "Guid", "Title", client?.TypeGuid);

			var banks = _context.DirBanks.ToList();
			ViewData["BankGuid"] = new SelectList(banks.OrderBy(i => i.Title), "Guid", "Title", client?.BankGuid);

			var regions = _context.DirCountries.ToList();
			regions.Insert(0, new DirCountries { Guid = Guid.Empty, Title = string.Empty });
			ViewData["RegionGuid"] = new SelectList(regions.OrderBy(i => i.Title), "Guid", "Title", client?.RegionGuid);

			var regionRayons = _context.DirRegionsDistricts.ToList();
			regionRayons.Insert(0, new DirRegionsDistricts() { Guid = Guid.Empty, Title = string.Empty });
			ViewData["RegionRayonGuid"] = new SelectList(regionRayons.OrderBy(i => i.Title), "Guid", "Title", client?.RegionRayonGuid);			
		}
    }
}
