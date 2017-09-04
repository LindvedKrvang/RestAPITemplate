using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repositories
{
    internal class VideoRepositoryInMemory : IVideoRepository
    {
        private readonly InMemoryContext _context;

        private static int _id = 1;

        public VideoRepositoryInMemory(InMemoryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all videos in ht memoryDb.
        /// </summary>
        /// <returns></returns>
        public List<Video> GetVidoes()
        {
            return _context.Videos.ToList();
        }

        /// <summary>
        /// Gets the first video with the parsed id. Returns null if none is found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Video GetVideo(int id)
        {
            return _context.Videos.FirstOrDefault(v => v.Id == id);
        }

        /// <summary>
        /// Deletes the video with the parse id in the memoryDb.
        /// </summary>
        /// <param name="idToRemove"></param>
        /// <returns></returns>
        public Video DeleteVideo(int idToRemove)
        {
            var videoToDelete = _context.Videos.FirstOrDefault(v => v.Id == idToRemove);
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
        /// <param name="name"></param>
        /// <returns></returns>
        public Video CreateVideo(string name)
        {
            var video = new Video()
            {
                Id = _id++,
                Name = name,
                Genre = EGenre.Undefined
            };
            _context.Videos.Add(video);
            return video;
        }

        /// <summary>
        /// Search all videos if they contain the given searchQuery and returns any that match.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public List<Video> SearchVideos(string searchQuery)
        {
            int.TryParse(searchQuery, out int id);
            return _context.Videos.Where(v =>
                    v.Name.ToLower().Contains(searchQuery.ToLower())
                    || v.Id == id
                    || v.Genre.ToString().ToLower().Contains(searchQuery.ToLower()))
                .ToList();
        }
    }
}
