﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Responses.Message
{
    public class MessageResponse
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
    }
}
