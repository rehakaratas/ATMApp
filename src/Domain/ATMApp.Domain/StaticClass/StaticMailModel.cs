using ATMApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Domain.StaticClass
{
    public class StaticMailModel
    {
        public static MailModel successMail = new MailModel()
        {
            Body = "Mail Progress Success",
            Subject="Ok"
        };

        public static MailModel failedMail = new MailModel()
        {
            Body = "Mail Progress Unsuccess",
            Subject = "Cancel"
        };
    }
}
