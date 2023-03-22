using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortener.Domain.Models
{
    public class URLModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortedUrl { get; set; }

        public long CreatorId { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
