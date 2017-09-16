using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    internal class ProfileConverter
    {
        internal ProfileBO Convert(Profile profile)
        {
            if (profile == null) return null;

            return new ProfileBO()
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Address = profile.Address
            };
        }

        internal Profile Convert(ProfileBO profile)
        {
            if (profile == null) return null;

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
