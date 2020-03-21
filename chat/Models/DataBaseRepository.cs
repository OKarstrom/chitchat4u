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

        /// <summary>
        /// Get connections for a userId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ConnectionVM> GetAllConnections(string id)
        {

            var connectionsRequired = (from con in appDbContext.UserConnections
                                       join user in appDbContext.Users
                                       on con.ApplicationUserID equals user.Id
                                       where user.Id.Equals(id)
                                       select new
                                       {
                                           Connection = con.Connection.Id,
                                       }).ToList();

            var Connections = (from con in connectionsRequired
                              join ucon in appDbContext.UserConnections
                              on con.Connection equals ucon.ConnectionID
                              join user in appDbContext.Users
                              on ucon.ApplicationUserID equals user.Id
                              where user.Id != id
                              select new
                              {
                                  ConnectionId = con.Connection,
                                  UserId = user.Id,
                                  UserEmail = user.Email,
                                  UserDisplayName = user.DisplayName
                              }).ToList();

            //Sorting dictionary if we have multiple users in one connection
            Dictionary<int, ConnectionVM> conDict = new Dictionary<int, ConnectionVM>();

            foreach (var con in Connections)
            {
                if (!conDict.ContainsKey(con.ConnectionId))//For handling multiple users in one connection
                {
                    conDict.Add(
                        con.ConnectionId,
                        new ConnectionVM
                        {
                            Id = con.ConnectionId,
                            UserList = new List<UserDetails>()
                        });
                }

                conDict[con.ConnectionId].UserList.Add(
                    new UserDetails
                    {
                        Id = con.UserId,
                        DisplayName = con.UserDisplayName,
                        Email = con.UserEmail
                    });
            }

            return conDict.Values.ToList();
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
