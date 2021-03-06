﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repositories
{
    internal class VideoRepositoryInMemory : IRepository<Video>
    {
        private readonly VideoAppContext _context;


        public VideoRepositoryInMemory(VideoAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all videos in ht memoryDb.
        /// </summary>
        /// <returns></returns>
        public List<Video> GetAll()
        {
            return _context.Videos.ToList();
        }

        /// <summary>
        /// Gets the first video with the parsed id. Returns null if none is found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Video Get(int id)
        {
            return _context.Videos.FirstOrDefault(v => v.Id == id);
        }

        /// <summary>
        /// Deletes the video with the parse id in the memoryDb.
        /// </summary>
        /// <param name="idToRemove"></param>
        /// <returns></returns>
        public Video Delete(int idToRemove)
        {
            var videoToDelete = _context.Videos.FirstOrDefault(v => v.Id == idToRemove);
            if (videoToDelete == null) return null;
            _context.Videos.Remove(videoToDelete);
            return videoToDelete;
        }

        /// <summary>
        /// Clears the Db of all contents.
        /// </summary>
        public void ClearAll()
        {
            foreach (var video in _context.Videos)
            {
                _context.Videos.Remove(video);
            }
        }

        /// <summary>
        /// Creates a video in the memoryDb.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public Video Create(Video video)
        {
            _context.Videos.Add(video);
            return video;
        }

        /// <summary>
        /// Search all videos if they contain the given searchQuery and returns any that match.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public List<Video> Search(string searchQuery)
        {
            int.TryParse(searchQuery, out int id);
            return _context.Videos.Where(v =>
                    v.Name.ToLower().Contains(searchQuery.ToLower())
                    || v.Id == id)
                .ToList();
        }
    }
}
