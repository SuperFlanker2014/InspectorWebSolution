using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InspectorWeb.ModelsDB;
using InspectorWeb.ViewModels;
using InspectorWeb.Classes;

namespace InspectorWeb.Controllers
{
    public class DocsExaminationTasksController : BaseController
    {
        private readonly InspectorWebDBContext context;
        private readonly IMapper mapper;

        public DocsExaminationTasksController(InspectorWebDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var directoryClass = typeof(DocsExaminationTasks);

            var properties = new List<DirectoryProperty>
            {
                new DirectoryProperty("number", directoryClass.DisplayName("Number"), "text"),
                new DirectoryProperty("date", directoryClass.DisplayName("Date"), "dateField"),
                new DirectoryProperty("authorId", directoryClass.DisplayName("AuthorId"), "select")
            };

            var directoryDropdowns = new Dictionary<string, string>()
            {
                { "authorId", "DirUsers" }
            };

            return View(new PlainDirectoryModel()
            {
                DirectoryName = "DocsExaminationTasks",
                Properties = properties,
                DirectoryDropdowns = directoryDropdowns,
                Access = DirectoryAccessRights.Delete,
                HeaderButtons = new List<CustomControlButton>
                {
                    new CustomControlButton("/DocsExaminationTasks/Create/", "Добавить", "jsgrid-button jsgrid-mode-button jsgrid-insert-mode-button")
                },
                ItemButtons = new List<CustomControlButton>
                {
                    new CustomControlButton("/DocsExaminationTasks/Edit/", "Изменить", "jsgrid-button jsgrid-edit-button")
                }
            });
        }

        public IActionResult Create()
        {
            PutSelectsData(null);

            var user = context.DirUsers.Where(u => u.Guid == UserGuid).Include(u => u.OrgGu).First();

            var numberQuery = context.DocsExaminationTasks
                    .Where(d => d.Author.FilialNumber == user.FilialNumber && d.Author.OrgGu.RegionNumber == user.OrgGu.RegionNumber);

            var view = new DocsExaminationTaskViewModel
            {
                Number = numberQuery.Any() ? numberQuery.Max(d => d.Number) + 1 : 1,
                Date = DateTime.Today.ToString(DocsExaminationTaskViewModel.DateFormat)
            };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ClientId,Number,Date,Title,CountMassVolume,SafePackage,DateReceipt,DateSampling,HasAppendix,ShouldReturn,OriginCountryId,DestinationCountryId,SamplingStandard,SamplingPlace,SamplingActor,SamplingProduction,ExamiationPlace,Examinations,Ciphers")]
            DocsExaminationTaskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var task = mapper.Map<DocsExaminationTaskViewModel, DocsExaminationTasks>(viewModel);
                task.Guid = Guid.NewGuid();
                task.AuthorId = UserGuid;

                task.DocsExaminationTasksExaminations = new List<DocsExaminationTasksExaminations>();
                foreach (var examModel in viewModel.TaskExaminations)
                {
                    var exam = mapper.Map<DocsExaminationTasksExaminationsViewModel, DocsExaminationTasksExaminations>(examModel);
                    exam.Guid = Guid.NewGuid();
                    exam.TaskId = task.Guid;
                    task.DocsExaminationTasksExaminations.Add(exam);
                }

                task.DocsExaminationTasksCiphers = new List<DocsExaminationTasksCiphers>();
                foreach (var cipherModel in viewModel.TaskCiphers)
                {
                    var cipher = mapper.Map<DocsExaminationTasksCiphersViewModel, DocsExaminationTasksCiphers>(cipherModel);
                    cipher.Guid = Guid.NewGuid();
                    cipher.TaskId = task.Guid;
                    task.DocsExaminationTasksCiphers.Add(cipher);
                }

                context.Add(task);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit), new { id = task.Guid });
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

            var docsExaminationTask = await context.DocsExaminationTasks
                .Include(d => d.Client)
                .Include(d => d.DestinationCountry)
                .Include(d => d.OriginCountry)
                .Include(d => d.SamplingProduction)
                .Include(d => d.DocsExaminationTasksExaminations)
                .Include(d => d.DocsExaminationTasksCiphers)
                .SingleOrDefaultAsync(d => d.Guid == id);

