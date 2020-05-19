namespace WebApi.Infrastructure.Models
{
    public class LoginUser
    {
        
        public string Name { get; set; }
        public string Password { get; set;}
        public string PhoneNumber { get; set;}
        public string Email { get; set;}
        public string Role { get; set;}
        public string Address { get; set; }
        public string Status { get; set; }
    }
}