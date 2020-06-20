using Ankhang_Bigshools.DTOs;
using Ankhang_Bigshools.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ankhang_Bigshools.Controllers
{
    public class FollowingsController : ApiController
    {
        public ApplicationDbContext _dbContext { get; set; }
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Follwings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");

            var folowing = new Follwing
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };

            _dbContext.Follwings.Add(folowing);
            _dbContext.SaveChanges();
            return Ok();


        }
    }
}

    