            if (docsExaminationTask == null)
            {
                return NotFound();
            }

            var viewModel = new DocsExaminationTaskViewModel(docsExaminationTask);

            PutSelectsData(viewModel);

            ViewData["Title"] = $"Задание на исследование #{viewModel.Number} от {viewModel.Date}";

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,
            [Bind("Guid,ClientId,Number,Date,Title,CountMassVolume,SafePackage,DateReceipt,DateSampling,HasAppendix,ShouldReturn,OriginCountryId,DestinationCountryId,SamplingStandard,SamplingPlace,SamplingActor,SamplingProduction,ExamiationPlace,Examinations,Ciphers,AuthorId")]
            DocsExaminationTaskViewModel viewModel)
        {
            if (id == null | id != viewModel.Guid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var task = mapper.Map<DocsExaminationTaskViewModel, DocsExaminationTasks>(viewModel);
                var taskExams = await context.DocsExaminationTasksExaminations
                    .AsNoTracking()
                    .Where(d => d.TaskId == task.Guid)
                    .ToListAsync();
                var taskCiphers = await context.DocsExaminationTasksCiphers
                    .AsNoTracking()
                    .Where(d => d.TaskId == task.Guid)
                    .ToListAsync();

                try
                {
                    context.Update(task);

                    // update TaskExaminations
                    {
                        var dbGuids = taskExams.Select(m => m.Guid).ToList();
                        var vmGuids = viewModel.TaskExaminations.Select(d => d.Guid).ToList();

                        var newExams = vmGuids.Except(dbGuids).ToList();
                        var deletedExams = dbGuids.Except(vmGuids).ToList();
                        var updatedExams = dbGuids.Intersect(vmGuids).ToList();

                        foreach (var item in viewModel.TaskExaminations.Where(te => newExams.Contains(te.Guid)))
                        {
                            item.Guid = Guid.NewGuid();
                            item.TaskId = task.Guid;
                            var exam = mapper.Map<DocsExaminationTasksExaminationsViewModel, DocsExaminationTasksExaminations>(item);

                            context.Add(exam);
                        }

                        foreach (var item in viewModel.TaskExaminations.Where(te => updatedExams.Contains(te.Guid)))
                        {
                            var exam = mapper.Map<DocsExaminationTasksExaminationsViewModel, DocsExaminationTasksExaminations>(item);
                            context.Update(exam);
                        }

                        foreach (var item in taskExams.Where(te => deletedExams.Contains(te.Guid)))
                        {
                            context.Remove(item);
                        }
                    }

                    // update TaskCiphers
                    {
                        var dbGuids = taskCiphers.Select(m => m.Guid).ToList();
                        var vmGuids = viewModel.TaskCiphers.Select(d => d.Guid).ToList();

                        var newExams = vmGuids.Except(dbGuids).ToList();
                        var deletedExams = dbGuids.Except(vmGuids).ToList();
                        var updatedExams = dbGuids.Intersect(vmGuids).ToList();

                        foreach (var item in viewModel.TaskCiphers.Where(te => newExams.Contains(te.Guid)))
                        {
                            item.Guid = Guid.NewGuid();
                            item.TaskId = task.Guid;
                            var exam = mapper.Map<DocsExaminationTasksCiphersViewModel, DocsExaminationTasksCiphers>(item);

                            context.Add(exam);
                        }

                        foreach (var item in viewModel.TaskCiphers.Where(te => updatedExams.Contains(te.Guid)))
                        {
                            var exam = mapper.Map<DocsExaminationTasksCiphersViewModel, DocsExaminationTasksCiphers>(item);
                            context.Update(exam);
                        }

                        foreach (var item in taskCiphers.Where(te => deletedExams.Contains(te.Guid)))
                        {
                            context.Remove(item);
                        }
                    }

                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocsExaminationTasksExists(viewModel.Guid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                //return RedirectToAction(nameof(Index));
            }

            PutSelectsData(viewModel);

            ViewData["Title"] = $"Задание на исследование #{viewModel.Number} от {viewModel.Date}";

            return View(viewModel);
        }

        public async Task<IActionResult> ViewerTask(Guid id)
        {
            var ds = await context.DocsExaminationTasks
                .Include(d => d.Client)
                .Include(d => d.DestinationCountry)
                .Include(d => d.OriginCountry)
                .Include(d => d.SamplingProduction)
                .Include(d => d.Author).ThenInclude(d => d.Laboratory)
                .Include(d => d.Author).ThenInclude(d => d.OrgGu)
                .Include(d => d.DocsExaminationTasksExaminations).ThenInclude(d => d.Examination)
                .Include(d => d.DocsExaminationTasksExaminations).ThenInclude(d => d.Method)
                .Include(d => d.DocsExaminationTasksExaminations).ThenInclude(d => d.User)
                .Include(d => d.DocsExaminationTasksCiphers).ThenInclude(d => d.WeightUnit)
                .FirstOrDefaultAsync(t => t.Guid == id);

            var report = new InspectorWeb.Reports.DocsExaminationTaskReport
            {
                DataSource = new List<DocsExaminationTasks> { ds }
            };

            ViewData["Title"] = $"Задание на исследования (испытания) № {ds.NumberText} от {ds.Date:dd.MM.yyyy} - печать";

            return View("Viewer", report);
        }

        public async Task<IActionResult> ViewerResult(Guid id)
        {
            var ds = await context.DocsExaminationTasks
                .Include(d => d.Client)
                .Include(d => d.DestinationCountry)
                .Include(d => d.OriginCountry)
                .Include(d => d.SamplingProduction)
                .Include(d => d.Author).ThenInclude(d => d.Laboratory)
                .Include(d => d.Author).ThenInclude(d => d.OrgGu)
                .Include(d => d.DocsExaminationTasksExaminations).ThenInclude(d => d.Examination)
                .Include(d => d.DocsExaminationTasksExaminations).ThenInclude(d => d.Method)
                .Include(d => d.DocsExaminationTasksExaminations).ThenInclude(d => d.User)
                .Include(d => d.DocsExaminationTasksCiphers).ThenInclude(d => d.WeightUnit)
                .FirstOrDefaultAsync(t => t.Guid == id);

            var report = new InspectorWeb.Reports.DocsExaminationResultReport
            {
                DataSource = new List<DocsExaminationTasks> { ds }
            };

            ViewData["Title"] = $"Протокол исследований (испытаний) № {ds.NumberText} от {ds.Date:dd.MM.yyyy} - печать";

            return View("Viewer", report);
        }

        private bool DocsExaminationTasksExists(Guid id)
        {
            return context.DocsExaminationTasks.Any(e => e.Guid == id);
        }

        private void PutSelectsData(DocsExaminationTaskViewModel viewModel)
        {
            var returnItems = new[]
            {
                new { value = true, text = "Да" },
                new { value = false, text = "Нет" }
            }.ToList();

            ViewData["Client"] = viewModel == null ?
                new SelectList(context.DocsClients, "Guid", "Name") :
                new SelectList(context.DocsClients, "Guid", "Name", viewModel.ClientId);
            ViewData["DestinationCountry"] = viewModel == null ?
                new SelectList(context.DirCountries, "Guid", "Title") :
                new SelectList(context.DirCountries, "Guid", "Title", viewModel.DestinationCountryId);
            ViewData["OriginCountry"] = viewModel == null ?
                new SelectList(context.DirCountries, "Guid", "Title") :
                new SelectList(context.DirCountries, "Guid", "Title", viewModel.OriginCountryId);
            ViewData["SamplingProduction"] = viewModel == null ?
                new SelectList(context.DirGoods, "Guid", "Title") :
                new SelectList(context.DirGoods, "Guid", "Title", viewModel.SamplingProductionId);
            ViewData["ShouldReturn"] = viewModel == null ?
                new SelectList(returnItems, "value", "text") :
                new SelectList(returnItems, "value", "text", viewModel.ShouldReturn);
        }
    }
}