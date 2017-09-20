using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    internal class VideoConverter
    {

        internal VideoBO Convert(Video video)
        {
            if (video == null) return null;
            return new VideoBO()
            {
                Id = video.Id,
                Name = video.Name,
                GenreId = video.Id
            };
        }

        internal Video Convert(VideoBO video)
        {
            if (video == null) return null;
            return new Video()
            {
                Id = video.Id,
                Name = video.Name,
                GenreId = video.GenreId
            };
        }
    }
}