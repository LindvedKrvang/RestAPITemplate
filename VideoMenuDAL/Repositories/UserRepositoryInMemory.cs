using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repositories
{
    internal class UserRepositoryInMemory : IRepository<User>
    {
        private readonly VideoAppContext _context;

        public UserRepositoryInMemory(VideoAppContext context)
        {
            _context = context;
        }

        public User Create(User entity)
        {
            _context.Users.Add(entity);
            return entity;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> Search(string searchQuery)
        {
            int.TryParse(searchQuery, out var id);
            return _context.Users.Where(u => u.Id == id 
                            || u.Username.Contains(searchQuery))
                            .ToList();
        }

        public User Delete(int idToRemove)
        {
            var userToDelete = Get(idToRemove);
            _context.Users.Remove(userToDelete);
            return userToDelete;
        }

        public void ClearAll()
        {
            foreach (var user in _context.Users)
            {
                _context.Users.Remove(user);
            }
        }
    }
}
