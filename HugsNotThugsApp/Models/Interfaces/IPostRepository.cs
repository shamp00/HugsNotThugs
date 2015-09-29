using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HugsNotThugsApp.Models
{
    public interface IPostRepository
    {
        IQueryable<Post> FindAllPosts();
        IQueryable<Post> FindNearbyPosts(decimal lat, decimal lon);
        IQueryable<Post> FindPostByGroup(int groupId);

        Post GetPost(int id);

        void Add(Post post);
        void Delete(Post post);

        void Save();
    }
}