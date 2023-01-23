using ATMApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Application.Models.DTOs
{
    public class ProcessDTO
    {
        public decimal Amout { get; set; }
        public Process Process { get; set; }

    }
}
