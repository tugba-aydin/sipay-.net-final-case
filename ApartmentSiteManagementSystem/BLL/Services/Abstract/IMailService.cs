using BLL.Models;
using BLL.Models.Requests;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IMailService
    {
        void SendEmailForNotIsPaidInvoice();
        void SendEmailForPassword(MailModel mailModel);
    }
}
