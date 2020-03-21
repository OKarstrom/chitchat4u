using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class ChatVM
    {
        public List<ConnectionVM> Connections { get; set; }//All established connections
    }
}
