using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using AutoMapper;
using InspectorWeb.ModelsDB;

namespace InspectorWeb.ViewModels
{
	[DisplayName("Задания на испытания")]
	public class DocsExaminationTaskViewModel
	{
		public const string DateFormat = "dd.MM.yyyy";

		public DocsExaminationTaskViewModel()
		{

		}

		public DocsExaminationTaskViewModel(DocsExaminationTasks docsExaminationTask)
		{
			ClientId = docsExaminationTask.ClientId;
			DestinationCountryId = docsExaminationTask.DestinationCountryId;
			OriginCountryId = docsExaminationTask.OriginCountryId;
			SamplingProductionId = docsExaminationTask.SamplingProductionId;

			Guid = docsExaminationTask.Guid;
			Number = docsExaminationTask.Number;
			Date = docsExaminationTask.Date.HasValue ? docsExaminationTask.Date.Value.ToString(DateFormat) : null;
			Title = docsExaminationTask.Title;
			CountMassVolume = docsExaminationTask.CountMassVolume;
			SafePackage = docsExaminationTask.SafePackage;
			DateReceipt = docsExaminationTask.DateReceipt.HasValue ? docsExaminationTask.DateReceipt.Value.ToString(DateFormat) : null;
			DateSampling = docsExaminationTask.DateSampling.HasValue ? docsExaminationTask.DateSampling.Value.ToString(DateFormat) : null;
			HasAppendix = docsExaminationTask.HasAppendix;
			ShouldReturn = docsExaminationTask.ShouldReturn ?? false;
			SamplingStandard = docsExaminationTask.SamplingStandard;
			SamplingPlace = docsExaminationTask.SamplingPlace;
			SamplingActor = docsExaminationTask.SamplingActor;
			ExamiationPlace = docsExaminationTask.ExamiationPlace;

			TaskExaminations = docsExaminationTask.DocsExaminationTasksExaminations.Select(m =>
				new DocsExaminationTasksExaminationsViewModel()
				{
					Guid = m.Guid,
					TaskId = m.TaskId,
					ExaminationId = m.ExaminationId,
					MethodId = m.MethodId,
					ExaminationResult = m.ExaminationResult,
					EndDate = m.EndDate,
					UserId = m.UserId,
					Comments = m.Comments
				}
			).ToArray();
		}

		public Guid Guid { get; set; }

		[DisplayName("Номер")]
		public virtual int? Number { get; set; }
		[DisplayName("Дата")]
		public string Date { get; set; }

		[DisplayName("Заказчик")] 
		public Guid? ClientId { get; set; }
		[DisplayName("Место назначения")] 
		public Guid? DestinationCountryId { get; set; }
		[DisplayName("Происхождение")] 
		public Guid? OriginCountryId { get; set; }
		[DisplayName("Продукция")] 
		public Guid? SamplingProductionId { get; set; }

		[DisplayName("Наименование образца")] 
		public string Title { get; set; }
		[DisplayName("Количество/вес/объём образца")] 
		public string CountMassVolume { get; set; }
		[DisplayName("Номер сейф-пакента/пломбы/иной идентификатор")] 
		public string SafePackage { get; set; }

		[DisplayName("Дата отбора")]
		public string DateSampling { get; set; }
		[DisplayName("Дата поступления на исследование")]
		public string DateReceipt { get; set; }

		[DisplayName("Образец отобран согласно")] 
		public string SamplingStandard { get; set; }
		[DisplayName("Имеется приложение с информацией об образцах")] 
		public int? HasAppendix { get; set; }		
		[DisplayName("Место отбора проб")] 
		public string SamplingPlace { get; set; }
		[DisplayName("Отбор проб произвёл")] 
		public string SamplingActor { get; set; }
		[DisplayName("Место проведения исследований")] 
		public string ExamiationPlace { get; set; }

		[DisplayName("Подлежит возврату")] 
		public bool ShouldReturn { get; set; }

		public string Examinations { get; set; }

		public DocsExaminationTasksExaminationsViewModel[] TaskExaminations
		{
			get { return Examinations == null ? null : JsonConvert.DeserializeObject<DocsExaminationTasksExaminationsViewModel[]>(Examinations); }
			set { Examinations = JsonConvert.SerializeObject(value); }
		}
	}
}