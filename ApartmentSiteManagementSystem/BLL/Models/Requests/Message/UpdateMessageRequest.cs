using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Requests.Message
{
    public class UpdateMessageRequest
    {
        public string Id { get; set; }
        public bool? IsRead { get; set; }
    }
}
