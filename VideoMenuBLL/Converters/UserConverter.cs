using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    internal class UserConverter
    {
        private readonly ProfileConverter _profileConverter = new ProfileConverter();

        public UserBO Convert(User user)
        {
            return new UserBO
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Profile = _profileConverter.Convert(user.Profile)
            };
        }

        public User Convert(UserBO user)
        {
            return new User
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Profile = _profileConverter.Convert(user.Profile)
            };
        }
    }
}
