using AutoMapper;
using AutoMapper.Internal;
using BLL.Models;
using BLL.Models.Requests;
using BLL.Services.Abstract;
using DAL.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class MailService : IMailService
    {
        private readonly MailSettingsModel mailSettings;
        private readonly IInvoiceService invoiceService;
        private readonly IMapper mapper;
        public MailService(IOptions<MailSettingsModel> _mailSettings, IInvoiceService _invoiceService,IMapper _mapper)
        {
            mailSettings = _mailSettings.Value;
            invoiceService = _invoiceService;
            mapper = _mapper;
        }
        public async Task SendEmail(MailModel mailModel)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailModel.ToEmail));
            email.Subject = mailModel.Subject;
            var builder = new BodyBuilder();
            if (mailModel.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailModel.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailModel.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
        public void SendEmailForNotIsPaidInvoice()
        {
            Console.WriteLine("");
            var response = invoiceService.GetAllNotPaidInvoices();
            var invoiceList = mapper.Map<List<Invoice>>(response);
            foreach (var item in invoiceList)
            {
                if (item.User != null)
                {
                    MailModel model = new MailModel()
                    {
                        ToEmail=item.User.Email,
                        Subject="Ödenmemiş "+item.Type+" Borcu",
                        Body="Merhaba "+ item.Period+ " dönemi için "+ item.Price +"TL tutarında ödenmemiş"+ item.Type+" borcunuz bulunmaktadır." 
                    };
                    SendEmail(model);
                }
            }
        }

        public void SendEmailForPassword(MailModel mailModel)
        {
            SendEmail(mailModel);
        }
    }
}
