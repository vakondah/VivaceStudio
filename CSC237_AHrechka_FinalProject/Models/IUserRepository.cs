﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public interface IUserRepository
    {
        // this property will be used only while working with mock repositories:
        User MyUser { get; }


        IEnumerable<User> GetUsers { get; }
        User GetUserById(int userId);
    }
}
