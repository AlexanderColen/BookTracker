using System.Collections.Generic;

namespace BookTracker.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public List<Book> OwnedBooks { get; set; }
        public List<Book> Wishlist { get; set; }
    }
}
