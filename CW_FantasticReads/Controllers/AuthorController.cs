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
	public class AuthorController : Controller
	{
		private AuthorRepository authorRepository;
		public AuthorController()
		{
			authorRepository = new AuthorRepository();
		}

		// GET: Author
		public ActionResult Index()
		{
			List<Author> allAuthors = new List<Author>();

			List<AuthorViewModel> model = new List<AuthorViewModel>();
			allAuthors = authorRepository.GetAll();
			foreach (var author in allAuthors)
			{
				AuthorViewModel authorViewModel = new AuthorViewModel
				{
					Name = author.Name,
					ID = author.ID
				};
				model.Add(authorViewModel);
			}
			return View(model);
		}
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(CreateAuthorViewModel model)
		{
			Author author = new Author
			{
				Name = model.Name
			};
			authorRepository.Create(author);

			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Edit(int id = 0)
		{
			Author author = authorRepository.GetByID(id);

			AuthorViewModel model = new AuthorViewModel();
			if (author != null)
			{
				model = new AuthorViewModel();
				model.Name = author.Name;
				model.ID = author.ID;
			}
			return View(model);
		}
		[HttpPost]
		public ActionResult Edit(AuthorViewModel authorEdit)
		{
			Author dbAuthor = authorRepository.GetByID(authorEdit.ID);
			if (dbAuthor == null)
			{
				//create new author if none exists
				dbAuthor = new Author();
			}
			dbAuthor.Name = authorEdit.Name;
			authorRepository.Save(dbAuthor);

			return RedirectToAction("Index");
		}
		public ActionResult Delete(int id = 0)
		{
			bool isDeleted = authorRepository.DeleteByID(id);
			return RedirectToAction("Index");
		}
	}
}