using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Account
{
    public class GetAccountDTO
    {
        public int AccountId { get; set; }

        public string UserName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Role { get; set; } = null!;

        public int Point { get; set; }

        public string AvatarUrl { get; set; } = null!;

        public bool IsActive { get; set; }
    }

    public class AccountDTO
    {
        public string UserName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Role { get; set; } = null!;

        public int Point { get; set; }

        public string AvatarUrl { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
