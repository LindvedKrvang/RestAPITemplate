using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;
using VideoMenuBLL.Services;
using VideoMenuDAL;
using Xunit;

namespace VideoMenuBLLTest
{
    public class ProfileServiceTests
    {
        private readonly IService<ProfileBO> _service;

        public ProfileServiceTests()
        {
            IDalFacade facade = new DalFacade();
            _service = new ProfileService(facade);
            _service.ClearAll();
        }

        private static readonly ProfileBO TestProfile = new ProfileBO()
        {
            Id = 5,
            FirstName = "Jonathan",
            LastName = "Tester",
            Address = "TestDrive"
        };

        [Fact]
        private void ProfileService_Create_Contains()
        {
            var profileCreated = _service.Create(TestProfile);
            var allProfiles = _service.GetAll();

            Assert.Contains(profileCreated, allProfiles);
        }

        [Fact]
        private void ProfileService_CreateAll_Equal()
        {
            //var profiles = new List<ProfileBO>{TestProfile, TestProfile, TestProfile};
            //_service.CreateAll(profiles);
            //var expectedResult = 3;
            //var result = _service.GetAll().Count;

            //Assert.Equal(expectedResult, result);
        }

        [Fact]
        private void ProfileSerivce_GetAll_Equal()
        {
            //_service.Create(TestProfile);
            //_service.Create(TestProfile);
            //var expectedResult = 2;
            //var result = _service.GetAll().Count;

            //Assert.Equal(expectedResult, result);
        }

        [Fact]
        private void ProfileService_GetOne_NotNull()
        {
            var profileCreated = _service.Create(TestProfile);
            var result = _service.GetOne(profileCreated.Id);

            Assert.NotNull(result);
        }

        [Fact]
        private void ProfileService_Search_Equal()
        {
            var profileCreated = _service.Create(TestProfile);
            var searchOne = _service.Search(profileCreated.Id + "");
            var searchTwo = _service.Search(profileCreated.FirstName);
            var searchThree = _service.Search(profileCreated.LastName);
            var searchFour = _service.Search(profileCreated.FullName);
            var searchFive = _service.Search(profileCreated.Address);

            Assert.Equal(profileCreated, searchOne[0]);
            Assert.Equal(profileCreated, searchTwo[0]);
            Assert.Equal(profileCreated, searchThree[0]);
            Assert.Equal(profileCreated, searchFour[0]);
            Assert.Equal(profileCreated, searchFive[0]);
        }

        [Fact]
        private void ProfileService_Update_Equal()
        {
            var profileCreated = _service.Create(TestProfile);
            var profileBeforeUpdate = _service.GetOne(profileCreated.Id);

            Assert.Equal(profileCreated, profileBeforeUpdate);

            profileCreated.FirstName = "I have been updated";
            profileCreated.LastName = "Truly, I have";
            profileCreated.Address = "UpdatedDrive";
            _service.Update(profileCreated);

            var profileAfterUpdate = _service.GetOne(profileCreated.Id);

            Assert.Equal(profileCreated, profileAfterUpdate);
        }

        [Fact]
        private void ProfileService_Delete()
        {
            var profileCreated = _service.Create(TestProfile);
            var profiles = _service.GetAll();

            Assert.Contains(profileCreated, profiles);

            profileCreated = _service.Delete(profileCreated.Id);
            profiles = _service.GetAll();

            Assert.DoesNotContain(profileCreated, profiles);
        }
    }
}