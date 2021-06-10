using System;
namespace WorldWideBasketball.Models
{
    public class Account
    {
        public string Username { get; set; } = "default";

        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public DateTime Data { get; set; } = DateTime.Now.Date;

    }
}
