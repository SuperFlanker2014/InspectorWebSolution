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
			AuthorId = docsExaminationTask.AuthorId;
			Number = docsExaminationTask.Number;
			Date = docsExaminationTask.Date.ToString(DateFormat);

			Title = docsExaminationTask.Title;
			CountMassVolume = docsExaminationTask.CountMassVolume;
			SafePackage = docsExaminationTask.SafePackage;
			DateReceipt = docsExaminationTask.DateReceipt.HasValue ? docsExaminationTask.DateReceipt.Value.ToString(DateFormat) : null;
			DateSampling = docsExaminationTask.DateSampling.HasValue ? docsExaminationTask.DateSampling.Value.ToString(DateFormat) : null;
			HasAppendix = docsExaminationTask.HasAppendix;
			ShouldReturn = docsExaminationTask.ShouldReturn ?? false;
			SamplingStandard = docsExaminationTask.SamplingStandard;
			SamplingPlace = docsExaminationTask.SamplingPlace;
			SamplingActorId = docsExaminationTask.SamplingActorId;
			ExamiationLaboratoryId = docsExaminationTask.ExamiationLaboratoryId;

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
					Comments = m.Comments,
					MethodItem = m.MethodItem,
					SampleCiphers = m.SampleCiphers
				}
			).ToArray();

			TaskCiphers = docsExaminationTask.DocsExaminationTasksCiphers.Select(m =>
				new DocsExaminationTasksCiphersViewModel()
				{
					Guid = m.Guid,
					TaskId = m.TaskId,
					Cipher = m.Cipher,
					SampleTitle = m.SampleTitle,
					WeightUnitId = m.WeightUnitId,
					Count = m.Count,
					Comments = m.Comments
				}
			).ToArray();
		}

		public Guid Guid { get; set; }
		public Guid AuthorId { get; set; }
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
		[DisplayName("Приложение с информ. об образцах")]
		public int? HasAppendix { get; set; }
		[DisplayName("Место отбора проб")]
		public string SamplingPlace { get; set; }
		[DisplayName("Отбор проб произвёл")]
		public Guid? SamplingActorId { get; set; }
		[DisplayName("Место проведения исследований")]
		public Guid? ExamiationLaboratoryId { get; set; }

		[DisplayName("Возврат")]
		public bool ShouldReturn { get; set; }

		public string Examinations { get; set; }
		public DocsExaminationTasksExaminationsViewModel[] TaskExaminations
		{
			get { return Examinations == null ? null : JsonConvert.DeserializeObject<DocsExaminationTasksExaminationsViewModel[]>(Examinations); }
			set { Examinations = JsonConvert.SerializeObject(value); }
		}

		public string Ciphers { get; set; }
		public DocsExaminationTasksCiphersViewModel[] TaskCiphers
		{
			get { return Ciphers == null ? null : JsonConvert.DeserializeObject<DocsExaminationTasksCiphersViewModel[]>(Ciphers); }
			set { Ciphers = JsonConvert.SerializeObject(value); }
		}
	}
}