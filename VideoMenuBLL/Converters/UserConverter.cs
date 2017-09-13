using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    public class UserConverter
    {
        public UserBO Convert(User user)
        {
            return new UserBO
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
        }

        public User Convert(UserBO user)
        {
            return new User
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
        }
    }
}
