using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Interfaces
{
    public interface IRentalRepository : IRepository<Rental>
    {
        List<Rental> SearchByVideoId(int videoId);
        List<Rental> SearchByUserId(int userId);
    }
}
