using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Callapp.Domain.Aggregates
{
    public class User
    {
        public int Id { get; set; }

        public Guid EntityId { get; set; }

        public UserProfile UserProfile { get; set; } = new UserProfile();

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    

        public void CreateUser(string username, string password, string email)
        {
            EntityId = Guid.NewGuid();
            UserName = username;
            Password = password;
            Email = email;
        }
    }
}
