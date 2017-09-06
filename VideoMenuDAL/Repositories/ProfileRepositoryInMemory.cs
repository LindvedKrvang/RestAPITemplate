using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repositories
{
    internal class ProfileRepositoryInMemory : IRepository<Profile>
    {
        private readonly InMemoryContext _context;

        public Profile Create(Profile profile)
        {
            throw new NotImplementedException();
        }

        public List<Profile> GetAll()
        {
            throw new NotImplementedException();
        }

        public Profile Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Profile> Search(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public Profile Delete(int idToRemove)
        {
            throw new NotImplementedException();
        }

        public void ClearAll()
        {
            throw new NotImplementedException();
        }
    }
}
