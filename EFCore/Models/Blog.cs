using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public Post Posts { get; set; }
    }
}
