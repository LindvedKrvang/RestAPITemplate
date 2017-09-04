using System;
using System.Collections.Generic;
using System.Linq;
using VideoMenuBLL.BusinessObjects;
using VideoMenuBLL.Converters;
using VideoMenuDAL;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Services
{
    public class VideoService : IService<VideoBO>
    {
        private readonly VideoConverter _converter = new VideoConverter();
        private readonly IDalFacade _facade;

        public VideoService(IDalFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Receives a list of names and creates videos of them in the database.
        /// </summary>
        /// <param name="nameOfVideos"></param>
        /// <returns></returns>
        public List<VideoBO> CreateAll(List<string> nameOfVideos)
        {
            var videos = new List<Video>();
            using (var uow = _facade.UnitOfWork)
            {
                videos.AddRange(nameOfVideos.Select(nameOfVideo => uow.VideoRepository.CreateVideo(nameOfVideo)));
                uow.Complete();
            }
            return videos.Select(_converter.Convert).ToList();
        }

        /// <summary>
        /// Gets the vidoes from the database and returns them.
        /// </summary>
        /// <returns></returns>
        public List<VideoBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.VideoRepository.GetVidoes().Select(_converter.Convert).ToList();
            }
        }

        /// <summary>
        /// Gets the video that have the parsed id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VideoBO GetOne(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return _converter.Convert(uow.VideoRepository.GetVideo(id));
            }
        }

        /// <summary>
        /// Creates a new video in the database with the given name.
        /// </summary>
        public VideoBO Create(string nameOfEntity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var createdVideo = uow.VideoRepository.CreateVideo(nameOfEntity);
                uow.Complete();
                return _converter.Convert(createdVideo);
            }
        }

        /// <summary>
        /// Removes the video with the parsed ID form the database.
        /// </summary>
        /// <param></param>
        /// <param name="idOfVideo"></param>
        /// <returns></returns>
        public VideoBO Delete(int idOfVideo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var deletedVideo = uow.VideoRepository.DeleteVideo(idOfVideo);
                uow.Complete();
                return _converter.Convert(deletedVideo);
            }
        }

        /// <summary>
        /// Clears the Db of everything.
        /// </summary>
        public void ClearAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                uow.VideoRepository.ClearAll();
                uow.Complete();
            }
        }

        /// <summary>
        /// Finds the video witch mathces with the id of the parsed video. Then updates the video.
        /// </summary>
        /// <param name="video"></param>
        public void Update(VideoBO video)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var videoToEdit = uow.VideoRepository.GetVideo(video.Id);
                videoToEdit.Name = video.Name;
                uow.Complete();
            }
        }


        /// <summary>
        /// Search all videos from the database if their name contains the searchQuery.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public List<VideoBO> Search(string searchQuery)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.VideoRepository.SearchVideos(searchQuery).Select(_converter.Convert).ToList();
            }
        }

        
    }
}
