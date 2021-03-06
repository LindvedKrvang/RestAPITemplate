﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuBLL.BusinessObjects
{
    public class ProfileBO : IComparable<ProfileBO>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public ProfileBO()
        {
            
        }

        public string FullName => $"{FirstName} {LastName}";

        public int CompareTo(ProfileBO other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var idComparison = Id.CompareTo(other.Id);
            if (idComparison != 0) return idComparison;
            var firstNameComparison = string.Compare(FirstName, other.FirstName, StringComparison.Ordinal);
            if (firstNameComparison != 0) return firstNameComparison;
            var lastNameComparison = string.Compare(LastName, other.LastName, StringComparison.Ordinal);
            if (lastNameComparison != 0) return lastNameComparison;
            return string.Compare(Address, other.Address, StringComparison.Ordinal);
        }
    }
}
