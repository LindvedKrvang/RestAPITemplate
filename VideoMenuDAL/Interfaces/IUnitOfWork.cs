using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Video> VideoRepository { get; }
        IRepository<Profile> ProfileRepository { get; }
        IRepository<User> UserRepository { get; }

        int Complete();
    }
}
