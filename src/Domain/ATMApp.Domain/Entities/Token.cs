using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Domain.Entities
{
    public class Token
    {
        public string AccessToken { get; set; } // Üretilen token'ın ta kendisini tutar.
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; } // AccessToken süresi doldu !!! --> Tekrar Yenileniyor.
    }
}
