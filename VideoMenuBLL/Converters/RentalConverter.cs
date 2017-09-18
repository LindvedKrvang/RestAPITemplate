using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    internal class RentalConverter
    {
        public Rental Convert(RentalBO rental)
        {
            return new Rental
            {
                Id = rental.Id,
                From = rental.From,
                To = rental.To
            };
        }

        public RentalBO Convert(Rental rental)
        {
            return new RentalBO
            {
                Id = rental.Id,
                From = rental.From,
                To = rental.To
            };
        }
    }
}
