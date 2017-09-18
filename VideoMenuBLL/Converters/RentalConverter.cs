using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    internal class RentalConverter
    {
        private readonly UserConverter _userConverter = new UserConverter();
        private readonly VideoConverter _videoConverter = new VideoConverter();

        public Rental Convert(RentalBO rental)
        {
            if (rental == null) return null;

            return new Rental
            {
                Id = rental.Id,
                From = rental.From,
                To = rental.To,
                UserId = rental.UserId,
                VideoId = rental.VideoId,
                User = _userConverter.Convert(rental.User),
                Video = _videoConverter.Convert(rental.Video)
            };
        }

        public RentalBO Convert(Rental rental)
        {
            if (rental == null) return null;

            return new RentalBO
            {
                Id = rental.Id,
                From = rental.From,
                To = rental.To,
                UserId = rental.UserId,
                VideoId = rental.VideoId,
                User = _userConverter.Convert(rental.User),
                Video = _videoConverter.Convert(rental.Video)
            };
        }
    }
}
