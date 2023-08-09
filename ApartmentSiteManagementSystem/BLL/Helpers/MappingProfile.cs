using AutoMapper;
using BLL.Models.Requests.Apartment;
using BLL.Models.Requests.Invoice;
using BLL.Models.Requests.Message;
using BLL.Models.Requests.Payment;
using BLL.Models.Requests.User;
using BLL.Models.Responses.Apartment;
using BLL.Models.Responses.Invoice;
using BLL.Models.Responses.Message;
using BLL.Models.Responses.User;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateApartmentRequest, Apartment>().ReverseMap();
            CreateMap<UpdateApartmentRequest, Apartment>().ReverseMap();
            CreateMap<Apartment, ApartmentResponse>().ReverseMap();

            CreateMap<CreateInvoiceRequest, Invoice>().ReverseMap();
            CreateMap<UpdateInvoiceRequest, Invoice>().ReverseMap();
            CreateMap<Invoice,InvoiceResponse>().ReverseMap();
            
            CreateMap<CreateUserRequest,User>().ReverseMap();
            CreateMap<UpdateUserRequest,User>().ReverseMap();
            CreateMap<User,UserResponse>().ReverseMap();

            CreateMap<CreateMessageRequest,Message>().ReverseMap();
            CreateMap<UpdateMessageRequest,Message>().ReverseMap();
            CreateMap<Message,MessageResponse>().ReverseMap();

            CreateMap<CreatePaymentRequest,Payment>().ReverseMap();
        }
    }
}
