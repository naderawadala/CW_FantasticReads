using DataAccess;
using Repositories.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class UserRepository : BaseRepository<User>
	{
		public override void Save(User item)
		{
			if (item.UserID == 0)
			{
				base.Create(item);
			}
			else
			{
				base.Edit(item, f => f.UserID == item.UserID);
			}
		}
		public int Save()
		{
			return Context.SaveChanges();
		}
		public void RegisterUser(User user, string password)
		{
			string salt, hash;
			PasswordManager passwordManager = new PasswordManager();
			hash = passwordManager.GeneratePasswordHash(password, out salt);
			user.PasswordHash = hash;
			user.PasswordSalt = salt;
			base.Create(user);
		}
		public User GetByNameAndPassword(string username, string password)
		{
			User user = base.DbSet.FirstOrDefault(u => u.Username == username);
			if (user != null)
			{
				PasswordManager passwordManager = new PasswordManager();
				bool isValidPassword = passwordManager.IsPasswordMatch(password, user.PasswordHash, user.PasswordSalt);
				if (isValidPassword == false)
				{
					user = null;
				}
			}
			return user;
		}
		public User GetByName(string username)
		{
			User user = base.DbSet.FirstOrDefault(u => u.Username == username);
			return user;
		}
	}
}
