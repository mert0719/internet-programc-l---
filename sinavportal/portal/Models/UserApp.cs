using Microsoft.AspNetCore.Identity;

namespace portal.Models
{
    public class UserApp:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
