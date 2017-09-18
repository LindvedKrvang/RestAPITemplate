using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuBLL.Converters;
using VideoMenuDAL;

namespace VideoMenuBLL.Services
{
    public class ProfileService : IService<ProfileBO>
    {
        private readonly ProfileConverter _converter = new ProfileConverter();
        private readonly IDalFacade _facade;

        public ProfileService(IDalFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Creates a profile.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ProfileBO Create(ProfileBO entity)
        {
            throw new InvalidOperationException();

            //using (var uow = _facade.UnitOfWork)
            //{
            //    var proflieCreated = uow.ProfileRepository.Create(_converter.Convert(entity));
            //    uow.Complete();
            //    return _converter.Convert(proflieCreated);
            //}
        }

        /// <summary>
        /// Creates all the profiles parsed.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public List<ProfileBO> CreateAll(List<ProfileBO> entities)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var profiles =  new List<ProfileBO>();
                foreach (var entity in entities)
                {
                    profiles.Add(_converter.Convert(uow.ProfileRepository.Create(_converter.Convert(entity))));
                }
                uow.Complete();
                return profiles;
            }
        }

        /// <summary>
        /// Get all the profiles from the database.
        /// </summary>
        /// <returns></returns>
        public List<ProfileBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.ProfileRepository.GetAll().Select(_converter.Convert).ToList();
            }
        }

        /// <summary>
        /// Get the profile with the parsed Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProfileBO GetOne(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return _converter.Convert(uow.ProfileRepository.Get(id));
            }
        }

        /// <summary>
        /// Returns all profiles with something that matches the searchQuery.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public List<ProfileBO> Search(string searchQuery)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.ProfileRepository.Search(searchQuery).Select(_converter.Convert).ToList();
            }
        }

        /// <summary>
        /// Updates the parsed profile in the database.
        /// </summary>
        /// <param name="entity"></param>
        public ProfileBO Update(ProfileBO entity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var profileToBeUpdated = uow.ProfileRepository.Get(entity.Id);
                profileToBeUpdated.FirstName = entity.FirstName;
                profileToBeUpdated.LastName = entity.LastName;
                profileToBeUpdated.Address = entity.Address;
                uow.Complete();
                return _converter.Convert(profileToBeUpdated);
            }
        }

        /// <summary>
        /// Deletes the parsed profile from the database.
        /// </summary>
        /// <param name="idOfEntity"></param>
        /// <returns></returns>
        public ProfileBO Delete(int idOfEntity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var profileDeleted = uow.ProfileRepository.Delete(idOfEntity);
                uow.Complete();
                return _converter.Convert(profileDeleted);
            }
        }

        /// <summary>
        /// THIS IS FOR UNITTESTING IN THE INMEMORY DATABASE!!! Clears the entire database for profiles.
        /// </summary>
        public void ClearAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                uow.ProfileRepository.ClearAll();
                uow.Complete();
            }
        }
    }
}
