using BLL.Models.Requests.Message;
using BLL.Models.Responses.Message;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IMessageService
    {
        List<MessageResponse> GetAllMessages();
        void SendMessage(CreateMessageRequest message);
        MessageResponse GetMessageDetail(string id);
    }
}
