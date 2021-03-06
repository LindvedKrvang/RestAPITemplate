﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Context
{
    internal sealed class VideoAppContext : DbContext
    {
        private static readonly DbContextOptions<VideoAppContext> Options = 
            new DbContextOptionsBuilder<VideoAppContext>().UseInMemoryDatabase("TheDB").Options;

        private static readonly string DBConnectionPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DBConnection.txt");
        
        private readonly string _connectionString = File.ReadAllText(DBConnectionPath);

        public VideoAppContext() : base(Options)
        {

        }

        //public VideoAppContext()
        //{
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(_connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
