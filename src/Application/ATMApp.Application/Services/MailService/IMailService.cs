using ATMApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Application.Services.MailService
{
    public interface IMailService
    {
        Task SendEmail(MailModel model);
    }
}
