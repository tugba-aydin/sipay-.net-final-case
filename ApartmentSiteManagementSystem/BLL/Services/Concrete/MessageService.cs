using AutoMapper;
using BLL.Models.Requests.Message;
using BLL.Services.Abstract;
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class MessageService:IMessageService
    {
        private readonly IRepository<Message> repository;
        private readonly IMapper mapper;
        public MessageService(IRepository<Message> _repository,IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        public List<Message> GetAllMessages() {
            return repository.GetAll();
        }

        public Message GetMessageDetail(string id)
        {
            if (id != null)
            {
                UpdateMessageRequest request = new UpdateMessageRequest();
                request.Id = id;
                request.IsRead = true;
                var model= mapper.Map<Message>(request);
                repository.Update(model);
                return repository.GetById(id);
            }
            return null;
        }

        public void SendMessage (CreateMessageRequest messageRequest)
        {
            if (messageRequest != null)
            {
                var message=mapper.Map<Message>(messageRequest);
                message.Id = Guid.NewGuid().ToString();
                message.IsRead = false;
                message.IsNew= true;
                repository.Add(message);
            }
        }
    }
}
