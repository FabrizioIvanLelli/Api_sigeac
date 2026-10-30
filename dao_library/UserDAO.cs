using dao_library;
using dao_library.entity_framework;
using entity_library;
using Microsoft.EntityFrameworkCore;


namespace dao_library.entity_framework
{
    public class UserDAO
    {
        private AppDbContext dbContext;

        public UserDAO(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User SaveUser(User user)
        {
            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();
            return user;
        }

        public User? GetUserById(long id)
        {
            return this.dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetUserEmail(string email)
        {
            return this.dbContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public bool UpdateUser(User user)
        {
            User? existingUser = this.dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null)
            {
                return false;
            }

            existingUser.Name = user.Name;
            existingUser.Dni = user.Dni;
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;
            return true;
        }
        public bool DeleteUserById(long id)
        {
            User? user = this.dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return false;
            }
            this.dbContext.Users.Remove(user);
            this.dbContext.SaveChanges();
            return true;
        }

    }
}
