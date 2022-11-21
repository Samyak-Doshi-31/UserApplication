using System.Collections.Generic;
using UserApplication.Models;

namespace UserApplication.Repository
{
    public interface IFriendRepository
    {
        public List<Friend> GetAllFriendByUserId(int userId);
        public Friend GetFriendByFriendId(int friendId);
        public Friend CheckFriendIfExists(string email, string mobileNumber);
        public bool AddFriend(Friend friend);
        public bool DeleteFriend(int friendId);
        public bool UpdateFriend(Friend friend);
    }
}
