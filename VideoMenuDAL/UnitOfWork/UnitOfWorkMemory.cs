﻿using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;
using VideoMenuDAL.Interfaces;
using VideoMenuDAL.Repositories;

namespace VideoMenuDAL.UnitOfWork
{
    internal class UnitOfWorkMemory : IUnitOfWork
    {
        public IRepository<Video> VideoRepository { get; internal set; }
        public IRepository<Profile> ProfileRepository { get; internal set; }
        public IRepository<User> UserRepository { get; internal set; }
        public IRentalRepository RentalRepository { get; internal set; }
        public IRepository<Genre> GenreRepository { get; internal set; }

        private readonly VideoAppContext _context;

        public UnitOfWorkMemory(VideoAppContext context)
        {
            _context = context;
            VideoRepository = new VideoRepositoryInMemory(_context);
            ProfileRepository = new ProfileRepositoryInMemory(_context);
            UserRepository = new UserRepositoryInMemory(_context);
            RentalRepository = new RentalRepository(_context);
            GenreRepository = new GenreRepository(_context);
        }

        /// <summary>
        /// Call this method when the unitOfWork is ready to persist the data.
        /// If this method isn't called, none of the data is saved.
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Call this method to dispose of the connection to the repository.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
