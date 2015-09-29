using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HugsNotThugsApp.Models
{
    public interface IUserRepository
    {
        User GetUser();
        //User GetUser(int userProfileId);

        IQueryable GetPostsLoggedIn(string lat, string lon);
        IQueryable GetPostsNotLoggedIn(string lat, string lon);

        // Groups
        IQueryable<Group> GetSubscriptions();
        IQueryable<Group> GetOwnedGroups();
        IQueryable<Group> GetInvitedGroups();
        bool IsSubscribedTo(int gid);
        bool IsOwnerOf(int gid);

        // Blocks and Posts
        IQueryable<User> GetBlockedUsers();
        IQueryable<Post> GetBlockedPosts();
        IQueryable<Post> GetCreatedPosts();

        // Group Ownership
        void AddCreatedGroup(int groupId);
        void RemoveCreatedGroup(int groupId);

        // Group Subscriptions
        void AddSubscription(int groupId);
        void RemoveSubscription(int groupId);

        // User Blocks
        void BlockUser(string blockUserName);
        void UnBlockUser(string unblockUserName);

        // Post Blocks
        void BlockPost(int blockId);
        void UnBlockPost(int blockedId);

        // Moderator Priveleges
        void AllowUserSubscribeToGroup(int allowedUserId, int groupId);
        void BanUserFromGroup(int bannedUserId, int groupId);
        void GiveUserOwnership(int UserId, int GroupId);
        
        // CRUD
        //void ChangeDescription(string NewDescription); 
        void Add(User user);
        void Delete(User user);
        void Save();
    }
}