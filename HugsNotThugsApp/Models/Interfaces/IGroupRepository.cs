using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HugsNotThugsApp.Models
{
    public interface IGroupRepository
    {
        IQueryable<Group> GetPopularGroups();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        //A work around
        List<Group> NotPrivateOrOwner(User u);
        IQueryable<Group> SearchOnTerm(string term);
        void MakePublic(int GroupId);
    }
}