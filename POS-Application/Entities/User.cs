using BCrypt.Net;

namespace POSApp.Entities
{
    public class User (int id, string name, string email, string password, string role)
    {
        public int Id { get; set; } = id;
        public string name { get; set; } = name;
        public string email { get; set; } = email;
        public string password { get; set; } = BCrypt.Net.BCrypt.HashPassword(password);
        public string role { get; set; } = role;
    }
}