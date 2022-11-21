using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using UserApplication.Context;
using UserApplication.Exception;
using UserApplication.Models;

namespace UserApplication.Repository
{
    public class FriendRepository:IFriendRepository
    {
        readonly UserApplicationDbContext _userDbContext;
        public FriendRepository(UserApplicationDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public List<Friend> GetAllFriendByUserId(int userId)
        {
            return _userDbContext.Friend.Where(u => u.UserRegisterId == userId).ToList();
            
        }
        public Friend GetFriendByFriendId(int friendId)
        {
            return _userDbContext.Friend.Where(u => u.FriendId == friendId).FirstOrDefault();
        }
        public Friend CheckFriendIfExists(string email,string mobileNumber)
        {
            return _userDbContext.Friend.Where(u =>u.FriendEmail==email &&u.FriendMobileNumber == mobileNumber).FirstOrDefault();
        }

        public bool AddFriend(Friend friend)
        {
            Friend checkFriend = CheckFriendIfExists(friend.FriendEmail,friend.FriendMobileNumber);
            if (checkFriend == null)
            {
                _userDbContext.Friend.Add(friend);
                _userDbContext.SaveChanges();
                return true;
            }
            
            else
            {
                throw new UserAlreadyExistsException($"Friend with {friend.FriendEmail} already exists");
            }
            
        }
        //public bool DeleteFriend(List<int> friendToBeDeletedList) 
        //{ 
        //    int resultCount = 0;
        //    bool finalResult = false;
        //    foreach(var friend in friendToBeDeletedList)
        //    {
        //        Friend getFriendId = GetFriendByFriendId(friend);
        //        _userDbContext.Friend.Remove(getFriendId);
                              
        //    }
        //    resultCount = _userDbContext.SaveChanges();
        //    if (resultCount==friendToBeDeletedList.Count)
        //    {
        //        return finalResult=true;
        //    }
        //    return finalResult;
        //}

        public bool DeleteFriend(int friendId)
        {
            Friend friend = GetFriendByFriendId(friendId);
            if(friend != null) 
            {
                _userDbContext.Friend.Remove(friend);
                return _userDbContext.SaveChanges() == 0 ? false : true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateFriend(Friend friend)
        {
                _userDbContext.Entry(friend).State = EntityState.Modified;
                return _userDbContext.SaveChanges()==0?false:true;
                         
        }
    }
}
