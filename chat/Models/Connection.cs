﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class Connection
    {
        public Connection()
        {
            this.Users = new List<ApplicationUserConnection>();
            this.Messages = new List<Message>();
        }
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public virtual List<ApplicationUserConnection> Users { get; set; }
        public virtual List<Message> Messages { get; set; }

    }
}
