using Gatocan.Model;
using Microsoft.EntityFrameworkCore;

namespace Gatocan.Data
{
    public class UserEFRepository : IUserRepository
    {
        private readonly GatocanContext _context;

        public UserEFRepository(GatocanContext context)
        {
            _context = context;
        }

          public void AddUser(User user)
        {
            _context.Users.Add(user);
            SaveChanges();
        }

        public IEnumerable<User> GetAllUsers() 
        {
            var users = _context.Users;
            return users;
        }

        public User GetUserByEmail(string UserEmail)
        {
            var user = _context.Users.FirstOrDefault(user => user.Email == UserEmail);
            return user;
        }
        public User GetUserById(int UserId)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == UserId);
            return user;
        }


        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteUser(User userDelete) {
            var user = GetUserById(userDelete.Id);
            _context.Users.Remove(user);
            SaveChanges();
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }

}