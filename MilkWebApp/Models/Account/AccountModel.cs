namespace MilkWebApp.Models.Account
{
    public class AccountModel
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

        public string HttpMethod { get; set; }
    }
}
