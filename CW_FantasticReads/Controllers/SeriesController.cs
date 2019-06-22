using CW_FantasticReads.Helpers;
using CW_FantasticReads.Models;
using DataAccess;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CW_FantasticReads.Controllers
{
	[CustomAuthorize]
	public class SeriesController : Controller
	{
		private SeriesRepository seriesRepository;
		public SeriesController()
		{
			seriesRepository = new SeriesRepository();
		}
		public ActionResult Index()
		{
			List<Series> allSeries = new List<Series>();
			List<SeriesViewModel> model = new List<SeriesViewModel>();
			allSeries = seriesRepository.GetAll();
			foreach(var series in allSeries)
			{
				SeriesViewModel seriesViewModel = new SeriesViewModel()
				{
					Name = series.Name,
					ID = series.ID
				};
				model.Add(seriesViewModel);
			}
			return View(model);
		}
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(CreateSeriesViewModel model)
		{
			Series series = new Series
			{
				Name = model.Name
			};
			seriesRepository.Create(series);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Edit(int id = 0)
		{
			Series series = seriesRepository.GetByID(id);
			SeriesViewModel model = new SeriesViewModel();
			if (series != null)
			{
				model = new SeriesViewModel
				{
					Name = series.Name,
					ID = series.ID
				};
			}
			return View(model);
		}
		[HttpPost]
		public ActionResult Edit(SeriesViewModel seriesEdit)
		{
			Series dbSeries = seriesRepository.GetByID(seriesEdit.ID);
			if(dbSeries==null)
			{
			
				dbSeries = new Series();
			}
			dbSeries.Name = seriesEdit.Name;
			seriesRepository.Save(dbSeries);
			
			return RedirectToAction("Index");
		}
		public ActionResult Delete(int id=0)
		{
			bool isDeleted = seriesRepository.DeleteByID(id);
			return RedirectToAction("Index");
		}
	}
}