using ATMApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Application.Models.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Status Status => Status.Active;
        public DateTime CreatedDate => DateTime.Now;
        public Roles Role => Roles.Personnel;

    }
}
