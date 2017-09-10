using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;
using VideoMenuBLL.Services;
using VideoMenuDAL;

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
    }
}
