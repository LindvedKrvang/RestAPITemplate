﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;
using VideoMenuDAL.Interfaces;

namespace VideoMenuDAL.Repositories
{
    internal class RentalRepository : IRentalRepository
    {
        private readonly VideoAppContext _context;

        public RentalRepository(VideoAppContext context)
        {
            _context = context;
        }

        public Rental Create(Rental entity)
        {
            _context.Rentals.Add(entity);
            return entity;
        }

        public List<Rental> GetAll()
        {
            return _context.Rentals.ToList();
        }

        public Rental Get(int id)
        {
            return _context.Rentals.FirstOrDefault(r => r.Id == id);
        }

        public List<Rental> Search(string searchQuery)
        {
            int.TryParse(searchQuery, out var id);
            return _context.Rentals.Where(r => r.Id == id).ToList();
        }

        public Rental Delete(int idToRemove)
        {
            var retanlToRemove = Get(idToRemove);
            _context.Rentals.Remove(retanlToRemove);
            return retanlToRemove;
        }

        public void ClearAll()
        {
            foreach (var rental in _context.Rentals)
            {
                _context.Rentals.Remove(rental);
            }
        }

        public List<Rental> SearchByVideoId(int videoId)
        {
            return _context.Rentals.Where(r => r.VideoId == videoId).ToList();
        }

        public List<Rental> SearchByUserId(int userId)
        {
            return _context.Rentals.Where(r => r.UserId == userId).ToList();
        }
    }
}
