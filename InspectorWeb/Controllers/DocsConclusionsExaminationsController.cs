using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InspectorWeb.ModelsDB;
using InspectorWeb.Classes.Metadata;
using InspectorWeb.ViewModels;
using AutoMapper;

namespace InspectorWeb.Controllers
{
	public class DocsConclusionsExaminationsController : BaseController
	{
		private InspectorWebDBContext DataContext { get; }
		private IMapper Mapper;

		public DocsConclusionsExaminationsController(InspectorWebDBContext context, IMapper mapper)
		{
			DataContext = context;
			Mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var inspectorWebDBContext = DataContext.DocsConclusionsExamination
				.Include(d => d.Gu)
				.Include(d => d.InvoiceTypeGu)
				.Include(d => d.TargetOrSourceGu)
				.Include(d => d.TransportTypeGu);

			return View(await inspectorWebDBContext.ToListAsync());
		}

		public IActionResult Create()
		{
			ViewData["InvoiceTypeGuid"] = new SelectList(DataContext.DirInvoiceTypes.OrderBy(d => d.Title), "Guid", "Title", null);
			ViewData["TargetOrSourceGuid"] = new SelectList(DataContext.DirCountries.OrderBy(d => d.Title), "Guid", "Title", null);
			ViewData["TransportTypeGuid"] = new SelectList(DataContext.DirTransportTypes.OrderBy(d => d.Title), "Guid", "Title", null);

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(
			[Bind("Number,Date,TransportTypeGuid,TransportNumber,InvoiceTypeGuid,InvoiceNumber,InvoiceDate,SertNumber,SertFrom,TargetOrSource,FactAddress,KarantinSertNumber,KarantinSertDate,TargetOrSourceGuid,Goods")]
			DocsConclusionsExaminationViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var guid = Guid.NewGuid();
				var docsConclusionsExamination = new DocsConclusionsExamination
				{
					Guid = guid,
					Gu = new DocsWithGoods
					{
						Guid = guid,
						Gu = new DocsAll
						{
							Guid = guid,
							Number = viewModel.Number,
							Date = viewModel.Date,
							DocUserGuid = Guid.Parse("081ed3f8-6d6e-45f4-8d29-5d05f6d92703"),
							DocClientGuid = Guid.Parse("7cd7504d-ea7b-4264-b0d0-004929bd8d51"),
						},
						DocsGoods = new List<DocsGoods>()
					},
					TransportTypeGuid = viewModel.TransportTypeGuid,
					TransportNumber = viewModel.TransportNumber,
					InvoiceTypeGuid = viewModel.InvoiceTypeGuid,
					InvoiceNumber = viewModel.InvoiceNumber,
					InvoiceDate = viewModel.InvoiceDate,
					SertNumber = viewModel.SertNumber,
					SertFrom = viewModel.SertFrom,
					TargetOrSource = viewModel.TargetOrSource,
					FactAddress = viewModel.FactAddress,
					KarantinSertNumber = viewModel.KarantinSertNumber,
					KarantinSertDate = viewModel.KarantinSertDate,
					TargetOrSourceGuid = viewModel.TargetOrSourceGuid
				};

				foreach (var docGood in viewModel.DocsGoods)
				{
					var goodGuid = Guid.NewGuid();
					
					var good = new DocsGoods
					{
						Guid = goodGuid,
						DocGuid = guid,
						GoodGuid = docGood.GoodGuid,
						Places = docGood.Places,
						PlacesUnitGuid = docGood.PlacesUnitGuid,
						ProductionCountryGuid = docGood.ProductionCountryGuid,
						SamplesCount = docGood.SamplesCount,
						Weight = docGood.Weight,
						WeightUnitGuid = docGood.WeightUnitGuid,
						DocsGoodsDiseases = new List<DocsGoodsDiseases>()
					};

					foreach (var docGoodDiseas in docGood.Diseases)
					{
						var diseasGuid = Guid.NewGuid();

						var diseas = new DocsGoodsDiseases
						{
							Guid = diseasGuid,
							Count = docGoodDiseas.Count,
							CountGuid = docGoodDiseas.CountGuid,
							DiaseaseGuid = docGoodDiseas.DiaseaseGuid,
							DiaseaseStateGuid = docGoodDiseas.DiaseaseStateGuid
						};

						good.DocsGoodsDiseases.Add(diseas);
					}

					docsConclusionsExamination.Gu.DocsGoods.Add(good);
				}

				DataContext.Add(docsConclusionsExamination);
				await DataContext.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}
			
			PutSelectsData(viewModel);

			return View(viewModel);
		}

		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var docsConclusionsExamination = await DataContext.DocsConclusionsExamination
				.Include(m => m.Gu.Gu)
				.Include(m => m.Gu.DocsGoods).ThenInclude(dg => dg.DocsGoodsDiseases)
				.SingleOrDefaultAsync(m => m.Guid == id);

