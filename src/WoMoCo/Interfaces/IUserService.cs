﻿using System.Collections.Generic;
using WoMoCo.Models;
using WoMoCo.ViewModels.Account;

namespace WoMoCo.Services
{
    public interface IUserService
    {
        void DeleteUser(string id);
        List<ApplicationUser> GetAllUsers();
        ApplicationUser GetByUsername(string uid);
        ApplicationUser GetUserById(string id);
        void SaveUser(ApplicationUser user);
    }
}