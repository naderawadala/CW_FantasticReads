using CW_FantasticReads.Helpers;
using CW_FantasticReads.Models;
using DataAccess;
using Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CW_FantasticReads.Controllers
{
	public class BookController : Controller
	{
		BookRepository bookRepository = new BookRepository();
		GenreRepository genreRepository = new GenreRepository();
		AuthorRepository authorRepository = new AuthorRepository();
		SeriesRepository seriesRepository = new SeriesRepository();
		public BookController()
		{
			bookRepository = new BookRepository();
		}
		// GET: Book
		[CustomAuthorize]
		public ActionResult Index()
		{
			List<Book> allBooks = bookRepository.GetAll();
			List<BookViewModel> model = new List<BookViewModel>();
			foreach(Book dbBook in allBooks)
			{
				BookViewModel bookViewModel = new BookViewModel(dbBook);
				model.Add(bookViewModel);
			}
			return View(model);
		}
		[HttpGet]
		[CustomAuthorize]
		public ActionResult Create()
		{
			var books = bookRepository.GetAll();
			var authors = authorRepository.GetAll();
			var genres = genreRepository.GetAll();
			var series = seriesRepository.GetAll();
			var bookSelectList = new SelectList(books, "ID", "Name");
			var authorSelectList = new SelectList(authors,"ID","Name");
			var genreSelectList = new SelectList(genres, "ID", "Name");
			var seriesSelectList = new SelectList(series, "ID", "Name");
			ViewBag.Books = bookSelectList;
			ViewBag.Genres = genreSelectList;
			ViewBag.Authors = authorSelectList;
			ViewBag.Series = seriesSelectList;
			return View(new CreateBookViewModel());
		}
		[HttpPost]
		[CustomAuthorize]
		public ActionResult Create(CreateBookViewModel model)
		{
			Book book = new Book
			{
				Name = model.Name,
				GenreID = model.Genre,
				AuthorID = model.Author,
				SeriesID = model.Series,
				Price = model.Price,
				Pages = model.Pages,
				ImageName = model.ImageName
			};
			if (Request.Files.Count > 0)
			{
				HttpPostedFileBase file = Request.Files[0];
				if (file.ContentLength != 0)
				{
					string imgPath = Server.MapPath(Constants.ImagesDirectory);
					string fileName = file.FileName;
					string savedFileName = Path.Combine(imgPath, Path.GetFileName(fileName));
					file.SaveAs(savedFileName);
					book.ImageName = fileName;
				}
				else
				{
					book.ImageName = Constants.NoCoverPath;
				}
			}
			bookRepository.Create(book);
			return RedirectToAction("Index");
		}
		public ActionResult Details(int id=0)
		{
			Book book = bookRepository.GetByID(id);
			if (book == null)
			{
				// couldn't find book
				return RedirectToAction("Index");
			}
			else
			{
				BookViewModel model = new BookViewModel(book);
				return View(model);
			}
		}
		[CustomAuthorize]
		[HttpGet]
		public ActionResult Edit(int id = 0)
		{
			Book dbBook = bookRepository.GetByID(id);
			if (dbBook==null)
			{
				return RedirectToAction("Index");
			}
			List<Author> allAuthors = authorRepository.GetAll();
			ViewBag.Authors = new SelectList(allAuthors, "ID", "Name");

			List<Series> allSeries = seriesRepository.GetAll();
			ViewBag.Series = new SelectList(allSeries, "ID", "Name");

			List<Genre> allGenres = genreRepository.GetAll();
			ViewBag.Genres = new SelectList(allGenres, "ID", "Name");

			List<Book> allBooks = bookRepository.GetAll();
			ViewBag.Books = new SelectList(allBooks, "ID", "Name");

			BookViewModel model = new BookViewModel();
			if(dbBook!=null)
			{
				model = new BookViewModel(dbBook);
			}
			return View(model);
		}
		[CustomAuthorize]
		[HttpPost]
		public ActionResult Edit(BookViewModel bookViewModel)
		{
			if(bookViewModel==null)
			{
				return RedirectToAction("Index");
			}
			BookRepository bookRepository = new BookRepository();
			Book dbBook = bookRepository.GetByID(bookViewModel.ID);
			if(dbBook==null)
			{
				dbBook = new Book();				
			}
			dbBook.ID = bookViewModel.ID;
			dbBook.Name = bookViewModel.Name;
			dbBook.GenreID = bookViewModel.Genre.ID;
			dbBook.AuthorID = bookViewModel.Author.ID;
			dbBook.SeriesID = bookViewModel.Series.ID;
			dbBook.Price = bookViewModel.Price;
			dbBook.Pages = bookViewModel.Pages;
			dbBook.ImageName = bookViewModel.ImageName;


			if (Request.Files.Count > 0)
			{
				HttpPostedFileBase file = Request.Files[0];
				if (file.ContentLength != 0)
				{
					string imgPath = Server.MapPath(Constants.ImagesDirectory);
					string fileName = file.FileName;
					string savedFileName = Path.Combine(imgPath, Path.GetFileName(fileName));
					file.SaveAs(savedFileName);
					dbBook.ImageName = fileName;
				}
			}
				bookRepository.Save(dbBook);
			return RedirectToAction("Index");
		}
		[CustomAuthorize]
		public ActionResult Delete(int id=0)
		{
			bool isDeleted = bookRepository.DeleteByID(id);
			if (isDeleted == false)
			{
				// couldn't find book
			}
			else
			{
				// successfully deleted
			}
			return RedirectToAction("Index");
		}
	}
}