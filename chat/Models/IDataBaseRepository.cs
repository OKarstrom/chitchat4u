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

        Task SaveMessage(string Content, string senderID, int connectionID);
        
    }
}
