﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Message
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public bool IsRead { get; set; }
        public bool IsNew { get; set; }
    }
}
