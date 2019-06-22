using DataAccess;
using Repositories;
using CW_FantasticReads.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CW_FantasticReads.Helpers;

namespace CW_FantasticReads.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			BookRepository bookRepository = new BookRepository();
			List<Book> allBooks = bookRepository.GetRecent(9);
			HomeViewModel model = new HomeViewModel(allBooks);
			return View(model);
		}
		public ActionResult AccessDenied()
		{
			return View();
		}
		[CustomAuthenticated]
		public ActionResult Browse(string searchValue)
		{
			BookRepository bookRepository = new BookRepository();
			if(searchValue==null)
			{
				searchValue = "";
			}

			searchValue = searchValue.ToLower();

			List<Book> resultBooks = bookRepository.GetAll().
				Where(p => p.Name.ToLower().Contains(searchValue)).ToList();

			List<SearchViewModel> model = new List<SearchViewModel>();
			foreach(Book book in resultBooks)
			{
				SearchViewModel modelItem = new SearchViewModel(book);
				model.Add(modelItem);
			}
			return View(model);
		}
	}
}