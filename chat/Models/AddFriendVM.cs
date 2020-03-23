using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class AddFriendVM
    {
        public AddFriendVM()
        {
            this.UserList = new List<ApplicationUser>();
            this.UserList.Add(new ApplicationUser() { Email = "No user in list", Id = "" });
        }

        public ApplicationUser SelectedUser { get; set; }
        public List<ApplicationUser> UserList { get; set; }
    }
}
