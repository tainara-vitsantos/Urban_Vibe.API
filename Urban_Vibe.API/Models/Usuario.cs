using Microsoft.AspNetCore.Identity;

namespace Urban_Vibe.API.Models
{
    public class Usuario : IdentityUser
    {
        public string? Name { get; set; }
    }
}