			if (docsConclusionsExamination == null)
			{
				return NotFound();
			}

			var viewModel = new DocsConclusionsExaminationViewModel(docsConclusionsExamination);

			ViewData["Title"] = $"Редактирование заключения № {viewModel.Number} от {viewModel.Date:dd.MM.yyy}";

			PutSelectsData(viewModel);

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id,
			[Bind("Guid,Number,Date,TransportTypeGuid,TransportNumber,InvoiceTypeGuid,InvoiceNumber,InvoiceDate,SertNumber,SertFrom,TargetOrSource,FactAddress,KarantinSertNumber,KarantinSertDate,TargetOrSourceGuid,Goods")]
			DocsConclusionsExaminationViewModel viewModel)
		{
			if (id == null | id != viewModel.Guid)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				var docsConclusionsExamination = await DataContext.DocsConclusionsExamination
					.Include(m => m.Gu.Gu)
					.Include(m => m.Gu.DocsGoods).ThenInclude(dg => dg.DocsGoodsDiseases)
					//.AsNoTracking()
					.SingleOrDefaultAsync(m => m.Guid == id);

				var docsConclusionsExaminationEdited = Mapper.Map<DocsConclusionsExaminationViewModel, DocsConclusionsExamination>(viewModel, docsConclusionsExamination);

				//docsConclusionsExaminationEdited.Gu.Gu.DocUserGuid = docsConclusionsExamination.Gu.Gu.DocUserGuid;
				//docsConclusionsExaminationEdited.Gu.Gu.DocClientGuid = docsConclusionsExamination.Gu.Gu.DocClientGuid;

				//перебрать вглубину, но сохранять в обратном порядке

				try
				{
					//DataContext.UpdateRange(docsConclusionsExamination.Gu.DocsGoods);
					DataContext.Update(docsConclusionsExamination);
					await DataContext.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					/*
					 InvalidOperationException: The instance of entity type 'DocsGoods' cannot be tracked because another instance with the same key value for {'Guid'} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the conflicting key values.
					 */
					if (!DataContext.DocsConclusionsExamination.Any(e => e.Guid == docsConclusionsExamination.Guid))
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

			PutSelectsData(viewModel);

			return View(viewModel);
		}

		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var docsConclusionsExamination = await DataContext.DocsConclusionsExamination
				.Include(d => d.Gu)
				.Include(d => d.InvoiceTypeGu)
				.Include(d => d.TargetOrSourceGu)
				.Include(d => d.TransportTypeGu)
				.SingleOrDefaultAsync(m => m.Guid == id);

			if (docsConclusionsExamination == null)
			{
				return NotFound();
			}

			return View(docsConclusionsExamination);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var docsConclusionsExamination = await DataContext.DocsConclusionsExamination
				.Include(d => d.Gu)
				.Include(d => d.Gu.DocsGoods).ThenInclude(d => d.DocsGoodsDiseases)
				.Include(d => d.Gu.Gu)
				.SingleOrDefaultAsync(m => m.Guid == id);

			foreach (var good in docsConclusionsExamination.Gu.DocsGoods)
			{
				DataContext.RemoveRange(good.DocsGoodsDiseases);
			}

			DataContext.RemoveRange(docsConclusionsExamination.Gu.DocsGoods);

			DataContext.Remove(docsConclusionsExamination);
			DataContext.Remove(docsConclusionsExamination.Gu);
			DataContext.Remove(docsConclusionsExamination.Gu.Gu);

			DataContext.SaveChanges();

			return RedirectToAction(nameof(Index));
		}

