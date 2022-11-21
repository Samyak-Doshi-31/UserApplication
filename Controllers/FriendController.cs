using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserApplication.Exception;
using UserApplication.Models;
using UserApplication.Repository;

namespace UserApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendController : ControllerBase
    {
        readonly IFriendRepository _friendRepository;
        public FriendController(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }
        [Route("GetAllFriendList")]
        [HttpGet]
        public ActionResult GetAllFriendList(int userId)
        {
            try
            {
                List<Friend> friendList = _friendRepository.GetAllFriendByUserId(userId);
                return Ok(friendList);
            }
            catch(System.Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("GetFriendById")]
        [HttpGet]
        public ActionResult GetFriendById(int friendId)
        {
            
                Friend friendList = _friendRepository.GetFriendByFriendId(friendId);
                return Ok(friendList);
                     
        }

        
        [HttpPost("AddFriend")]
        public ActionResult AddFriend(Friend friend)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    bool result = _friendRepository.AddFriend(friend);
                    if (result)
                    {
                        return Ok(result);
                    }
                }
                
            }
            catch (UserAlreadyExistsException ex)
            {
                return StatusCode(500, ex.Message);
            }
            return BadRequest();
        }

        [Route("DeleteFriend")]
        [HttpDelete]
        public ActionResult DeleteFriend(int friendId)
        {
            try
            {
                bool removeStatus = _friendRepository.DeleteFriend(friendId);
                if (removeStatus)
                {
                    return Ok(removeStatus);

                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return BadRequest();
        }

        [Route("EditFriend")]
        [HttpPut]
        public ActionResult EditFriend(Friend friend)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    bool updateStatus = _friendRepository.UpdateFriend(friend);
                    if (updateStatus)
                    {
                        return Ok(updateStatus);
                    }
                }
                
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return BadRequest();
        }
    }
}
