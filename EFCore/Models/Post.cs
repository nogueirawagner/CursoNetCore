﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
