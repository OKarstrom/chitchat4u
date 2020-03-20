using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public interface IDataBaseRepository
    {
        List<Connection> GetAllConnections(string id);

        List<ApplicationUser> GetAllUsers();

        Connection AddConnection(List<string> id);
        
    }
}
