using BLL.Models.Requests.Message;
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
        List<Message> GetAllMessages();
        void SendMessage(CreateMessageRequest message);
        Message GetMessageDetail(string id);
    }
}
