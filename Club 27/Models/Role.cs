using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Club_27.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Club_27.Models
{
    public class Role
    {
        public Role()
        { 

        }

        public Role(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

