using System;
using System.Collections.Generic;
using VideoMenuBLL;
using VideoMenuBLL.Services;
using VideoMenuDAL;
using Xunit;
using VideoMenuBLL.BusinessObjects;

namespace VideoMenuBLLTest
{
    public class VideoServiceTests
    {
        private readonly IService<VideoBO> _videoService;

        public VideoServiceTests()
        {
            IDalFacade dal = new DalFacade();
            _videoService = new VideoService(dal);
            _videoService.ClearAll();
        }

        private static readonly VideoBO TestVideo = new VideoBO()
        {
            Id = 5,
            Name = "Test",
            Genre = EGenreBO.Undefined
        };

        [Fact]
        public void VideoService_GetVideo_NotNull()
        {
            var videoCreated = _videoService.Create(TestVideo);
            var video = _videoService.GetOne(videoCreated.Id);

            Assert.NotNull(video);
        }

        [Fact]
        private void VideoService_GetAllVideos_Equal()
        {
            _videoService.Create(TestVideo);
            _videoService.Create(TestVideo);
            var result = _videoService.GetAll().Count;
            var expectedResult = 2;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        private void VideoService_CreateVideo_Contains()
        {
            var videoCreated = _videoService.Create(TestVideo);
            var videos = _videoService.GetAll();

            Assert.Contains(videoCreated, videos);
        }

        [Fact]
        private void VideoService_DeleteVideo_DoesNotContain()
        {
            var video1 = _videoService.Create(TestVideo);
            var video2 = _videoService.Create(TestVideo);

            _videoService.Delete(video2.Id);

            Assert.DoesNotContain(video2, _videoService.GetAll());
        }

        [Fact]
        private void VideoService_CreateAll_Contains()
        {
            var names = new List<VideoBO>(){new VideoBO(){Name = "Test1"}, new VideoBO(){Name = "Test2"}, new VideoBO(){Name = "Test3"}};
            var createdVideos = _videoService.CreateAll(names);

            var videosFromDb = _videoService.GetAll();

            Assert.Contains(createdVideos[0], videosFromDb);
            Assert.Contains(createdVideos[1], videosFromDb);
            Assert.Contains(createdVideos[2], videosFromDb);
        }
    }
}