using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Requests.Message
{
    public class CreateMessageRequest
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
    }
}
