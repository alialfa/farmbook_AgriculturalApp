using System.Collections.Generic;

namespace FarmBook_v7.Models
{
    public class PresentState
    {
        public IEnumerable<ChatMessage> Messages { get; set; }

        public ICollection<UsersSignedIn> UsersSigned { get; set; }
    }
}