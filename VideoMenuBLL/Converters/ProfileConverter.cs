using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    class ProfileConverter
    {
        internal ProfileBO Convert(Profile profile)
        {
            return new ProfileBO()
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Address = profile.Address,
            };
        }

        internal Profile Convert(ProfileBO profile)
        {
            return new Profile()
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Address = profile.Address
            };
        }
    }
}
