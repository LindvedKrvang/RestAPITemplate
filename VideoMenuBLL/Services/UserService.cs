using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuBLL.Converters;
using VideoMenuDAL;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Services
{
    public class UserService : IService<UserBO>
    {
        private readonly UserConverter _userConverter = new UserConverter();
        private readonly ProfileConverter _profileConverter = new ProfileConverter();
        private readonly RentalConverter _rentalConverter = new RentalConverter();
        private readonly VideoConverter _videoConverter = new VideoConverter();
        private readonly IDalFacade _facade;

        public UserService(IDalFacade facade)
        {
            _facade = facade;
        }

        public UserBO Create(UserBO entity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var userToCreate = uow.UserRepository.Create(_userConverter.Convert(entity));
                uow.ProfileRepository.Create(new Profile() {FirstName = entity.Username});
                uow.Complete();
                return _userConverter.Convert(userToCreate);
            }
        }

        public List<UserBO> CreateAll(List<UserBO> entities)
        {
            var users = new List<User>();
            using (var uow = _facade.UnitOfWork)
            {
                users.AddRange(entities.Select(u => uow.UserRepository.Create(_userConverter.Convert(u))));
                //TODO RKL: Also create profiles here.
                uow.Complete();
            }
            return users.Select(_userConverter.Convert).ToList();
        }

        public List<UserBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                var users = uow.UserRepository.GetAll().Select(_userConverter.Convert).ToList();

                foreach (var user in users)
                {
                    user.Profile = _profileConverter.Convert(uow.ProfileRepository.Get(user.Id));
                }

                return users;
            }
        }

        public UserBO GetOne(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var user = _userConverter.Convert(uow.UserRepository.Get(id));
                if (user == null) return null;
                user.Profile = _profileConverter.Convert(uow.ProfileRepository.Get(user.Id));
                user.Rentals = uow.RentalRepository.SearchByUserId(user.Id).Select(_rentalConverter.Convert).ToList();
                user.Rentals.ForEach(r => r.Video = _videoConverter.Convert(uow.VideoRepository.Get(r.VideoId)));
                return user;
            }
        }

        public List<UserBO> Search(string searchQuery)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.UserRepository.Search(searchQuery).Select(_userConverter.Convert).ToList();
            }
        }

        public UserBO Update(UserBO entity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var userToEdit = uow.UserRepository.Get(entity.Id);
                userToEdit.Username = entity.Username;
                userToEdit.Password = entity.Password;
                uow.Complete();
                return _userConverter.Convert(userToEdit);
            }
        }

        public UserBO Delete(int idOfEntity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var userToDelete = uow.UserRepository.Delete(idOfEntity);
                uow.ProfileRepository.Delete(userToDelete.Id);
                var rentalsToDelete = uow.RentalRepository.SearchByUserId(userToDelete.Id);
                rentalsToDelete.ForEach(r => uow.RentalRepository.Delete(r.Id));
                uow.Complete();
                return _userConverter.Convert(userToDelete);
            }
        }

        public void ClearAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                uow.UserRepository.ClearAll();
                uow.Complete();
            }
        }
    }
}
