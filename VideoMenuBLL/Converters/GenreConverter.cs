using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    internal class GenreConverter
    {
        public GenreBO Convert(Genre genre)
        {
            if (genre == null) return null;
            return new GenreBO
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public Genre Convert(GenreBO genre)
        {
            if (genre == null) return null;
            return new Genre
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
    }
}
