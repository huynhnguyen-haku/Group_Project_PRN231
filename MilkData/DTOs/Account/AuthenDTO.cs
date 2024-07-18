using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Account
{
    public class AuthenDTO
    {
        public int Id { get; set; }
        public string Role { set; get; }
        public string Token { get; set; }
    }
}
