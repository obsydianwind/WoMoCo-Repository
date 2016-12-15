﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Repositories;

namespace WoMoCo.Services
{
    public class CommService : ICommService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;

        //Get all Comms
        public IList<Comm> GetAllComms()
        {
            return _repo.Query<Comm>().ToList();
            
        }
        public Comm GetCommById(int id)
        {
            return _repo.Query<Comm>().Where(c => c.Id == id).FirstOrDefault();
        }
        public void SaveComm(Comm comm, string uid)
        {
            // get currently logged in user by uid to assign as SendingUser
            ApplicationUser currUser = _repo.Query<ApplicationUser>().Where(a => a.Id == uid).FirstOrDefault();
            //get the RecievingUser
            ApplicationUser recUser = _repo.Query<ApplicationUser>().Where(u => u.Id == comm.RecId).FirstOrDefault();
            comm.SendingUser = currUser;
            comm.RecId = recUser.Id;
            comm.ReceivingUser = recUser;
            comm.DateSent = DateTime.Now;

            if(comm.Id == 0)
            {
                _repo.Add(comm);
            }
            else
            {
                _repo.Update(comm);
            }
        }
        public void DeleteComm(int id)
        {
            Comm commToDelete = _repo.Query<Comm>().Where(c => c.Id == id).FirstOrDefault();
            _repo.Delete(commToDelete);
        }
        public CommService(IGenericRepository repo, UserManager<ApplicationUser> manager)
        {
            _repo = repo;
            _manager = manager;
        }
    }
}