		private void PutSelectsData(DocsConclusionsExaminationViewModel viewModel)
		{
			ViewData["InvoiceTypeGuid"] = new SelectList(DataContext.DirInvoiceTypes.OrderBy(d => d.Title), "Guid", "Title", viewModel.InvoiceTypeGuid);
			ViewData["TargetOrSourceGuid"] = new SelectList(DataContext.DirCountries.OrderBy(d => d.Title), "Guid", "Title", viewModel.TargetOrSourceGuid);
			ViewData["TransportTypeGuid"] = new SelectList(DataContext.DirTransportTypes.OrderBy(d => d.Title), "Guid", "Title", viewModel.TransportTypeGuid);
		}
	}
}


//var guid = Guid.NewGuid();
//var docsConclusionsExamination = new DocsConclusionsExamination
//{
//	Guid = guid,
//	Gu = new DocsWithGoods
//	{
//		Guid = guid,
//		Gu = new DocsAll
//		{
//			Guid = guid,
//			Number = viewModel.Number,
//			Date = viewModel.Date,
//			DocUserGuid = Guid.Parse("081ed3f8-6d6e-45f4-8d29-5d05f6d92703"),
//			DocClientGuid = Guid.Parse("7cd7504d-ea7b-4264-b0d0-004929bd8d51"),
//		},
//		DocsGoods = new List<DocsGoods>()
//	},
//	TransportTypeGuid = viewModel.TransportTypeGuid,
//	TransportNumber = viewModel.TransportNumber,
//	InvoiceTypeGuid = viewModel.InvoiceTypeGuid,
//	InvoiceNumber = viewModel.InvoiceNumber,
//	InvoiceDate = viewModel.InvoiceDate,
//	SertNumber = viewModel.SertNumber,
//	SertFrom = viewModel.SertFrom,
//	TargetOrSource = viewModel.TargetOrSource,
//	FactAddress = viewModel.FactAddress,
//	KarantinSertNumber = viewModel.KarantinSertNumber,
//	KarantinSertDate = viewModel.KarantinSertDate,
//	TargetOrSourceGuid = viewModel.TargetOrSourceGuid
//};

//foreach (var docGood in viewModel.DocsGoods)
//{
//	var goodGuid = Guid.NewGuid();

//	var good = new DocsGoods
//	{
//		Guid = goodGuid,
//		DocGuid = guid,
//		GoodGuid = docGood.GoodGuid,
//		Places = docGood.Places,
//		PlacesUnitGuid = docGood.PlacesUnitGuid,
//		ProductionCountryGuid = docGood.ProductionCountryGuid,
//		SamplesCount = docGood.SamplesCount,
//		Weight = docGood.Weight,
//		WeightUnitGuid = docGood.WeightUnitGuid,
//		DocsGoodsDiseases = new List<DocsGoodsDiseases>()
//	};

//	foreach (var docGoodDiseas in docGood.Diseases)
//	{
//		var diseasGuid = Guid.NewGuid();

//		var diseas = new DocsGoodsDiseases
//		{
//			Guid = diseasGuid,
//			Count = docGoodDiseas.Count,
//			CountGuid = docGoodDiseas.CountGuid,
//			DiaseaseGuid = docGoodDiseas.DiaseaseGuid,
//			DiaseaseStateGuid = docGoodDiseas.DiaseaseStateGuid
//		};

//		good.DocsGoodsDiseases.Add(diseas);
//	}

//	docsConclusionsExamination.Gu.DocsGoods.Add(good);
//}