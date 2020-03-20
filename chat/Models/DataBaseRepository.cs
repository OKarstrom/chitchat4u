using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class DataBaseRepository : IDataBaseRepository
    {
        private readonly AppDbContext appDbContext;

        public DataBaseRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public int AddConnection(Connection c)
        {
            appDbContext.Connection.Add(c);
            return appDbContext.SaveChanges();
        }

        public Connection AddConnection(List<string> id)
        {
            Connection c = new Connection();
            foreach(string s in id)
                c.Users.Add(new ApplicationUserConnection() {ApplicationUserID= s });
            appDbContext.Connection.Add(c);
            try {
                appDbContext.SaveChanges();
            }
            catch{ };
                    
            return c;
        }

        public List<Connection> GetAllConnections()
        {
            return appDbContext.Connection.AsEnumerable<Connection>().ToList();
        }

        public List<Connection> GetAllConnections(string id)
        {
            var u = appDbContext.UserConnections.Where(c => c.ApplicationUserID == id).Select(s => s.Connection).Select(s => s.Users.Where(s=>s.ApplicationUserID != id)); 
            var au = appDbContext.Users
                .First<ApplicationUser>(a => a.Id.Equals(id))
                .Connections.Select<ApplicationUserConnection, Connection>(auc => auc.Connection);
            return au.ToList();
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return appDbContext.Users.AsEnumerable<ApplicationUser>().ToList();
        }

        //List<ConnectionVM> IDataBaseRepository.GetAllConnections(string id)
        //{
        //    var u = appDbContext.UserConnections.Where(c => c.ApplicationUserID == id).Select(s => s.Connection).Select(s => s.Users.Where(s => s.ApplicationUserID != id));
        //    foreach(ApplicationUserConnection a in u)
        //    {
        //        //a.Connection.Users
        //        //a.AppUser.UserName;//Name
        //        //a.ApplicationUserID;//Send address
        //        //a.ConnectionID;//ConnectionID
        //    }
        //}
    }

    public class UserManager
    {
    }
}
