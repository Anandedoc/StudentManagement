using System.ComponentModel;

namespace Services.Contracts
{
    public class LoginContract
    {
        [DefaultValue("admin")]
        public string UserName { get; set; }
        [DefaultValue("password123")]
        public string Password { get; set; }
    }
}
