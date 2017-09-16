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
        private readonly UserConverter _converter = new UserConverter();
        private readonly IDalFacade _facade;

        public UserService(IDalFacade facade)
        {
            _facade = facade;
        }

        public UserBO Create(UserBO entity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var userToCreate = uow.UserRepository.Create(_converter.Convert(entity));
                //var profiel = uow.ProfileRepository.Create()
                uow.Complete();
                return _converter.Convert(userToCreate);
            }
        }

        public List<UserBO> CreateAll(List<UserBO> entities)
        {
            var users = new List<User>();
            using (var uow = _facade.UnitOfWork)
            {
                users.AddRange(entities.Select(u => uow.UserRepository.Create(_converter.Convert(u))));
                uow.Complete();
            }
            return users.Select(_converter.Convert).ToList();
        }

        public List<UserBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.UserRepository.GetAll().Select(_converter.Convert).ToList();
            }
        }

        public UserBO GetOne(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return _converter.Convert(uow.UserRepository.Get(id));
            }
        }

        public List<UserBO> Search(string searchQuery)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.UserRepository.Search(searchQuery).Select(_converter.Convert).ToList();
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
                return _converter.Convert(userToEdit);
            }
        }

        public UserBO Delete(int idOfEntity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var userToDelete = uow.UserRepository.Delete(idOfEntity);
                uow.Complete();
                return _converter.Convert(userToDelete);
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
