using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReverseEngineeringDb.DataContext
{
    public class Address
    {
        [Key]
        public int CompanyKey { get; set; }
        [MaxLength(100)]
        public string StreetName { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }

        private Company Company { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public Post Post { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}