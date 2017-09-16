using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repositories
{
    internal class ProfileRepositoryInMemory : IRepository<Profile>
    {
        private readonly InMemoryContext _context;


        public ProfileRepositoryInMemory(InMemoryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a profile in the InMemoryDatabase.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public Profile Create(Profile profile)
        {
            //var newProfile = new Profile()
            //{
            //    FirstName = profile.FirstName,
            //    LastName = profile.LastName,
            //    Address = profile.Address,
            //    UserId = profile.UserId
            //};
            _context.Profiles.Add(profile);
            return profile;
        }

        /// <summary>
        /// Returns all the profiles in the InMemoryDatabase.
        /// </summary>
        /// <returns></returns>
        public List<Profile> GetAll()
        {
            return _context.Profiles.ToList();
        }

        /// <summary>
        /// Returns a specific profile from the InMemoryDatabase, returns null if none is found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Profile Get(int id)
        {
            return _context.Profiles.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Returns a list of profiles that matches any part of the searchQuery, if any.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public List<Profile> Search(string searchQuery)
        {
            int.TryParse(searchQuery, out var id);
            return _context.Profiles.Where(p => p.Id == id
                    || searchQuery.ToLower().Contains(p.FirstName.ToLower())
                    || searchQuery.ToLower().Contains(p.LastName.ToLower())
                    || searchQuery.ToLower().Contains(p.Address.ToLower()))
                    .ToList();
        }

        /// <summary>
        /// Deletes the profile from the InMemoryDatabase with the parsed Id.
        /// </summary>
        /// <param name="idToRemove"></param>
        /// <returns></returns>
        public Profile Delete(int idToRemove)
        {
            var profileToDelete = _context.Profiles.FirstOrDefault(p => p.Id == idToRemove);
            if (profileToDelete == null) return null;
            _context.Profiles.Remove(profileToDelete);
            return profileToDelete;
        }

        /// <summary>
        /// Clears all profiles in the InMemoryDatabase. This is for unitTesting purpourse only!
        /// </summary>
        public void ClearAll()
        {
            foreach (var profile in _context.Profiles)
            {
                _context.Profiles.Remove(profile);
            }
        }
    }
}