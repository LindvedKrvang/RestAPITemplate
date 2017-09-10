using System;
using System.Collections.Generic;
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


        public ProfileBO Create(ProfileBO entity)
        {
            throw new NotImplementedException();
        }

        public List<ProfileBO> CreateAll(List<ProfileBO> entities)
        {
            throw new NotImplementedException();
        }

        public List<ProfileBO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProfileBO GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProfileBO> Search(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public void Update(ProfileBO video)
        {
            throw new NotImplementedException();
        }

        public ProfileBO Delete(int idOfVideo)
        {
            throw new NotImplementedException();
        }

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
