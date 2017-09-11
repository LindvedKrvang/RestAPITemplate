﻿using VideoMenuBLL.BusinessObjects;
using VideoMenuBLL.Services;
using VideoMenuDAL;

namespace VideoMenuBLL
{
    public class BllFacade
    {
        public IService<VideoBO> VideoService => new VideoService(new DalFacade());
        public IService<ProfileBO> ProfileService => new ProfileService(new DalFacade());
    }
}
