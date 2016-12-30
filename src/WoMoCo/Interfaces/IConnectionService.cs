﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;

namespace WoMoCo.Interfaces
{
    public interface IConnectionService
    {
        void DeletingFriends(string uid, string cid);
        IEnumerable<UserConnection> GetAllFriends();
        IList<ApplicationUser> GetFriendsId(string id);
        void SavingFriends(UserConnection user);
    }
}