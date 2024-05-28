﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Infrastructure.JWT
{
    public class JwtOptions
    {

      
            public string Issuer { get; set; }
            public string Audience { get; set; }
            public int Lifetime { get; set; }
            public string Signingkey { get; set; }
        

    }
}
