using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Context
{
    internal class InMemoryContext : DbContext
    {
        private static readonly DbContextOptions<InMemoryContext> Options = 
            new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("TheDB").Options;

        public InMemoryContext() : base(Options)
        {
            
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
