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

        public int ChangeDisplayName(ApplicationUser user)
        {
            appDbContext.Users.Update(user);
            return appDbContext.SaveChanges();
        }

        public List<ApplicationUser> GetAddableFriends(string userId)
        {
            List<ConnectionVM> conlist = GetAllConnections(userId);
            List<ApplicationUser> Users = GetAllUsers();

            Dictionary<string, UserDetails> dictUsers = new Dictionary<string, UserDetails>();
            
            foreach (ConnectionVM cvm in conlist)
            {
                foreach (UserDetails ud in cvm.UserList)
                {
                    if (!ud.Id.Equals(userId))
                        dictUsers.Add(ud.Id, ud);
                }
            }

            List<ApplicationUser> remove = new List<ApplicationUser>();

            foreach (ApplicationUser au in Users)
            {
                if (dictUsers.ContainsKey(au.Id))
                {
                    remove.Add(au);
                }
            }

            foreach (ApplicationUser u in remove)
            {
                Users.Remove(u);
            }
            


            return Users;
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
            return appDbContext.Users.ToList();
        }

        /// <summary>
        /// Get messaget for connetion id
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        public List<MessageVM> GetMessages(int chatId)
        {
            List<MessageVM> retVal = new List<MessageVM>(); 
            try
            {
                retVal= (from mess in appDbContext.Message
                     where mess.Connection.Id.Equals(chatId)
                     select new MessageVM()
                     {
                         UserId = mess.ApplicationUser.Id,
                         UserName = mess.ApplicationUser.DisplayName,
                         Content = mess.Content
                     }).ToList();
            }
            catch { }
            return retVal;
                            
        }

        public async Task SaveMessage(string Content, string senderID, int connectionID)
        {
            Message msg = new Message();
            msg.Content = Content;

            msg.ApplicationUser = await appDbContext.Users.FindAsync(senderID);
            msg.Connection = await appDbContext.Connection.FindAsync(connectionID);
            msg.ApplicationUser.Id = senderID;
            msg.Connection.Id = connectionID;
            appDbContext.Message.Add(msg);
            
            int ret = await appDbContext.SaveChangesAsync();
            
        }
    }

}
