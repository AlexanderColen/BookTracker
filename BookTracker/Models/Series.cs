using System.Collections.Generic;

namespace BookTracker.Models
{
    public class Series
    {
        public int SeriesID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<Book> Books { get; set; }
    }
}
