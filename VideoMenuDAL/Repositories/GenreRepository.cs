using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repositories
{
    internal class GenreRepository : IRepository<Genre>
    {
        private readonly VideoAppContext _context;

        public GenreRepository(VideoAppContext context)
        {
            _context = context;
        }

        public Genre Create(Genre entity)
        {
            _context.Genres.Add(entity);
            return entity;
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public Genre Get(int id)
        {
            return _context.Genres.FirstOrDefault(g => g.Id == id);
        }

        public List<Genre> Search(string searchQuery)
        {
            int.TryParse(searchQuery, out var id);
            return _context.Genres.Where(g => g.Id == id || g.Name.Contains(searchQuery)).ToList();
        }

        public Genre Delete(int idToRemove)
        {
            var genre = Get(idToRemove);
            _context.Genres.Remove(genre);
            return genre;
        }

        public void ClearAll()
        {
            var genres = GetAll();
            foreach (var genre in genres)
            {
                _context.Genres.Remove(genre);
            }
        }
    }
}
