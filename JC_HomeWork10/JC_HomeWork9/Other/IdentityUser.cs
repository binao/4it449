﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;


namespace JC_HomeWork9.Other
{
    public class IdentityUser : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}