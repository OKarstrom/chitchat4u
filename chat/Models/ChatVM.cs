using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class ChatVM
    {
        public string CurrentUserId { get; set; }
        public string CurrentFriendId { get; set; }
        public int SelectedConnection { get; set; } // connection whos messages are attached
        public List<ConnectionVM> Connections { get; set; }//All established connections
        public IList<MessageVM> Messages { get; set; }
    }
}
