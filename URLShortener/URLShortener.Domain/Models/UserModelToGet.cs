using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortener.Domain.Models
{
    public class UserModelToGet
    {
        public string Id { get; set; }
        public bool IsAuth { get; set; }
        public string? Role { get; set; }
    }
}
