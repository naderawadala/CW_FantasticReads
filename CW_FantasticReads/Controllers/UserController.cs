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
	public class UserController : Controller
	{
		private UserRepository userRepo = new UserRepository();
		public ActionResult Register()
		{
			RegisterViewModel model = new RegisterViewModel();
			return View(model);
		}
		[HttpPost]
		public ActionResult Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				User existingUser = userRepo.GetByName(model.Username);
				if (existingUser != null)
				{
					ModelState.AddModelError("", "This user is already registered in the system!");
					return View();
				}
				User dbUser = new User();
				dbUser.Username = model.Username;		
				userRepo.RegisterUser(dbUser, model.Password);
				userRepo.Save();
				TempData["Message"] = "User was successfully registered";
				return RedirectToAction("Index","Home");
			}
			else
			{
				return View();
			}
		}
		public ActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				User dbUser = userRepo.GetByNameAndPassword(model.Username, model.Password);
				bool isUserExists = dbUser != null;
				if (isUserExists)
				{
					LoginSession.Current.SetCurrentUser(dbUser.UserID, dbUser.Username, dbUser.IsAdmin);
					return RedirectToAction("Index","Home");
				}
				else
				{
					ModelState.AddModelError("", "Invalid username and/or password");
				}
			}
			return RedirectToAction("Index", "Home");
		}

		public ActionResult Logout()
		{
			LoginSession.Current.Logout();
			return RedirectToAction("Index","Home");
		}

		[CustomAuthorize]
		public ActionResult Index()
		{
			List<User> allUsers = userRepo.GetAll();
			List<UserViewModel> model = new List<UserViewModel>();
			foreach(User dbUser in allUsers)
			{
				UserViewModel userViewModel = new UserViewModel(dbUser);
				model.Add(userViewModel);
			}
			return View(model);
		}
		[CustomAuthorize]
		public ActionResult Delete(int id=0)
		{
			User user=userRepo.GetByID(id);
			if (user != null && user.IsAdmin==false)
			{
				bool isDeleted = userRepo.DeleteByID(id);

				if (isDeleted == false)
				{
					TempData["ErrorMessage"] = "Couldn't find a user";
				}
				else
				{
					TempData["Message"] = "Successfully deleted";
				}
			}
			else
			{
				TempData["ErrorMessage"] = "Cannot delete admins";
			}
			return RedirectToAction("Index");
		}
	}
}