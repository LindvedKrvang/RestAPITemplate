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
        private readonly RentalConverter _rentalConverter = new RentalConverter();
        private readonly UserConverter _userConverter = new UserConverter();
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
        public List<VideoBO> CreateAll(List<VideoBO> videoss)
        {
            var videos = new List<Video>();
            using (var uow = _facade.UnitOfWork)
            {
                videos.AddRange(videoss.Select(v => uow.VideoRepository.Create(_converter.Convert(v))));
                //videos.AddRange(nameOfVideos.Select(nameOfVideo => uow.VideoRepository.Create(_converter.Convert(new VideoBO(){Name = nameOfVideo}))));
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
                return uow.VideoRepository.GetAll().Select(_converter.Convert).ToList();
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
                var video = _converter.Convert(uow.VideoRepository.Get(id));
                video.Rentals = uow.RentalRepository.SearchByVideoId(video.Id).Select(_rentalConverter.Convert).ToList();
                video.Rentals.ForEach(v => v.User = _userConverter.Convert(uow.UserRepository.Get(v.UserId)));
                return video;
            }
        }

        /// <summary>
        /// Creates a new video in the database with the given name.
        /// </summary>
        public VideoBO Create(VideoBO video)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var createdVideo = uow.VideoRepository.Create(_converter.Convert(video));
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
                var deletedVideo = uow.VideoRepository.Delete(idOfVideo);
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
        public VideoBO Update(VideoBO video)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var videoToEdit = uow.VideoRepository.Get(video.Id);
                videoToEdit.Name = video.Name;
                uow.Complete();
                return _converter.Convert(videoToEdit);
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
                return uow.VideoRepository.Search(searchQuery).Select(_converter.Convert).ToList();
            }
        }

        
    }
}
