using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public interface IDataBaseRepository
    {
        List<ConnectionVM> GetAllConnections(string id);

        List<ApplicationUser> GetAllUsers();

        //List<string> GetConnectionDisplaynames

        Connection AddConnection(List<string> id);

        List<MessageVM> GetMessages(int chatId);

        int ChangeDisplayName(ApplicationUser user);

        Task SaveMessage(string Content, string senderID, int connectionID);

        List<ApplicationUser> GetAddableFriends(string userId);
        
    }
}
