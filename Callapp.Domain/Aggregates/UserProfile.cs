using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callapp.Domain.Aggregates
{
    public class UserProfile
    {
        public int Id { get; set; }

        public Guid EntityId { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        [MaxLength(11)]
        public string PersonalNumber { get; set; } = string.Empty;
    }
}
