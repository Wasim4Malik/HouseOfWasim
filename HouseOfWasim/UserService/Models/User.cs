﻿using Microsoft.AspNetCore.Identity;

namespace UserService.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
