using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    internal class VideoConverter
    {
        internal VideoBO Convert(Video video) {
            return new VideoBO() {
                Genre = EGenreBO.Undefined,
                Id = video.Id,
                Name = video.Name
            };
        }

        internal Video Convert(VideoBO video) {
            return new Video() {
                Genre = EGenre.Undefined,
                Id = video.Id,
                Name = video.Name
            };
        }
    }
}
