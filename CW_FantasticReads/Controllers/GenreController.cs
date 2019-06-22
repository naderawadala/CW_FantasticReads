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
	public class GenreController : Controller
	{
		private GenreRepository genreRepository;
		public GenreController()
		{
			genreRepository = new GenreRepository();
		}
		public ActionResult Index()
		{
			List<Genre> allGenres = new List<Genre>();
			List<GenreViewModel> model = new List<GenreViewModel>();
			allGenres = genreRepository.GetAll();
			foreach(var genre in allGenres)
			{
				GenreViewModel genreViewModel = new GenreViewModel
				{
					Name = genre.Name,
					ID=genre.ID
				};
				model.Add(genreViewModel);
			}
			return View(model);
		}
		[HttpGet]
		public ActionResult Create()
		{
			CreateGenreViewModel model = new CreateGenreViewModel();
			return View(model);
		}
		[HttpPost]
		public ActionResult Create(CreateGenreViewModel model)
		{
			var genre = new Genre();
			genre.Name = model.Name;
			genreRepository.Create(genre);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Edit(int id=0)
		{
			Genre genre = genreRepository.GetByID(id);
			GenreViewModel model = new GenreViewModel();
			if(genre!=null)
			{
				model = new GenreViewModel();
				model.Name = genre.Name;
				model.ID = genre.ID;
			}
			return View(model);
		}
		[HttpPost]
		public ActionResult Edit(GenreViewModel genreEdit)
		{
			Genre dbGenre = genreRepository.GetByID(genreEdit.ID);
			if(dbGenre==null)
			{
				dbGenre = new Genre();
			}
			dbGenre.Name = genreEdit.Name;
			genreRepository.Save(dbGenre);
			
			return RedirectToAction("Index");
		}
		public ActionResult Delete(int id=0)
		{
			bool isDeleted = genreRepository.DeleteByID(id);
			if(isDeleted==false)
			{
				
			}
			else
			{
				
			}
			return RedirectToAction("Index");
		}
	}
}