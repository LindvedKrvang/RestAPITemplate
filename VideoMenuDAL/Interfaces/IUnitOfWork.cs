using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Entities;
using VideoMenuDAL.Interfaces;

namespace VideoMenuDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Video> VideoRepository { get; }
        IRepository<Profile> ProfileRepository { get; }
        IRepository<User> UserRepository { get; }
        IRentalRepository RentalRepository { get; }
        IRepository<Genre> GenreRepository { get; }

        int Complete();
    }
}
