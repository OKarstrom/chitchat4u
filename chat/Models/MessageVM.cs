﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class MessageVM
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
    }
}
